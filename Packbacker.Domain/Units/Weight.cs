namespace Packbacker.Domain.Units
{
    public record Weight
    {
        public Weight(int grams)
        {
            Grams = grams;
        }

        public int Grams { get; }

        public static Weight FromGrams(int grams)
        {
            return new Weight(grams);
        }

        public static Weight FromKilograms(double kilograms)
        {
            int grams = KilogramsToGrams(kilograms);

            return new Weight(grams);
        }

        public static Weight Parse(string weight, WeightUnit unit) => unit switch
        {
            WeightUnit.Grams => FromGrams(int.Parse(weight)),
            WeightUnit.Kilograms => FromKilograms(double.Parse(weight)),
            _ => throw new ArgumentException($"Invalid {nameof(WeightUnit)}: {unit}")
        };

        public string GetDisplayString(WeightUnit unit) => unit switch
        {
            WeightUnit.Grams => $"{Grams}g",
            WeightUnit.Kilograms => $"{(double)Grams / 1000:0.00}kg",
            _ => throw new ArgumentException($"Invalid {nameof(WeightUnit)}: {unit}")
        };

        private static int KilogramsToGrams(double kilograms)
        {
            return (int)Math.Round(kilograms * 1000);
        }
    }
}
