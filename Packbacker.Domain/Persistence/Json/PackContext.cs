using System.Text.Json.Serialization;

namespace Packbacker.Domain.Persistence.Json
{
    [JsonSerializable(typeof(Pack))]
    public partial class PackContext : JsonSerializerContext
    {
    }
}
