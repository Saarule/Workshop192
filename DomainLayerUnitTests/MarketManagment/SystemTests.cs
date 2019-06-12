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
            product1.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 50);
            product1.AddDiscountPolicy(new PolicyLeafUserName("user", "!="), 30);
            product2.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 70);
            product1.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            product1.AddSellingPolicy(new PolicyLeafProductAmount(product1, ">", 1));
            product2.AddSellingPolicy(new PolicyLeafUserName("user", "!="));
            store1.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 50);
            store1.AddDiscountPolicy(new PolicyLeafProductAmount(null, ">=", 10), 70);
            store1.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            store1.AddSellingPolicy(new PolicyLeafProductAmount(null, ">=", 3));
            product3.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 30);
            product4.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 80);
            product3.AddSellingPolicy(new PolicyLeafUserName("", "=="));
            store2.AddDiscountPolicy(new PolicyLeafUserName("", "=="), 30);
            store2.AddSellingPolicy(new PolicyLeafUserName("", "=="));
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
            Assert.AreEqual(235, system.SumOfCartPrice(1));
        }

        [Test]
        public void CheckSellingPolicies_AllPoliciesPass_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 2);
            user.AddProductsToMultiCart("store1", 2, 1);
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
            Assert.IsFalse(system.CheckSellingPolicies(1));
        }

        [Test]
        public void RemoveProductsFromStore_SuccesfullyRemoveProducts_ReturnsTrue()
        {
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 2);
            user.AddProductsToMultiCart("store2", 3, 3);
            user.AddProductsToMultiCart("store2", 4, 4);
            system.RemoveProductsFromStore(system.GetMultiCart(user.GetMultiCart()));
            Assert.AreEqual(9, store1.GetInventory()[product1]);
            Assert.AreEqual(8, store1.GetInventory()[product2]);
            Assert.AreEqual(7, store2.GetInventory()[product3]);
            Assert.AreEqual(6, store2.GetInventory()[product4]);
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
            Assert.AreEqual(10, store1.GetInventory()[product1]);
            Assert.AreEqual(10, store1.GetInventory()[product2]);
            Assert.AreEqual(10, store2.GetInventory()[product3]);
            Assert.AreEqual(10, store2.GetInventory()[product4]);
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
            Assert.IsFalse(system.CheckProductsAvailability(system.GetMultiCart(user.GetMultiCart())));
        }

        [Test]
        public void PurchaseProducts_SuccesfullPurchase_ReturnsTrue()
        {
            system.ConnectDeliverySystem(new Workshop192.DeliverySystemReal());
            system.ConnectMoneyCollectionSystem(new Workshop192.MoneyCollectionSystemReal());
            user.AddProductsToMultiCart("store1", 1, 5);
            user.AddProductsToMultiCart("store1", 2, 5);
            user.AddProductsToMultiCart("store2", 3, 5);
            user.AddProductsToMultiCart("store2", 4, 5);
            Assert.IsTrue(system.PurchaseProducts(1, 1, "Ben", "Here"));
        }

        [Test]
        public void PurchaseProducts_CantPurchaseExternalSystemsNotConnected_ReturnsFalse()
        {
            user.AddProductsToMultiCart("store1", 1, 5);
            user.AddProductsToMultiCart("store1", 2, 5);
            user.AddProductsToMultiCart("store2", 3, 5);
            user.AddProductsToMultiCart("store2", 4, 5);
            Assert.IsFalse(system.PurchaseProducts(1, 1, "Ben", "Here"));
        }

        [TearDown]
        public void TearDown()
        {
            system = Workshop192.MarketManagment.System.Reset();
            AllRegisteredUsers.Reset();
        }
    }
}
