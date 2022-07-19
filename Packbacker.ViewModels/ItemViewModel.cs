using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Packbacker.Domain;
using Packbacker.Domain.Units;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class ItemViewModel
    {
        private readonly Guid id;
        private readonly Weight weight;

        public ItemViewModel(Item item)
        {
            id = item.Id;
            weight = item.Weight;

            Name = item.Name;
        }

        public delegate void Deleted(ItemViewModel deleted);
        public event Deleted? OnDeleted;

        public string Name { get; set; }
        public string Weight => weight.GetDisplayString(WeightUnit);
        public WeightUnit WeightUnit { get; set; }

        [RelayCommand]
        public void Delete()
        {
            OnDeleted?.Invoke(this);
        }

        public Item ToItem()
        {
            return new Item(id, Name, weight, WeightUnit);
        }
    }
}
