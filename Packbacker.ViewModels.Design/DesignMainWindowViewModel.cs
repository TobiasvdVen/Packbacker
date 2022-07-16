using Moq;
using Packbacker.Domain.Services;

namespace Packbacker.ViewModels.Design
{
    public class DesignMainWindowViewModel : MainWindowViewModel
    {
        public DesignMainWindowViewModel() : base(MockGearEditorViewModel(), new Mock<ISaveFileService>().Object)
        {
        }

        private static GearEditorViewModel MockGearEditorViewModel()
        {
            return new DesignGearEditorViewModel();
        }
    }
}
