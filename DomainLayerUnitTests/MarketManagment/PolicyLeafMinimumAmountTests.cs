using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class PolicyLeafMinimumAmountTests
    {
        PolicyLeafMinimumAmount policy;
        Cart cart;

        [SetUp]
        public void SetUp()
        {
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            Store store = new Store("store");
            Product p1 = new Product(1, "1", "1", 1);
            Product p2 = new Product(2, "2", "2", 2);
            store.AddProducts(p1, 10);
            store.AddProducts(p2, 10);
            cart = new Cart(store);
            cart.AddProductsToCart(1, 10);
            cart.AddProductsToCart(2, 10);
        }

        [Test]
        public void Validate_ValidateProductCorrect_ReturnsTrue()
        {
            policy = new PolicyLeafMinimumAmount(1, 9);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateStoreCorrect_ReturnsTrue()
        {
            policy = new PolicyLeafMinimumAmount(0, 18);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateProductIncorrect_ReturnsFalse()
        {
            policy = new PolicyLeafMinimumAmount(1, 12);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateStoreIncorrect_ReturnsFalse()
        {
            policy = new PolicyLeafMinimumAmount(0, 25);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
