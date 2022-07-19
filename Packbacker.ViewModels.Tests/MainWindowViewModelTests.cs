using Moq;
using Packbacker.Domain.Abstractions;
using System.Linq;
using System.Text;
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
            Mock<IOpenFileService> openFileService = new Mock<IOpenFileService>();
            Mock<IItemStore> itemStore = new Mock<IItemStore>();

            GearEditorViewModel gearEditorViewModel = new(new GearListViewModel(Enumerable.Empty<ItemViewModel>()), new Mock<IItemStore>().Object);
            MainWindowViewModel mainWindowViewModel = new(gearEditorViewModel, saveFileService.Object, openFileService.Object, itemStore.Object);

            await mainWindowViewModel.SaveAsync();

            string json = """
                    {"ItemIds":[]}
                    """;

            byte[] expectedContent = Encoding.UTF8.GetBytes(json);

            saveFileService.Verify(s => s.SaveAsync(expectedContent, ".pack", "Pack files (*.pack)|*.pack"));
        }
    }
}
