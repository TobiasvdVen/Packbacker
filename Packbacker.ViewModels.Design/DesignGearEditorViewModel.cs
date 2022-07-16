namespace Packbacker.ViewModels.Design
{
    public class DesignGearEditorViewModel : GearEditorViewModel
    {
        public DesignGearEditorViewModel() : base(MockGearListViewModel())
        {
        }

        private static GearListViewModel MockGearListViewModel()
        {
            return new DesignGearListViewModel();
        }
    }
}
