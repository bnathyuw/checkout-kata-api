using System.IO;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class WalkingSkeletonSteps
    {
        private HttpWebResponse _webResponse;

        [When(@"I make a request to the API")]
        public void WhenIMakeARequestToTheApi()
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/");
            _webResponse = (HttpWebResponse)webRequest.GetResponse();
        }

        [Then(@"I get a response")]
        public void ThenIGetAResponse()
        {
            var responseStream = _webResponse.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var response = streamReader.ReadToEnd();

            Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.EqualTo("welcome"));
        }
    }
}
