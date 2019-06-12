using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class StoreTests
    {
        private Store store;
        private Product product1;
        private Product product2;
        private Cart cart;

        [SetUp]
        public void SetUp()
        {
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            store = new Store("store");
            cart = new Cart(store);
            product1 = new Product(1, "toaster", "cooking supplies", 15);
            product2 = new Product(2, "grenade", "weapon", 5);
            store.AddProducts(product1, 10);
            cart.AddProductsToCart(1, 10);
        }

        [Test]
        public void AddProducts_AddNewProducts_ReturnsTrue()
        {
            Assert.IsTrue(store.AddProducts(product2, 5));
            Assert.AreEqual(2, store.GetInventory().Count);
            Assert.AreEqual(5, store.GetInventory()[product2]);
        }

        [Test]
        public void AddProducts_AddExistingProducts_ReturnsFalse()
        {
            Assert.IsFalse(store.AddProducts(product1, 5));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(10, store.GetInventory()[product1]);
        }

        [Test]
        public void RemoveProducts_RemoveExistingProducts_ReturnsTrue()
        {
            Assert.IsTrue(store.RemoveProducts(product1, 2));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(8, store.GetInventory()[product1]);
        }

        [Test]
        public void RemoveProducts_RemoveNonExistingProducts_ReturnsFalse()
        {
            Assert.IsFalse(store.RemoveProducts(product2, 2));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(10, store.GetInventory()[product1]);
        }

        [Test]
        public void RemoveProductFromstore_RemoveExistingProducts_ReturnsTrue()
        {
            Assert.IsTrue(store.RemoveProductFromInventory(product1.GetId()));
            Assert.AreEqual(0, store.GetInventory().Count);
        }

        [Test]
        public void RemoveProductFromstore_RemoveNonExistingProducts_ReturnsFalse()
        {
            Assert.IsFalse(store.RemoveProductFromInventory(product2.GetId()));
            Assert.AreEqual(1, store.GetInventory().Count);
        }

        [Test]
        public void EditProduct_EditExistingProduct_ReturnsTrue()
        {
            Assert.IsTrue(store.EditProduct(product1.GetId(), "c", "c", 3, 30));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(30, store.GetInventory()[product1]);
        }

        [Test]
        public void EditProduct_EditNonExistingProduct_ReturnsFalse()
        {
            Assert.IsFalse(store.EditProduct(product2.GetId(), "c", "c", 3, 30));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(10, store.GetInventory()[product1]);
        }

        [Test]
        public void SetDiscountMinimum_SetDiscountSuccesfully_ReturnsTrue()
        {
            store.AddProducts(product2, 10);
            cart.AddProductsToCart(2, 10);
            store.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 20);
            store.AddDiscountPolicy(new PolicyLeafUserName("user", "=="), 90);
            store.AddDiscountPolicy(new PolicyLeafUserName("user", "!="), 50);
            cart.SetSum();
            store.SetDiscountMinimum(1, cart);
            Assert.AreEqual(100, cart.GetCartSum());
        }

        [Test]
        public void CheckSellingPolicies_AllPoliciesPass_ReturnsTrue()
        {
            store.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            store.AddSellingPolicy(new PolicyLeafUserName("user", "!="));
            Assert.IsTrue(store.CheckSellingPolicies(1, cart));
        }

        [Test]
        public void CheckSellingPolicies_NotAllPoliciesPass_ReturnsFalse()
        {
            store.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            store.AddSellingPolicy(new PolicyLeafUserName("user", "!="));
            store.AddSellingPolicy(new PolicyLeafProductAmount(product1, ">", 10));
            Assert.IsFalse(store.CheckSellingPolicies(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
