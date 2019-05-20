using System;
using NUnit.Framework;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests
{
    
    [TestFixture]
    public class SystemTests
    {
        private Workshop192.System system;
        private User user;

        [SetUp]
        public void Init()
        {
            system = Workshop192.System.GetInstance();
            system.Register("user1", "12345");
            system.Register("user2", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
            Product p1 = new Product(1, 2, "wood");
            Product p2 = new Product(2, 5, "stone");
            Product p3 = new Product(3, 7, "dirt");
            user = new User();
            user.LogIn(system.GetUser("user1", "12345"));
            user.GetState().GetOwner(system.GetStore("myStore")).AddProduct(p1);
            user.GetState().GetOwner(system.GetStore("myStore")).AddProduct(p2);
            user.GetState().GetOwner(system.GetStore("myStore")).AddProduct(p3);
            user.AddProductToCart(p1, system.GetStore("myStore"));
            user.AddProductToCart(p2, system.GetStore("myStore"));
        }

        [Test]
        public void AddStore_ToUser_ReturnsTrue()
        {
            Assert.AreEqual("myStore", system.GetUser("user1", "12345").GetStoreOwners().Last.Value.GetStore().GetName());
        }

        [Test]
        public void AddStore_StoreCountIncresedByOne_ReturnTrue()
        {
            Assert.IsTrue(system.GetUser("user1", "12345").GetStoreOwners().Count == 1);
        }

        [Test]
        public void AddStore_StoreWithAlreadyExistName_ReturnsFalse()
        {
            system.OpenStore("myStore", system.GetUser("user2", "12345")); 
            Assert.IsFalse(system.GetUser("user2", "12345").GetStoreOwners().Count == 1);
        }

        [Test]
        public void RemoveStore_StoreCountDecreasedByOne_ReturnsTrue()
        {
            UserState userState = system.GetUser("user1", "12345");
            system.CloseStore(system.GetStore("myStore"), userState);
            Assert.IsTrue(system.GetUser("user1", "12345").GetStoreOwners().Count == 0);
        }

        [Test]
        public void RemoveStore_StoreRemovedIfTheUserHadOne_ReturnsNull()
        {
            system.RemoveUser(system.GetUser("user1", "12345"));
            Assert.IsNull(system.GetUser("user1", "12345"));
            Assert.IsNull(system.GetStore("myStore"));
        }

        [Test]
        public void RemoveUser_IsUserDeletedFromSystem_ReturnsNull()
        {
            system.RemoveUser(system.GetUser("user2", "12345"));
            Assert.IsNull(system.GetUser("user2", "12345"));
        }

        [Test]
        public void GetStore_CheckStoreObjectNameValidity_AreEqual()
        {
            Assert.AreEqual("myStore", system.GetStore("myStore").GetName());
        }

        [Test]
        public void OpenStore_StoreAddedToStoreList_ReturnsTrue()
        {
            Assert.IsTrue(system.GetStore("myStore") != null);
        }

        [Test]
        public void OpenStore_StoreCountIncresedByOne_ReturnsTrue()
        {
            Assert.AreEqual(1, system.GetAllStores().Count);
            system.OpenStore("myStore2", system.GetUser("user2", "12345"));
            Assert.AreEqual(2, system.GetAllStores().Count);
        }

        [Test]
        public void Register_UserAddedToSystem_ReturnsTrue()
        {
            Assert.IsTrue(system.Register("user3", "12345"));
        }

        [Test]
        public void Register_AddUserToSystemWhenUserAlreadyExist_ReturnsFalse()
        {
            Assert.IsFalse(system.Register("user2", "12345"));
        }

        [Test]
        public void SumOfCartPrice_SumOfProductsInCartIsCorrect_AreEqual()
        {
            Assert.AreEqual(7, system.SumOfCartPrice(user.GetCarts()));
        }

        [Test]
        public void CheckProductsAvailability_ProductRemovedFromStoreAfterCheckout_ReturnTrue()
        {
            Assert.IsTrue(system.CheckProductsavailability(user.GetCarts()));
            Assert.AreEqual(1, system.GetStore("myStore").GetProducts().Count);
        }

        [Test]
        public void CheckProductsAvailability_ProductNoLongerAvailable_ReturnsFalse()
        {
            Product p4 = new Product(4, 9, "stuff");
            User user2 = new User();
            user2.LogIn(system.GetUser("user2", "12345"));
            user.GetState().GetOwner(system.GetStore("myStore")).AddProduct(p4);
            user.AddProductToCart(p4, system.GetStore("myStore"));
            user2.AddProductToCart(p4, system.GetStore("myStore"));
            Assert.IsTrue(system.CheckProductsavailability(user2.GetCarts()));
            Assert.IsFalse(system.CheckProductsavailability(user.GetCarts()));
            Assert.AreEqual(3, system.GetStore("myStore").GetProducts().Count);
        }

        [Test]
        public void PurchaseProduct_CartIsReset_ReturnsTrue()
        {
            system.PurchaseProducts(0, user, "myName", "myAddress");
            Assert.IsTrue(user.GetCarts().Count == 0);
        }

        [TearDown]
        public void Dispose()
        {
            Workshop192.System.Reset();
        }
    }
}