using Packbacker.Domain.Abstractions;
using Packbacker.Domain.Persistence;
using Packbacker.Domain.Persistence.Json;
using System.IO.Abstractions;
using System.Text.Json;

namespace Packbacker.Domain.Services
{
    public class FileItemStore : IItemStore
    {
        private readonly IFileSystem fileSystem;
        private readonly string saveDirectory;
        private List<Item>? items;

        public FileItemStore(IFileSystem fileSystem, string saveDirectory)
        {
            this.fileSystem = fileSystem;
            this.saveDirectory = saveDirectory;
        }

        private string FilePath => Path.Combine(saveDirectory, "ItemCatalog");
        private IFile File => fileSystem.File;

        public async Task AddItemAsync(Item item)
        {
            List<Item> currentItems = await GetItemsInternalAsync();

            currentItems.Add(item);

            ItemCatalog updated = new(currentItems);

            using Stream stream = File.Open(FilePath, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync(stream, updated, ItemCatalogContext.Default.ItemCatalog);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await GetItemsInternalAsync();
        }

        private async Task<List<Item>> GetItemsInternalAsync()
        {
            if (items == null)
            {
                using Stream stream = File.Open(FilePath, FileMode.OpenOrCreate);

                ItemCatalog? itemCatalog = null;

                try
                {
                    itemCatalog = await JsonSerializer.DeserializeAsync(stream, ItemCatalogContext.Default.ItemCatalog);
                }
                catch (Exception)
                { }

                items = itemCatalog?.Items?.ToList() ?? new List<Item>();
            }

            return items;
        }
    }
}
