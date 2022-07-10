using MVVM;
using System.Collections.ObjectModel;

namespace Packbacker.ViewModels
{
    public class PackViewModel : ViewModel
    {
        public PackViewModel(IEnumerable<ItemViewModel> items)
        {
            Items = new ObservableCollection<ItemViewModel>(items);
        }

        public bool Loading { get; } = true;
        public ObservableCollection<ItemViewModel> Items { get; }
    }
}