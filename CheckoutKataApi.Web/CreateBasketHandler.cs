using System.Net;
using System.Web;

namespace CheckoutKataApi.Web
{
    public class CreateBasketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Created;
            context.Response.RedirectLocation = "http://checkout-kata-api.local/baskets/1";
        }

        public bool IsReusable { get; private set; }
    }
}