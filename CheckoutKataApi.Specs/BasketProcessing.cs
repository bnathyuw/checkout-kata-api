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
            Post(new Uri("http://checkout-kata-api.local/baskets"));

            AssertStatusCodeIs(HttpStatusCode.Created);

            return new Uri(_webResponse.GetResponseHeader("Location"));
        }

        public void GetBasket(Uri basketUri)
        {
            Get(basketUri);

            AssertStatusCodeIs(HttpStatusCode.OK);
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

        private void Get(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
        }

        private void AssertStatusCodeIs(HttpStatusCode httpStatusCode)
        {
            Assert.That(_webResponse.StatusCode, Is.EqualTo(httpStatusCode));
        }

        private void Post(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
        }
    }
}