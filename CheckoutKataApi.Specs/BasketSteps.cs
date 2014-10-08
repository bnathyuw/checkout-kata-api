using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class BasketSteps
    {
        private Uri _basketUri;
        private HttpWebResponse _webResponse;

        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
            _basketUri = CreateBasket("");
        }

        [When(@"I check my basket")]
        public void WhenICheckMyBasket()
        {
            GetBasket(_basketUri);
        }

        [Then(@"the price should be (.*)")]
        public void ThenThePriceShouldBe(int expectedPrice)
        {
            AssertPriceIsCorrect(expectedPrice);
        }

        private Uri CreateBasket(string basketContents)
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/baskets");
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            var webResponse = (HttpWebResponse)webRequest.GetResponse();


            Assert.That(webResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            return new Uri(webResponse.GetResponseHeader("Location"));
        }

        private void GetBasket(Uri basketUri)
        {
            var webRequest = WebRequest.Create(basketUri);
            _webResponse = (HttpWebResponse) webRequest.GetResponse();

            Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        private void AssertPriceIsCorrect(int expectedPrice)
        {
            var responseStream = _webResponse.GetResponseStream();
            Assert.IsNotNull(responseStream, "responseStream");
            var streamReader = new StreamReader(responseStream);
            var body = streamReader.ReadToEnd();

            var serializer = new JavaScriptSerializer();
            var basket = serializer.Deserialize<Basket>(body);

            Assert.That(basket.Price, Is.EqualTo(expectedPrice));
        }
    }

    public class Basket
    {
        public int Price { get; set; }
    }
}
