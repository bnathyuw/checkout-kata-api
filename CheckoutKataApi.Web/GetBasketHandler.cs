using System.Web;
using System.Web.Script.Serialization;

namespace CheckoutKataApi.Web
{
    public class GetBasketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var basketStore = new BasketStore();
            var url = context.Request.Url.ToString();
            var basketIdIndex = url.LastIndexOf('/');
            var basketId = int.Parse(url.Substring(basketIdIndex + 1));
            var basket = basketStore.Get(basketId);
            var serializer = new JavaScriptSerializer();
            var serializedBasket = serializer.Serialize(basket);
            context.Response.Write(serializedBasket);
        }

        public bool IsReusable { get; private set; }
    }
}