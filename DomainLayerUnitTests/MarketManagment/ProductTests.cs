using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class ProductTests
    {
        Store store;
        Cart cart;
        Product product;

        [SetUp]
        public void SetUp()
        {
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            store = new Store("temp");
            cart = new Cart(store);
            product = new Product(1, "cake", "food", 10);
            store.AddProducts(product, 10);
            cart.AddProductsToCart(1, 10);
        }

        [Test]
        public void EditProduct_SuccesfulyEditProduct_ReturnsTrue()
        {
            Assert.AreEqual("cake", product.GetName());
            Assert.AreEqual("food", product.GetCategory());
            Assert.AreEqual(10, product.GetPrice());
            product.EditProduct("cheese cake", "good food", 15);
            Assert.AreEqual("cheese cake", product.GetName());
            Assert.AreEqual("good food", product.GetCategory());
            Assert.AreEqual(15, product.GetPrice());
        }

        [Test]
        public void SetDiscountMinimum_SetDiscountSuccesfully_ReturnsTrue()
        {
            LinkedList<string> policy = new LinkedList<string>();
            policy.AddLast("Ban");
            policy.AddLast("AND");
            policy.AddLast("1");
            policy.AddLast("user");
            product.AddDiscountPolicy(policy, 50);
            cart.SetSum();
            product.SetDiscountMinimum(1, cart);
            Assert.AreEqual(50, cart.GetCartSum());
        }

        [Test]
        public void CheckSellingPolicies_AllPoliciesPass_ReturnsTrue()
        {
            LinkedList<string> policy = new LinkedList<string>();
            policy.AddLast("Ban");
            policy.AddLast("AND");
            policy.AddLast("1");
            policy.AddLast("user");
            product.AddSellingPolicy(policy);
            Assert.IsTrue(product.CheckSellingPolicy(1, cart));
        }

        [Test]
        public void CheckSellingPolicies_NotAllPoliciesPass_ReturnsFalse()
        {
            LinkedList<string> policy = new LinkedList<string>();
            policy.AddLast("Ban");
            policy.AddLast("AND");
            policy.AddLast("1");
            policy.AddLast("user");
            product.AddSellingPolicy(policy);
            policy = new LinkedList<string>();
            policy.AddLast("Max");
            policy.AddLast("AND");
            policy.AddLast("1");
            policy.AddLast("0");
            policy.AddLast("2");
            product.AddSellingPolicy(policy);
            Assert.Throws<ErrorMessageException>(() => product.CheckSellingPolicy(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.MarketManagment.System.Reset();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
