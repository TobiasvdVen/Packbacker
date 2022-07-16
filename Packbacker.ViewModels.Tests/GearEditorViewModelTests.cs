using System.Linq;
using Xunit;

namespace Packbacker.ViewModels.Tests
{
    public class GearEditorViewModelTests
    {
        [Fact]
        public void GivenItemNameAndWeight_WhenAddButtonPressed_ItemIsAddedToList()
        {
            GearListViewModel gearListViewModel = new(Enumerable.Empty<ItemViewModel>());
            GearEditorViewModel gearEditorViewModel = new(gearListViewModel)
            {
                AddItemName = "Backpack",
                AddItemWeight = "16"
            };

            gearEditorViewModel.Add();

            ItemViewModel addedItem = gearListViewModel.Items.Single();

            Assert.Equal("Backpack", addedItem.Name);
            Assert.Equal("16g", addedItem.Weight);
        }
    }
}
