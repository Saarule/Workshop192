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
            p1 = new Product(1, 2, "wood");
            cart = new Cart(new Store("tempStore"));
        }

        [Test]
        public void AddProduct_AddNewProductToCart_ReturnsTrue()
        {
            Assert.IsTrue(cart.AddProduct(p1));
            Assert.AreEqual(1, cart.GetProducts().Count);
        }

        [Test]
        public void AddProduct_AddExistingProductToCart_ReturnsFalse()
        {
            Assert.IsTrue(cart.AddProduct(p1));
            Assert.IsFalse(cart.AddProduct(p1));
            Assert.AreEqual(1, cart.GetProducts().Count);
        }
    }
}
