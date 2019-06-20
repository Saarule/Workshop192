using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using Workshop192;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class SystemTests
    {
        private Workshop192.MarketManagment.System system;
        private Store store1;
        private Store store2;
        private User user;
        private Product product1, product2, product3, product4;

        [SetUp]
        public void SetUp()
        {
            LinkedList<string> policy = new LinkedList<string>();
            system = Workshop192.MarketManagment.System.GetInstance();
            AllRegisteredUsers.GetInstance().CreateUser();
            user = AllRegisteredUsers.GetInstance().GetUser(1);
            system.OpenStore("store1");
            system.OpenStore("store2");
            store1 = system.GetStore("store1");
            store2 = system.GetStore("store2");
            product1 = new Product(1, "", "", 10);
            product2 = new Product(2, "", "", 20);
            product3 = new Product(3, "", "", 30);
            product4 = new Product(4, "", "", 40);
            store1.AddProducts(product1, 10);
            store1.AddProducts(product2, 10);
            store2.AddProducts(product3, 10);
            store2.AddProducts(product4, 10);
            policy.AddLast("Ban"); policy.AddLast("And"); policy.AddLast("1"); policy.AddLast("user");
            product1.AddDiscountPolicy(policy, 50);
            policy = new LinkedList<string>();
            policy.AddLast("Min"); policy.AddLast("And"); policy.AddLast("1"); policy.AddLast("0"); policy.AddLast("5");
            product1.AddSellingPolicy(policy);
            policy = new LinkedList<string>();
            policy.AddLast("Min"); policy.AddLast("And"); policy.AddLast("0"); policy.AddLast("0"); policy.AddLast("5");
            store1.AddSellingPolicy(policy);
            policy = new LinkedList<string>();
            policy.AddLast("Max"); policy.AddLast("And"); policy.AddLast("0"); policy.AddLast("0"); policy.AddLast("50");
            store1.AddSellingPolicy(policy);
        }

        [Test]
        public void CreateProduct_CreateTwoProductsWithDifferentId_ReturnsTrue()
        {
            Assert.AreNotEqual(system.CreateProduct("", "", 1).GetId(), system.CreateProduct("", "", 2).GetId());
        }

        [Test]
        public void SumOfCartPrice_ReturnsCorrectSumZero_ReturnsTrue()
        {
            Assert.AreEqual(0, system.SumOfCartPrice(1));
        }

        [Test]
        public void SumOfCartPrice_ReturnsCorrectSum_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 5);
            user.AddProductsToMultiCart("store1", 2, 5);
            user.AddProductsToMultiCart("store2", 3, 5);
            user.AddProductsToMultiCart("store2", 4, 5);
            Assert.AreEqual(475, system.SumOfCartPrice(1));
        }

        [Test]
        public void CheckSellingPolicies_AllPoliciesPass_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 7);
            user.AddProductsToMultiCart("store1", 2, 5);
            user.AddProductsToMultiCart("store2", 3, 1);
            user.AddProductsToMultiCart("store2", 4, 1);
            Assert.IsTrue(system.CheckSellingPolicies(1));
        }

        [Test]
        public void CheckSellingPolicies_NotAllPoliciesPass_ReturnsFalse()
        {
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 1);
            user.AddProductsToMultiCart("store2", 3, 1);
            user.AddProductsToMultiCart("store2", 4, 1);
            Assert.Throws<ErrorMessageException>(() => system.CheckSellingPolicies(1));
        }

        [Test]
        public void RemoveProductsFromStore_SuccesfullyRemoveProducts_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 2);
            user.AddProductsToMultiCart("store2", 3, 3);
            user.AddProductsToMultiCart("store2", 4, 4);
            system.RemoveProductsFromStore(system.GetMultiCart(user.GetMultiCart()));
            Assert.AreEqual(9, store1.GetProductAmount(product1).amount);
            Assert.AreEqual(8, store1.GetProductAmount(product2).amount);
            Assert.AreEqual(7, store2.GetProductAmount(product3).amount);
            Assert.AreEqual(6, store2.GetProductAmount(product4).amount);
        }

        [Test]
        public void ReturnProductsToStore_SuccesfullyReturnProducts_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 2);
            user.AddProductsToMultiCart("store2", 3, 3);
            user.AddProductsToMultiCart("store2", 4, 4);
            system.RemoveProductsFromStore(system.GetMultiCart(user.GetMultiCart()));
            system.ReturnProductsToStore(system.GetMultiCart(user.GetMultiCart()));
            Assert.AreEqual(10, store1.GetProductAmount(product1).amount);
            Assert.AreEqual(10, store1.GetProductAmount(product2).amount);
            Assert.AreEqual(10, store2.GetProductAmount(product3).amount);
            Assert.AreEqual(10, store2.GetProductAmount(product4).amount);
        }

        [Test]
        public void CheckProductsAvailability_AllProductsAvailable_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 2);
            user.AddProductsToMultiCart("store2", 3, 3);
            user.AddProductsToMultiCart("store2", 4, 4);
            Assert.IsTrue(system.CheckProductsAvailability(system.GetMultiCart(user.GetMultiCart())));
        }

        [Test]
        public void CheckProductsAvailability_NotAllProductsAvailable_ReturnsFalse()
        {
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 2);
            user.AddProductsToMultiCart("store2", 3, 3);
            user.AddProductsToMultiCart("store2", 4, 4);
            store1.RemoveProductFromInventory(2);
            Assert.Throws<ErrorMessageException>(() => system.CheckProductsAvailability(system.GetMultiCart(user.GetMultiCart())));
        }

        [Test]
        public void PurchaseProducts_SuccesfullPurchase_ReturnsTrue()
        {
            system.ConnectDeliverySystem(new DeliverySystemReal());
            system.ConnectMoneyCollectionSystem(new MoneyCollectionSystemReal());
            user.AddProductsToMultiCart("store1", 1, 5);
            user.AddProductsToMultiCart("store1", 2, 5);
            user.AddProductsToMultiCart("store2", 3, 5);
            user.AddProductsToMultiCart("store2", 4, 5);
            Assert.AreNotEqual(new Tuple<int, int>(-1, -1), system.PurchaseProducts(1, "", "", "", "", "", "", "", "", "", "", ""));
            Assert.AreEqual(5, store1.GetProductAmount(product1).amount);
            Assert.AreEqual(5, store1.GetProductAmount(product2).amount);
            Assert.AreEqual(5, store2.GetProductAmount(product3).amount);
            Assert.AreEqual(5, store2.GetProductAmount(product4).amount);
        }

        [Test]
        public void PurchaseProducts_CantPurchaseExternalSystemsNotConnected_ReturnsFalse()
        {
            user.AddProductsToMultiCart("store1", 1, 5);
            user.AddProductsToMultiCart("store1", 2, 5);
            user.AddProductsToMultiCart("store2", 3, 5);
            user.AddProductsToMultiCart("store2", 4, 5);
            Assert.AreEqual(-1, system.PurchaseProducts(1, "", "", "", "", "", "", "", "", "", "", "").Item1);
            Assert.AreEqual(10, store1.GetProductAmount(product1).amount);
            Assert.AreEqual(10, store1.GetProductAmount(product2).amount);
            Assert.AreEqual(10, store2.GetProductAmount(product3).amount);
            Assert.AreEqual(10, store2.GetProductAmount(product4).amount);
        }

        [TearDown]
        public void TearDown()
        {
            system = Workshop192.MarketManagment.System.Reset();
            AllRegisteredUsers.Reset();
        }
    }
}
