using System.Linq;

namespace CheckoutKataApi.Web
{
	public class PriceCalculator
	{
		public int GetPriceOf(string items)
		{
			return items.Count(item => item == 'A')*50 +
			       items.Count(item => item == 'B')*30 +
			       items.Count(item => item == 'C')*20 +
			       items.Count(item => item == 'D')*15;
		}
	}
}