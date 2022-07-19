using Moq;
using Packbacker.Domain.Abstractions;

namespace Packbacker.ViewModels.Design
{
    public class DesignGearEditorViewModel : GearEditorViewModel
    {
        public DesignGearEditorViewModel() : base(MockGearListViewModel(), new Mock<IItemStore>().Object)
        {
        }

        private static GearListViewModel MockGearListViewModel()
        {
            return new DesignGearListViewModel();
        }
    }
}
