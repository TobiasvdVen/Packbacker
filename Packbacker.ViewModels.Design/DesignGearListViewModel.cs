using Packbacker.Domain;
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
                new ItemViewModel(new Item(Guid.NewGuid(), "Backpack", new Weight(2300), WeightUnit.Grams)),
                new ItemViewModel(new Item(Guid.NewGuid(), "Tent", new Weight(1700), WeightUnit.Grams)),
                new ItemViewModel(new Item(Guid.NewGuid(), "Sleeping Bag", new Weight(450), WeightUnit.Grams))
            };
        }
    }
}