namespace Packbacker.ViewModels.Design
{
    public class DesignPackViewModel : PackViewModel
    {
        public DesignPackViewModel() : base(MockItems())
        {
        }

        private static IEnumerable<string> MockItems()
        {
            return new List<string>()
            {
                "Backpack",
                "Tent",
                "Sleeping Bag"
            };
        }
    }
}