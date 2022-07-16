using MVVM;
using Packbacker.Domain.Units;

namespace Packbacker.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly Weight weight;

        public ItemViewModel(string name, Weight weight)
        {
            this.weight = weight;

            Name = name;
        }

        public string Name { get; set; }
        public string Weight => weight.GetDisplayString(WeightUnit);
        public WeightUnit WeightUnit { get; set; }
    }
}
