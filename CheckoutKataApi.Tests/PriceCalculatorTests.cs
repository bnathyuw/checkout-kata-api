using CheckoutKataApi.Web;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
    [TestFixture]
    public class PriceCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase("A", 50)]
        public void Should_return_expected_price(string items, int expectedPrice)
        {
            var priceCalculator = new PriceCalculator();
            Assert.That(priceCalculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
        }
    }
}