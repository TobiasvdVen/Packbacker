using System.Collections.ObjectModel;

namespace Packbacker.ViewModels
{
    public class PackViewModel
    {
        public PackViewModel(IEnumerable<string> items)
        {
            Items = new ObservableCollection<string>(items);
        }

        public ObservableCollection<string> Items { get; }
    }
}