using System.Linq;

namespace CheckoutKataApi.Web
{
    public class BasketItems
    {
        private readonly string _items;

        public BasketItems(string items)
        {
            _items = items;
        }

        public int ItemCount(char itemCode)
        {
            return _items.Count(item => item == itemCode);
        }
    }

    public class PriceCalculator
    {
        public int GetPriceOf(BasketItems basketItems)
        {
            var itemACount = basketItems.ItemCount('A');
            var itemBCount = basketItems.ItemCount('B');
            var itemCCount = basketItems.ItemCount('C');
            var itemDCount = basketItems.ItemCount('D');
            
            return itemACount*50 - (itemACount/3)*20 +
                   itemBCount*30 - (itemBCount/2)*15 +
                   itemCCount*20 +
                   itemDCount*15;
        }
    }
}