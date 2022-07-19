using Packbacker.Domain.Units;

namespace Packbacker.Domain
{
    public record Item(
        Guid Id,
        string Name,
        Weight Weight,
        WeightUnit DefaultWeightUnits)
    {
    }
}
