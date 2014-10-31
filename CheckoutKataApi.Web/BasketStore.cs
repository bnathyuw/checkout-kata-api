using System.Collections.Generic;
using System.Linq;

namespace CheckoutKataApi.Web
{
    public class BasketStore
    {
        private static int _currentBasketId;
        private static Dictionary <int,Basket> _baskets = new Dictionary<int, Basket>();

        public int Add(Basket basket)
        {
            var basketId = ++_currentBasketId;
            _baskets.Add(basketId, basket);
            return basketId;
        }

        public Basket Get(int basketId)
        {
            return _baskets[basketId];
        }
    }
}