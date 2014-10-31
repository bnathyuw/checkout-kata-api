using CheckoutKataApi.Web;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
    [TestFixture]

    public class BasketStoreTests
    {
         [Test]
         public void Should_return_valid_basket_id()
         {
             var basket = new Basket();
             var basketStore = new BasketStore();
             var basketId = basketStore.Add(basket);
             Assert.That(basketId, Is.GreaterThan(0));
         }

        [Test]
        public void Should_return_unique_basket_ids_for_each_basket()
        {
            var basketStore = new BasketStore();
            var basketId1 = basketStore.Add(new Basket());
            var basketId2 = basketStore.Add(new Basket());
            Assert.That(basketId1, Is.Not.EqualTo(basketId2));
        }

        [Test]
        public void Should_return_unique_basketIds_between_basket_stores()
        {
            var basketStore1 = new BasketStore();
            var basketStore2 = new BasketStore();
            var basketId1 = basketStore1.Add(new Basket());
            var basketId2 = basketStore2.Add(new Basket());
            Assert.That(basketId1, Is.Not.EqualTo(basketId2));
        }

        [Test]
        public void Should_return_a_basket_given_a_basket_id()
        {
            var basketStore = new BasketStore();
            var basket = new Basket();
            var basketId = basketStore.Add(basket);
            Assert.That(basketStore.Get(basketId), Is.EqualTo(basket));
        }

        [Test]
        public void Should_retrieve_correct_basket()
        {
            var basketStore = new BasketStore();
            basketStore.Add(new Basket());
            var basket2 = new Basket();
            var basketId2 = basketStore.Add(basket2);
            basketStore.Add(new Basket());
            Assert.That(basketStore.Get(basketId2), Is.EqualTo(basket2));
        }

        [Test]
        public void Should_return_existing_basket_from_new_basketstore()
        {
            var basketStore = new BasketStore();
            var basket = new Basket();
            var basketId = basketStore.Add(basket);
            var basketStore2 = new BasketStore();
            Assert.That(basketStore2.Get(basketId), Is.EqualTo(basket));
        }
    }
}