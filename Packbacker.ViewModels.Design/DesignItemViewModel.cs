using Packbacker.Domain.Units;

namespace Packbacker.ViewModels.Design
{
    public class DesignItemViewModel : ItemViewModel
    {
        public DesignItemViewModel() : base("Backpack", new Weight(20))
        {
        }
    }
}
