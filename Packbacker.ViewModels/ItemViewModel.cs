using MVVM;

namespace Packbacker.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        public ItemViewModel(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
    }
}
