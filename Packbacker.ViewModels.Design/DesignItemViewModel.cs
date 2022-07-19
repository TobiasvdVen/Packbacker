using Packbacker.Domain;
using Packbacker.Domain.Units;

namespace Packbacker.ViewModels.Design
{
    public class DesignItemViewModel : ItemViewModel
    {
        public DesignItemViewModel() : base(MockItem())
        {
        }

        public static Item MockItem()
        {
            return new Item(Guid.NewGuid(), "Backpack", new Weight(20), WeightUnit.Grams);
        }
    }
}
