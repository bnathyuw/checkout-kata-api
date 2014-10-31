namespace CheckoutKataApi.Web
{
    public class PriceCalculator
    {
        public int GetPriceOf(string items)
        {
            if (items == "A")
            {
                return 50;
            }
            return 0;
        }
    }
}