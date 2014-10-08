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
            var webRequest = WebRequest.Create(_basketUri);
            _webResponse = (HttpWebResponse)webRequest.GetResponse();

            Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        
        [Then(@"the price should be (.*)")]
        public void ThenThePriceShouldBe(int expectedPrice)
        {
            var responseStream = _webResponse.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var body = streamReader.ReadToEnd();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Basket basket = serializer.Deserialize<Basket>(body);

            Assert.That(basket.Price, Is.EqualTo(expectedPrice));
        }
    }

    public class Basket
    {
        public int Price { get; set; }
    }
}
