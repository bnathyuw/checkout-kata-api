using System.IO;
using System.Net;
using System.Web;

namespace CheckoutKataApi.Web
{
    public class CreateBasketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var basketStore = new BasketStore();
            using (var stream = context.Request.InputStream)
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var items = streamReader.ReadToEnd();
                    var basketItems = new BasketItems(items);
                    var price = new PriceCalculator().GetPriceOf(basketItems);
                    
                    var basket = new Basket {Price = price};

                    var basketId = basketStore.Add(basket);

                    context.Response.StatusCode = (int)HttpStatusCode.Created;
                    context.Response.RedirectLocation = "http://checkout-kata-api.local/baskets/" + basketId;
                }
            }
        }

        public bool IsReusable { get; private set; }
    }
}