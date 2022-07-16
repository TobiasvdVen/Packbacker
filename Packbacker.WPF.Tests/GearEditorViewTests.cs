using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FlaUI.UIA3.Async;
using Packbacker.WPF.Tests.Infrastructure;
using Xunit;

namespace Packbacker.WPF.Tests
{
    public class GearEditorViewTests : IClassFixture<AutomationDelaysProvider>
    {
        private const string PackbackerExePathEnvironmentVariable = "PACKBACKER_WPF_EXE_PATH";
        private const string SaveFilePathEnvironmentVariable = "TEST_SAVE_FILE_PATH";

        private readonly IAutomationDelays delays;

        public GearEditorViewTests(AutomationDelaysProvider automationDelaysProvider)
        {
            delays = automationDelaysProvider.AutomationDelays;
        }

        [Fact]
        public async Task AddItemAndSave()
        {
            string fileName = Guid.NewGuid().ToString();
            Console.WriteLine($"Running {nameof(AddItemAndSave)} with file name: {fileName}.");

            string packbackerExePath = GetPackbackerExePath();

            using AsyncApplication packbacker = AsyncApplication.Launch(packbackerExePath, arguments: null, delays);

            try
            {
                using UIA3Automation automation = new();

                AsyncWindow window = packbacker.GetMainWindow(automation);

                AsyncAutomationElement gearEditorView = window.FindFirstChild("GearEditorView");
                AsyncButton addButton = gearEditorView.FindFirstChild("AddButton").AsButton();

                AsyncTextBox nameTextBox = gearEditorView.FindFirstChild("NameField").AsTextBox();
                AsyncTextBox weightTextBox = gearEditorView.FindFirstChild("WeightField").AsTextBox();

                await nameTextBox.EnterAsync("Backpack");
                await weightTextBox.EnterAsync("32");

                await addButton.InvokeAsync();

                Menu menus = window.Window.FindFirstChild("Menus").AsMenu();
                MenuItem fileMenu = menus.FindFirstChild("File").AsMenuItem();

                fileMenu.Items["Save"].Invoke();

                await Task.Delay(1000);

                Window saveWindow = window.Window.FindFirstChild(c => c.ByName("Save As")).AsWindow();

                Button previousLocations = saveWindow.FindFirstDescendant(c => c.ByName("Previous Locations")).AsButton() ?? throw new Exception("Unable to find button: Previous Locations.");
                previousLocations.Invoke();
                await Task.Delay(1000);
                previousLocations.Invoke();

                string directoryPath = GetSaveDirectoryPath();

                TextBox directoryField = saveWindow.FindFirstDescendant(c => c.ByName("Address")).FindFirstChild(c => c.ByName("Address")).AsTextBox() ?? throw new Exception("Unable to find field: Address");
                directoryField.Text = directoryPath;

                TextBox fileNameField = saveWindow.FindAllChildren()[0].FindAllChildren()[4].FindFirstChild("1001").AsTextBox();
                fileNameField.Enter(fileName);

                Button saveButton = saveWindow.FindFirstChild(c => c.ByName("Save")).AsButton();

                await Task.Delay(1000);

                saveButton.Invoke();

                await Task.Delay(1000);

                string filePath = $"{directoryPath}\\{fileName}.pack";

                Assert.True(File.Exists(filePath), $"Save file did not exist: {filePath}");

                TeamCityDetector teamCityDetector = new();

                if (!teamCityDetector.TeamCityDetected)
                {
                    // Not deleting the saved file causes NCrunch to never complete the test, the reason for this eludes me...
                    File.Delete(filePath);
                }
            }
            finally
            {
                await packbacker.CloseAsync();
            }
        }

        private string GetPackbackerExePath()
        {
            return Environment.GetEnvironmentVariable(PackbackerExePathEnvironmentVariable) ?? throw new FileNotFoundException($"Unable to find environment variable specifying executable path: {PackbackerExePathEnvironmentVariable}");
        }

        private string GetSaveDirectoryPath()
        {
            return Environment.GetEnvironmentVariable(SaveFilePathEnvironmentVariable) ?? throw new FileNotFoundException($"Unable to find environment variable specifying save file path: {SaveFilePathEnvironmentVariable}");
        }
    }
}