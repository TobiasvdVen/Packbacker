using Fub;
using Packbacker.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Packbacker.ViewModels.Tests
{
    public class GearListViewModelTests
    {
        [Fact]
        public void GivenGearListWithItem_WhenItemDeleted_ItemIsRemovedFromList()
        {
            Item item = Fub<Item>.Simple();
            ItemViewModel itemViewModel = new(item);
            GearListViewModel gearListViewModel = new(new List<ItemViewModel>() { itemViewModel });

            itemViewModel.Delete();

            Assert.Empty(gearListViewModel.Items);
        }

        [Fact]
        public void GivenEmptyGearList_WhenItemAddThenDeleted_ItemIsRemovedFromList()
        {
            Item item = Fub<Item>.Simple();
            ItemViewModel itemViewModel = new(item);
            GearListViewModel gearListViewModel = new(Enumerable.Empty<ItemViewModel>());

            gearListViewModel.AddItem(itemViewModel);

            itemViewModel.Delete();

            Assert.Empty(gearListViewModel.Items);
        }
    }
}
