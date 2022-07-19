using System.Text.Json.Serialization;

namespace Packbacker.Domain.Persistence.Json
{
    [JsonSerializable(typeof(ItemCatalog))]
    internal partial class ItemCatalogContext : JsonSerializerContext
    {
    }
}
