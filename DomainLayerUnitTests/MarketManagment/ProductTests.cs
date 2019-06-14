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
            product.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 50);
            product.AddDiscountPolicy(new PolicyLeafUserName("user", "=="), 70);
            product.AddDiscountPolicy(new PolicyLeafUserName("user", "!="), 30);
            cart.SetSum();
            product.SetDiscountMinimum(1, cart);
            Assert.AreEqual(50, cart.GetCartSum());
        }

        [Test]
        public void CheckSellingPolicies_AllPoliciesPass_ReturnsTrue()
        {
            product.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            product.AddSellingPolicy(new PolicyLeafUserName("user", "!="));
            Assert.IsTrue(product.CheckSellingPolicies(1, cart));
        }

        [Test]
        public void CheckSellingPolicies_NotAllPoliciesPass_ReturnsFalse()
        {
            product.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            product.AddSellingPolicy(new PolicyLeafUserName("user", "!="));
            product.AddSellingPolicy(new PolicyLeafProductAmount(product, ">", 10));
            Assert.Throws<ErrorMessageException>(() => product.CheckSellingPolicies(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.MarketManagment.System.Reset();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
