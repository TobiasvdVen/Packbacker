namespace Packbacker.ViewModels.Design
{
    public class DesignPackViewModel : PackViewModel
    {
        public DesignPackViewModel() : base(MockItems())
        {
        }

        private static IEnumerable<ItemViewModel> MockItems()
        {
            return new List<ItemViewModel>()
            {
                new ItemViewModel("Backpack", 2300),
                new ItemViewModel("Tent", 1700),
                new ItemViewModel("Sleeping Bag", 450)
            };
        }
    }
}