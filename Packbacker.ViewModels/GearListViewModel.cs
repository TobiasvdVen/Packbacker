using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class GearListViewModel
    {
        [ObservableProperty]
        private bool loading;

        [ObservableProperty]
        private ObservableCollection<ItemViewModel> items;

        public GearListViewModel(IEnumerable<ItemViewModel> items)
        {
            loading = true;

            this.items = new ObservableCollection<ItemViewModel>(items);

            foreach (ItemViewModel item in items)
            {
                item.OnDeleted += Item_OnDeleted;
            }
        }

        public void AddItem(ItemViewModel item)
        {
            Items.Add(item);

            item.OnDeleted += Item_OnDeleted;
        }

        private void Item_OnDeleted(ItemViewModel deleted)
        {
            deleted.OnDeleted -= Item_OnDeleted;

            Items.Remove(deleted);
        }
    }
}