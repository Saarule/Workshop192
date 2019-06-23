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
    class StoreTests
    {
        private Store store;
        private Product product1;
        private Product product2;
        private Cart cart;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            store = new Store("store");
            cart = new Cart(store, new MultiCart(1));
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
            Assert.AreEqual(5, store.GetProductAmount(product2).amount);
        }

        [Test]
        public void AddProducts_AddExistingProducts_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => store.AddProducts(product1, 5));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(10, store.GetProductAmount(product1).amount);
        }

        [Test]
        public void RemoveProducts_RemoveExistingProducts_ReturnsTrue()
        {
            Assert.IsTrue(store.RemoveProducts(product1, 2));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(8, store.GetProductAmount(product1).amount);
        }

        [Test]
        public void RemoveProducts_RemoveNonExistingProducts_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => store.RemoveProducts(product2, 2));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(10, store.GetProductAmount(product1).amount);
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
            Assert.Throws<ErrorMessageException>(() => store.RemoveProductFromInventory(product2.GetId()));
            Assert.AreEqual(1, store.GetInventory().Count);
        }

        [Test]
        public void EditProduct_EditExistingProduct_ReturnsTrue()
        {
            Assert.IsTrue(store.EditProduct(product1.GetId(), "c", "c", 3, 30));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(30, store.GetProductAmount(product1).amount);
        }

        [Test]
        public void EditProduct_EditNonExistingProduct_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => store.EditProduct(product2.GetId(), "c", "c", 3, 30));
            Assert.AreEqual(1, store.GetInventory().Count);
            Assert.AreEqual(10, store.GetProductAmount(product1).amount);
        }

        [Test]
        public void SetDiscountMinimum_SetDiscountSuccesfully_ReturnsTrue()
        {
            LinkedList<string> discountPolicy = new LinkedList<string>();
            discountPolicy.AddLast("Ban");
            discountPolicy.AddLast("And");
            discountPolicy.AddLast("0");
            discountPolicy.AddLast("user");
            store.AddProducts(product2, 10);
            cart.AddProductsToCart(2, 10);
            store.AddDiscountPolicy(discountPolicy, 50);
            cart.SetSum();
            store.SetDiscountMinimum(1, cart);
            Assert.AreEqual(100, cart.GetCartSum());
        }

        [Test]
        public void CheckSellingPolicies_AllPoliciesPass_ReturnsTrue()
        {
            LinkedList<string> sellingPolicy = new LinkedList<string>();
            sellingPolicy.AddLast("Ban");
            sellingPolicy.AddLast("And");
            sellingPolicy.AddLast("0");
            sellingPolicy.AddLast("user");
            store.AddSellingPolicy(sellingPolicy);
            Assert.IsTrue(store.CheckSellingPolicy(1, cart));
        }

        [Test]
        public void CheckSellingPolicies_NotAllPoliciesPass_ReturnsFalse()
        {
            LinkedList<string> sellingPolicy = new LinkedList<string>();
            sellingPolicy.AddLast("Ban");
            sellingPolicy.AddLast("And");
            sellingPolicy.AddLast("0");
            sellingPolicy.AddLast("");
            store.AddSellingPolicy(sellingPolicy);
            Assert.Throws<ErrorMessageException>(() => store.CheckSellingPolicy(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().StartTests();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
