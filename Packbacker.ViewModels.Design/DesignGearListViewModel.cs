using Packbacker.Domain.Units;

namespace Packbacker.ViewModels.Design
{
    public class DesignGearListViewModel : GearListViewModel
    {
        public DesignGearListViewModel() : base(MockItems())
        {
        }

        private static IEnumerable<ItemViewModel> MockItems()
        {
            return new List<ItemViewModel>()
            {
                new ItemViewModel("Backpack", new Weight(2300)),
                new ItemViewModel("Tent", new Weight(1700)),
                new ItemViewModel("Sleeping Bag", new Weight(450))
            };
        }
    }
}