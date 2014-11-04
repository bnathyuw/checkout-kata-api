using CheckoutKataApi.Web;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
    [TestFixture]
    public class PriceCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase("A", 50)]
        [TestCase("AB", 80)]
        [TestCase("ABC", 100)]
        [TestCase("ABCD", 115)]
        public void Should_return_expected_price(string items, int expectedPrice)
        {
            var priceCalculator = new PriceCalculator();
            Assert.That(priceCalculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
        }

        [TestCase("AAA", 130)]
        [TestCase("BB", 45)]
        public void Should_return_expected_discount_price(string items, int expectedPrice)
        {
            var priceCalculator = new PriceCalculator();
            Assert.That(priceCalculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
        }
    }
}