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
        private Workshop192.System system;
        private User user;
        private Product p1;
        private Product p2;

        [SetUp]
        public void SetUp()
        {
            system = Workshop192.System.GetInstance();
            system.Register("user1", "12345");
            system.Register("user2", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
            p1 = new Product(1, 2, "wood");
            p2 = new Product(2, 5, "stone");
            user = new User();
            user.LogIn(system.GetUser("user1", "12345"));
            user.GetState().GetOwner(system.GetStore("myStore")).AddProduct(p1);
            user.GetState().GetOwner(system.GetStore("myStore")).AddProduct(p2);
            user.AddProductToCart(p1, system.GetStore("myStore"));
        }

        [Test]
        public void AddProduct_AddNewProductToCart_ReturnsTrue()
        {
            Assert.IsTrue(user.GetCarts().First.Value.AddProduct(p2));
            Assert.AreEqual(2, user.GetCarts().First.Value.GetProducts().Count);
        }

        [Test]
        public void AddProduct_AddExistingProductToCart_ReturnsFalse()
        {
            Assert.IsFalse(user.GetCarts().First.Value.AddProduct(p1));
            Assert.AreEqual(1, user.GetCarts().First.Value.GetProducts().Count);
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.System.Reset();
        }
    }
}
