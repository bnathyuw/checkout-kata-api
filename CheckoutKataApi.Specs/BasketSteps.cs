using System;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class BasketSteps
    {
        private Uri _basketUri;

        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
            _basketUri = CreateBasket("");
        }

        private Uri CreateBasket(string p)
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/baskets");
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            var webResponse = (HttpWebResponse)webRequest.GetResponse();


            Assert.That(webResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            return new Uri(webResponse.GetResponseHeader("Location"));
        }

        [When(@"I check my basket")]
        public void WhenICheckMyBasket()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the price should be (.*)")]
        public void ThenThePriceShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
