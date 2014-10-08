using System;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class WalkingSkeletonSteps
    {
        private readonly Browser _browser = new Browser();

        [When(@"I make a request to the API")]
        public void WhenIMakeARequestToTheApi()
        {
            _browser.Get(new Uri("http://checkout-kata-api.local/"));
        }

        [Then(@"I get a response")]
        public void ThenIGetAResponse()
        {
            _browser.AssertStatusCodeIs(HttpStatusCode.OK);

            var body = _browser.GetResponseBody();
            Assert.That(body, Is.EqualTo("welcome"));
        }
    }
}
