namespace Packbacker.Domain.Abstractions
{
    public interface IItemStore
    {
        Task AddItemAsync(Item item);
        Task<IEnumerable<Item>> GetItemsAsync();
    }
}
