using System.Web;
using System.Web.Script.Serialization;

namespace CheckoutKataApi.Web
{
    public class GetBasketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Basket basket = new Basket();
            var serializer = new JavaScriptSerializer();
            var serializedBasket = serializer.Serialize(basket);
            context.Response.Write(serializedBasket);
        }

        public bool IsReusable { get; private set; }
    }
}