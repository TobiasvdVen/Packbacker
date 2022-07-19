using Moq;
using Packbacker.Domain.Abstractions;

namespace Packbacker.ViewModels.Design
{
    public class DesignMainWindowViewModel : MainWindowViewModel
    {
        public DesignMainWindowViewModel()
            : base(MockGearEditorViewModel(), new Mock<ISaveFileService>().Object, new Mock<IOpenFileService>().Object, new Mock<IItemStore>().Object)
        {
        }

        private static GearEditorViewModel MockGearEditorViewModel()
        {
            return new DesignGearEditorViewModel();
        }
    }
}
