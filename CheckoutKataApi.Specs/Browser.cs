using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace CheckoutKataApi.Specs
{
    public class Browser
    {
        private HttpWebResponse _webResponse;
        private string _responseBody;

        public string ResponseBody
        {
            get { return _responseBody; }
        }

        public void Post(Uri requestUri, string body)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";
            webRequest.ContentLength = body.Length;
            using (var requestStream = webRequest.GetRequestStream())
            {
                using (var streamWriter = new StreamWriter(requestStream))
                {
                    streamWriter.Write(body);
                }
            }
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
            _responseBody = ReadResponseBody(_webResponse);

            Console.WriteLine(
                "Method: {0} \nUri: {1} \n{2} \nBody: {3}\n=====",
                webRequest.Method, webRequest.RequestUri, webRequest.Headers, body);

            Console.WriteLine("StatusCode: {0} \n{1} \nBody: {2}\n=====",
                _webResponse.StatusCode, _webResponse.Headers, ResponseBody);
        }

        public void Get(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
            _responseBody = ReadResponseBody(_webResponse);

            Console.WriteLine(
                "Method: {0} \nUri: {1} \n{2}\n=====",
                webRequest.Method, webRequest.RequestUri, webRequest.Headers);

            Console.WriteLine(
                "StatusCode: {0} \n{1} \nBody: {2}\n=====",
                _webResponse.StatusCode, _webResponse.Headers, ResponseBody);
        }

        public void AssertStatusCodeIs(HttpStatusCode httpStatusCode)
        {
            Assert.That(_webResponse.StatusCode, Is.EqualTo(httpStatusCode));
        }

        public Uri GetLocationUri()
        {
            return new Uri(_webResponse.GetResponseHeader("Location"));
        }

        private string ReadResponseBody(WebResponse httpWebResponse)
        {
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                Assert.IsNotNull(responseStream, "responseStream");
                using (var streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}