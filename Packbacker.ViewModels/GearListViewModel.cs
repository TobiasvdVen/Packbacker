using MVVM;
using System.Collections.ObjectModel;

namespace Packbacker.ViewModels
{
    public class GearListViewModel : ViewModel
    {
        public GearListViewModel(IEnumerable<ItemViewModel> items)
        {
            Items = new ObservableCollection<ItemViewModel>(items);
        }

        public bool Loading { get; } = true;
        public ObservableCollection<ItemViewModel> Items { get; }

        public void AddItem(ItemViewModel item)
        {
            Items.Add(item);
        }
    }
}