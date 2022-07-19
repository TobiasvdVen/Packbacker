using Moq;
using Packbacker.Domain.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Packbacker.ViewModels.Tests
{
    public class GearEditorViewModelTests
    {
        Mock<IItemStore> itemStore;

        GearListViewModel gearListViewModel;
        GearEditorViewModel gearEditorViewModel;

        public GearEditorViewModelTests()
        {
            itemStore = new Mock<IItemStore>();

            gearListViewModel = new(Enumerable.Empty<ItemViewModel>());
            gearEditorViewModel = new(gearListViewModel, itemStore.Object)
            {
                AddItemName = "Backpack",
                AddItemWeight = "16"
            };
        }

        [Fact]
        public async Task GivenItemNameAndWeight_WhenAddButtonPressed_ItemIsAddedToList()
        {
            await gearEditorViewModel.AddAsync();

            ItemViewModel addedItem = gearListViewModel.Items.Single();

            Assert.Equal("Backpack", addedItem.Name);
            Assert.Equal("16g", addedItem.Weight);
        }
    }
}
