using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Packbacker.Domain;
using Packbacker.Domain.Abstractions;
using Packbacker.Domain.Persistence;
using Packbacker.Domain.Persistence.Json;
using System.Text.Json;

namespace Packbacker.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainWindowViewModel
    {
        private readonly ISaveFileService saveFileService;
        private readonly IOpenFileService openFileService;
        private readonly IItemStore itemStore;

        public MainWindowViewModel(
            GearEditorViewModel gearEditorViewModel,
            ISaveFileService saveFileService,
            IOpenFileService openFileService,
            IItemStore itemStore)
        {
            this.saveFileService = saveFileService;
            this.openFileService = openFileService;
            this.itemStore = itemStore;
            GearEditorViewModel = gearEditorViewModel;
        }

        public GearEditorViewModel GearEditorViewModel { get; }

        [RelayCommand]
        public async Task SaveAsync()
        {
            IEnumerable<Item> gearList = GearEditorViewModel.ExportGear();
            Pack pack = new(gearList.Select(item => item.Id));

            using MemoryStream stream = new();
            await JsonSerializer.SerializeAsync(stream, pack, PackContext.Default.Pack);

            await saveFileService.SaveAsync(stream.ToArray(), ".pack", "Pack files (*.pack)|*.pack");
        }

        [RelayCommand]
        public async Task OpenAsync()
        {
            byte[] fileData = await openFileService.OpenFileAsync();
            using MemoryStream stream = new(fileData);

            Pack? pack = await JsonSerializer.DeserializeAsync(stream, PackContext.Default.Pack);

            if (pack != null)
            {
                IEnumerable<Item> items = await itemStore.GetItemsAsync();

                IEnumerable<Item> itemsInPack = items.Where(item => pack.ItemIds.Contains(item.Id));

                GearEditorViewModel.LoadGear(itemsInPack);
            }
        }
    }
}
