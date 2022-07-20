using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Packbacker.Domain;
using Packbacker.Domain.Abstractions;
using Packbacker.Domain.Units;
using Packbacker.ViewModels.Units;
using System.Collections.ObjectModel;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class GearEditorViewModel
    {
        private readonly IItemStore itemStore;

        [ObservableProperty]
        private string? addItemName;

        [ObservableProperty]
        private string? addItemWeight;

        [ObservableProperty]
        private WeightUnitViewModel selectedWeightUnit;

        public GearEditorViewModel(GearListViewModel gearListViewModel, IItemStore itemStore)
        {
            this.itemStore = itemStore;

            GearListViewModel = gearListViewModel;

            AvailableWeightUnits = Enum.GetValues<WeightUnit>().Select(unit => new WeightUnitViewModel(unit));
            selectedWeightUnit = AvailableWeightUnits.First();
        }

        public GearListViewModel GearListViewModel { get; }

        public IEnumerable<WeightUnitViewModel> AvailableWeightUnits { get; }

        [RelayCommand]
        public async Task AddAsync()
        {
            if (AddItemName == null || AddItemWeight == null)
            {
                return;
            }

            Weight weight = Weight.Parse(AddItemWeight, SelectedWeightUnit.Unit);
            Item item = new(Guid.NewGuid(), AddItemName, weight, SelectedWeightUnit.Unit);

            await itemStore.AddItemAsync(item);

            GearListViewModel.AddItem(new ItemViewModel(item));
        }

        public IEnumerable<Item> ExportGear()
        {
            return GearListViewModel.Items.Select(itemViewModel => itemViewModel.ToItem());
        }

        internal void LoadGear(IEnumerable<Item> items)
        {
            IEnumerable<ItemViewModel> itemViewModels = items.Select(item => new ItemViewModel(item));

            GearListViewModel.Items = new ObservableCollection<ItemViewModel>(itemViewModels);
        }
    }
}
