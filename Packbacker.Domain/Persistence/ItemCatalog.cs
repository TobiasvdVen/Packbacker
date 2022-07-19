namespace Packbacker.Domain.Persistence
{
    internal record ItemCatalog
    {
        public ItemCatalog(IEnumerable<Item> items)
        {
            Items = items;
        }

        public IEnumerable<Item> Items { get; }
    }
}
