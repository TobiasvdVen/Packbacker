using Xunit;

namespace Packbacker.Domain.Units.Tests
{
    public class WeightTests
    {
        [Theory]
        [InlineData(100, WeightUnit.Grams, "100g")]
        [InlineData(100, WeightUnit.Kilograms, "0.10kg")]
        [InlineData(233, WeightUnit.Kilograms, "0.23kg")]
        [InlineData(235, WeightUnit.Kilograms, "0.24kg")]
        [InlineData(237, WeightUnit.Kilograms, "0.24kg")]
        public void GivenWeight_WhenGetDisplayStringGrams_ReturnsGramsAndUnits(int grams, WeightUnit unit, string expectedDisplayString)
        {
            Weight weight = Weight.FromGrams(grams);

            Assert.Equal(expectedDisplayString, weight.GetDisplayString(unit));
        }

        [Theory]
        [InlineData(0.1, 100)]
        [InlineData(0.9999, 1000)]
        [InlineData(0.999, 999)]
        [InlineData(0.9991, 999)]
        public void GivenKiloGrams_WhenWeightCreated_GramsIsCalculatedCorrectly(double kilograms, int expectedGrams)
        {
            Weight weight = Weight.FromKilograms(kilograms);

            Assert.Equal(expectedGrams, weight.Grams);
        }

        [Theory]
        [InlineData("100", WeightUnit.Grams, 100)]
        [InlineData("2.2", WeightUnit.Kilograms, 2200)]
        public void GivenStringAndUnits_WhenWeightCreated_GramsIsCalculatedCorrectly(string input, WeightUnit unit, int expectedGrams)
        {
            Weight weight = Weight.Parse(input, unit);

            Assert.Equal(expectedGrams, weight.Grams);
        }
    }
}
