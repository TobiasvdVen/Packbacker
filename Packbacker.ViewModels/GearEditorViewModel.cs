using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Packbacker.Domain.Units;
using Packbacker.ViewModels.Units;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class GearEditorViewModel
    {
        [ObservableProperty]
        private string? addItemName;

        [ObservableProperty]
        private string addItemWeight;

        public GearEditorViewModel(GearListViewModel gearListViewModel)
        {
            addItemWeight = string.Empty;

            GearListViewModel = gearListViewModel;
            AvailableWeightUnits = Enum.GetValues<WeightUnit>().Select(unit => new WeightUnitViewModel(unit));
            SelectedWeightUnit = AvailableWeightUnits.First();
        }

        public GearListViewModel GearListViewModel { get; }

        public IEnumerable<WeightUnitViewModel> AvailableWeightUnits { get; }

        public WeightUnitViewModel SelectedWeightUnit { get; set; }

        [RelayCommand]
        public void Add()
        {
            if (AddItemName == null)
            {
                return;
            }

            Weight weight = Weight.Parse(addItemWeight, SelectedWeightUnit.Unit);

            GearListViewModel.AddItem(new ItemViewModel(AddItemName, weight));
        }
    }
}
