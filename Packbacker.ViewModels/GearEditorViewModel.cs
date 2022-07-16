using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class GearEditorViewModel
    {
        [ObservableProperty]
        private string? addItemName;

        [ObservableProperty]
        private int addItemWeight;

        public GearEditorViewModel(GearListViewModel gearListViewModel)
        {
            GearListViewModel = gearListViewModel;
        }

        public GearListViewModel GearListViewModel { get; }

        [RelayCommand]
        public void Add()
        {
            if (AddItemName == null)
            {
                return;
            }

            GearListViewModel.AddItem(new ItemViewModel(AddItemName, AddItemWeight));
        }
    }
}
