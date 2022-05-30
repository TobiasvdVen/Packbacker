namespace Packbacker.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(PackViewModel packViewModel)
        {
            PackViewModel = packViewModel;
        }

        public PackViewModel PackViewModel { get; }
    }
}
