using Moq;
using Packbacker.ViewModels.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Packbacker.ViewModels.Tests
{
    public class MainWindowViewModelTests
    {
        [Fact]
        public async Task GivenMainWindowViewModel_WhenSave_ThenInvokeSaveFileService()
        {
            Mock<ISaveFileService> saveFileService = new Mock<ISaveFileService>();

            GearEditorViewModel gearEditorViewModel = new(new GearListViewModel(Enumerable.Empty<ItemViewModel>()));
            MainWindowViewModel mainWindowViewModel = new(gearEditorViewModel, saveFileService.Object);

            await mainWindowViewModel.SaveAsync();

            saveFileService.Verify(s => s.SaveAsync(It.IsAny<string>(), ".pack", "Pack files (*.pack)|*.pack"));
        }
    }
}
