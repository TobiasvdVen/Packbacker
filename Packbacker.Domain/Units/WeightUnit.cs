namespace Packbacker.Domain.Units
{
    public enum WeightUnit
    {
        Grams,
        Kilograms
    }

    public static class WeightUnitExtensions
    {
        public static string ToShortString(this WeightUnit unit) => unit switch
        {
            WeightUnit.Grams => "g",
            WeightUnit.Kilograms => "kg",
            _ => throw new ArgumentException($"Unknown weight unit: {unit}.")
        };
    }
}