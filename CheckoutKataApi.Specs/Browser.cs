using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace CheckoutKataApi.Specs
{
    public class Browser
    {
        private HttpWebResponse _webResponse;

        public void Post(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
        }

        public void Get(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
        }

        public void AssertStatusCodeIs(HttpStatusCode httpStatusCode)
        {
            Assert.That(_webResponse.StatusCode, Is.EqualTo(httpStatusCode));
        }

        public Uri GetLocationUri()
        {
            return new Uri(_webResponse.GetResponseHeader("Location"));
        }

        public string GetResponseBody()
        {
            var responseStream = _webResponse.GetResponseStream();
            Assert.IsNotNull(responseStream, "responseStream");
            var streamReader = new StreamReader(responseStream);
            var body = streamReader.ReadToEnd();
            return body;
        }
    }
}