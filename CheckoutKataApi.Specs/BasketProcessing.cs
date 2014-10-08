using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;

namespace CheckoutKataApi.Specs
{
    public class BasketProcessing
    {
        private HttpWebResponse _webResponse;

        public Uri CreateBasket(string basketContents)
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/baskets");
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            var webResponse = (HttpWebResponse)webRequest.GetResponse();


            Assert.That(webResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            return new Uri(webResponse.GetResponseHeader("Location"));
        }

        public void GetBasket(Uri basketUri)
        {
            var webRequest = WebRequest.Create(basketUri);
            _webResponse = (HttpWebResponse) webRequest.GetResponse();

            Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void AssertPriceIsCorrect(int expectedPrice)
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
}