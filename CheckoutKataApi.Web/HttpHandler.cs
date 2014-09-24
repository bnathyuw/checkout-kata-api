using System.Web;

namespace CheckoutKataApi.Web
{
	public class HttpHandler : IHttpHandler 
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.Write("welcome");
		}

		public bool IsReusable { get; private set; }
	}
}