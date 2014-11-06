using System.Collections.Generic;
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

    public class Discount
    {
        private readonly int _groupSize;
        private readonly int _discountPerGroup;
        private readonly char _itemCode;

        public Discount(int groupSize, int discountPerGroup, char itemCode)
        {
            _groupSize = groupSize;
            _discountPerGroup = discountPerGroup;
            _itemCode = itemCode;
        }

        public int DiscountOnItems(BasketItems basketItems)
        {
            return (basketItems.ItemCount(_itemCode)/ _groupSize) * _discountPerGroup;
        }
    }

    public class FullPrice
    {
        private readonly int _pricePerItem;
        private readonly char _itemCode;

        public FullPrice(int pricePerItem, char itemCode)
        {
            _pricePerItem = pricePerItem;
            _itemCode = itemCode;
        }

        public int PriceOfItems(BasketItems basketItems)
        {
            return basketItems.ItemCount(_itemCode) * _pricePerItem;
        }
    }

    public class PriceCalculator
    {
        private readonly List<FullPrice> _fullPrices;
        private readonly List<Discount> _discountPrices;

        public PriceCalculator()
        {
            _fullPrices = new List<FullPrice>
                {
                    new FullPrice(50, 'A'),
                    new FullPrice(30, 'B'),
                    new FullPrice(20, 'C'),
                    new FullPrice(15, 'D')
                };

            _discountPrices = new List<Discount>
                {
                    new Discount(3, 20, 'A'), 
                    new Discount(2, 15, 'B')
                };
        }

        public int GetPriceOf(BasketItems basketItems)
        {
            return _fullPrices.Sum(price => price.PriceOfItems(basketItems))
                   - _discountPrices.Sum(price => price.DiscountOnItems(basketItems));
        }
    }
}