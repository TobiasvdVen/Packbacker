using CommunityToolkit.Mvvm.ComponentModel;
using Packbacker.Domain.Units;

namespace Packbacker.ViewModels.Units
{
    [INotifyPropertyChanged]
    public partial class WeightUnitViewModel
    {
        [ObservableProperty]
        private WeightUnit unit;

        public WeightUnitViewModel(WeightUnit unit)
        {
            this.unit = unit;
        }

        public override string ToString()
        {
            return Unit.ToShortString();
        }
    }
}
