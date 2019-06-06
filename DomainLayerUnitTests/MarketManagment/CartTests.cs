using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class CartTests
    {
        private Cart cart;
        private Product p1;

        [SetUp]
        public void SetUp()
        {
            Store store = new Store("newStore");
            p1 = new Product(1, "air", "element", 5);
            store.AddProducts(p1, 4);
            cart = new Cart(store);
        }

        [Test]
        public void AddProductsToCart_AddNewProductToCart_ReturnsTrue()
        {
            Assert.IsTrue(cart.AddProductsToCart(p1, 3));
            Assert.AreEqual(1, cart.GetProducts().Count);
            Assert.AreEqual(3, cart.GetProducts()[p1]);
        }

        [Test]
        public void AddProductsToCart_AddExistingProductToCart_ReturnsTrue()
        {
            cart.AddProductsToCart(p1, 2);
            Assert.IsTrue(cart.AddProductsToCart(p1, 1));
            Assert.AreEqual(1, cart.GetProducts().Count);
            Assert.AreEqual(3, cart.GetProducts()[p1]);
        }

        [Test]
        public void AddProductsToCart_AddProductToCartOverAmount_ReturnsFalse()
        {
            Assert.IsFalse(cart.AddProductsToCart(p1, 5));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }

        [Test]
        public void RemoveProduct_RemoveExistingProductFromCart_ReturnsTrue()
        {
            cart.AddProductsToCart(p1, 3);
            Assert.IsTrue(cart.RemoveProduct(p1));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }

        [Test]
        public void RemoveProduct_RemoveNonExistingProductFromCart_ReturnsFalse()
        {
            Assert.IsFalse(cart.RemoveProduct(p1));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }

        [Test]
        public void SetSum_SuccesfulySetsTheFullPriceOfAllProducts_ReturnsTrue()
        {
            cart.AddProductsToCart(p1, 2);
            cart.SetSum();
            Assert.AreEqual(10, cart.GetCartSum());
            cart.AddProductsToCart(p1, 2);
            cart.SetSum();
            Assert.AreEqual(20, cart.GetCartSum());
        }
    }
}
