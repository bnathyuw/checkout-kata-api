using System;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class BasketSteps
    {
        private Uri _basketUri;
        private readonly BasketProcessing _basketProcessing = new BasketProcessing();

        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
            _basketUri = _basketProcessing.CreateBasket("");
        }

        [Given(@"I have item (.*) in my basket")]
        [Given(@"I have items (.*) in my basket")]
        public void GivenIHaveItemAInMyBasket(string items)
        {
            _basketUri = _basketProcessing.CreateBasket(items);
        }

        [When(@"I check my basket")]
        public void WhenICheckMyBasket()
        {
            _basketProcessing.GetBasket(_basketUri);
        }

        [Then(@"the price should be (.*)")]
        public void ThenThePriceShouldBe(int expectedPrice)
        {
            _basketProcessing.AssertPriceIsCorrect(expectedPrice);
        }
    }
}
