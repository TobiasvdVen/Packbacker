using Packbacker.Domain.Services;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Xunit;

namespace Packbacker.Domain.Tests.Services
{
    public class FileItemStoreTests
    {
        [Fact]
        public async Task GivenEmptyStore_WhenGetItems_ReturnEmpty()
        {
            string directory = "test/";

            IFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                {
                    $"{directory}/ItemCatalog",
                    new MockFileData(string.Empty)
                }
            });

            FileItemStore itemStore = new(fileSystem, directory);

            IEnumerable<Item?>? items = await itemStore.GetItemsAsync();

            Assert.Empty(items);
        }
    }
}
