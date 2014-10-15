using System.Net;
using System.Web;

namespace CheckoutKataApi.Web
{
    public class CreateBasketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var basketStore = new BasketStore();
            Basket basket = new Basket();

            var basketId = basketStore.Add(basket);

            context.Response.StatusCode = (int)HttpStatusCode.Created;
            context.Response.RedirectLocation = "http://checkout-kata-api.local/baskets/" + basketId;
        }

        public bool IsReusable { get; private set; }
    }
}