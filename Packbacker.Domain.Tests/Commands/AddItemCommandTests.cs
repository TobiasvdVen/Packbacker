using Fub;
using Moq;
using Packbacker.Domain.Abstractions;
using Packbacker.Domain.Commands.Add;
using Packbacker.Domain.Services;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Xunit;

namespace Packbacker.Domain.Tests.Commands
{
    public class AddItemCommandTests
    {
        const string TestDirectory = "test/";

        readonly IFileSystem fileSystem;
        readonly IItemStore itemStore;

        readonly Item item;
        readonly AddItemCommand command;
        readonly ICommandService commandService;

        public AddItemCommandTests()
        {
            fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                {
                    $"{TestDirectory}/ItemCatalog",
                    new MockFileData("""
                    {
                        "Items": []
                    }
                    """)
                }
            });

            itemStore = new FileItemStore(fileSystem, TestDirectory);

            item = Fub<Item>.Simple();
            command = new(item);

            AddItemHandler handler = new(itemStore);

            Mock<ICommandService> mockCommandService = new();
            mockCommandService.Setup(c => c.ExecuteAsync(command)).Callback(async () => await handler.ExecuteAsync(command));
            commandService = mockCommandService.Object;
        }

        [Fact]
        public async Task GivenAddItemCommand_WhenExecuted_ItemAddedToStore()
        {
            await commandService.ExecuteAsync(command);

            IEnumerable<Item?> items = await itemStore.GetItemsAsync();

            Assert.Contains(item, items);
        }

        [Fact]
        public async Task GivenAddItemCommand_WhenNewStoreUsed_ItemIsInStore()
        {
            await commandService.ExecuteAsync(command);

            IItemStore newItemStore = new FileItemStore(fileSystem, TestDirectory);

            IEnumerable<Item?> items = await newItemStore.GetItemsAsync();

            Assert.Single(items, item);
        }
    }
}
