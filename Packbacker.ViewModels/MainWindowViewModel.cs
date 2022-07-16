using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Packbacker.ViewModels.Services;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainWindowViewModel
    {
        private readonly ISaveFileService saveFileService;

        public MainWindowViewModel(GearEditorViewModel gearEditorViewModel, ISaveFileService saveFileService)
        {
            GearEditorViewModel = gearEditorViewModel;

            this.saveFileService = saveFileService;
        }

        public GearEditorViewModel GearEditorViewModel { get; }

        [RelayCommand]
        public async Task SaveAsync()
        {
            await saveFileService.SaveAsync("Hello world!", ".pack", "Pack files (*.pack)|*.pack");
        }
    }
}
