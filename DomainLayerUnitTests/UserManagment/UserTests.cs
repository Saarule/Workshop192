using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class UserTests
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
            user.LogOut();
        }

        [Test]
        public void LogIn_UserNotLoggedIn_ReturnTrue()
        {
            Assert.IsTrue(user.LogIn(system.GetUser("user1", "12345")));
        }

        [Test]
        public void LogIn_UserIsAlreadyLoggedIn_ReturnsFalse()
        {
            User user2 = new User();
            user2.LogIn(system.GetUser("user2", "12345"));
            Assert.IsFalse(user2.LogIn(system.GetUser("user2", "12345")));
        }

        [Test]
        public void LogOut_UserNotLoggedIn_ReturnFalse()
        {
            User user3 = new User();
            Assert.IsFalse(user3.LogOut());
        }
        [Test]
        public void LogOut_UserIsLoggedIn_ReturnsTrue()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsTrue(user.LogOut());
        }

        [Test]
        public void SetAdmin_IsAlreadyAdmin_ReturnsFalse()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsTrue(user.SetAdmin());
            Assert.IsFalse(user.SetAdmin());
        }

        [Test]
        public void SetAdmin_UserIsNotAdmin_ReturnTrue()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsTrue(user.SetAdmin());
        }

        [Test]
        public void SetAdmin_UserIsNotLoggedIn_ReturnsFalse()
        {
            Assert.IsFalse(user.SetAdmin());
        }

        [Test]
        public void AddStoreOwner_UserIsNotStoreOwnerHimself_ReturnsFalse()
        {
            User user2 = new User();
            system.Register("user3", "12345");
            user2.AddStoreOwner(system.GetStore("myStore"), system.GetUser("user3", "12345"));
            Assert.IsFalse(user2.AddStoreOwner(system.GetStore("myStore"), system.GetUser("user3", "12345")));
        }

        [Test]
        public void AddStoreOwner_TheUserYouAreAddingIsAlreadyStoreOwner_ReturnFalse()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsFalse(user.AddStoreOwner(system.GetStore("myStore"), system.GetUser("user1", "12345")));
        }

        [Test]
        public void AddStoreOwner_MakeUserAStoreOwner_ReturnsTrue()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsTrue(user.AddStoreOwner(system.GetStore("myStore"), system.GetUser("user2", "12345")));
        }

        [Test]
        public void AddStoreManager_NewStoreManager_ReturnsTrue()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsTrue(user.AddStoreManager(system.GetStore("myStore"), system.GetUser("user2", "12345"), new bool[6]));
        }

        [Test]
        public void RemoveStoreOwner_StoreOwnerIsChild_ReturnsTrue()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            user.AddStoreOwner(system.GetStore("myStore"), system.GetUser("user2", "12345"));
            Assert.IsTrue(user.RemoveStoreOwner(system.GetStore("myStore"), system.GetUser("user2", "12345")));
        }

        [Test]
        public void RemoveStoreOwner_StoreOwnerIsNotChild_ReturnsFalse()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            user.AddStoreOwner(system.GetStore("myStore"), system.GetUser("user2", "12345"));
            Assert.IsFalse(system.GetUser("user2", "12345").RemoveStoreOwner(system.GetStore("myStore"), user.GetState()));
        }

        [Test]
        public void RemoveStoreOwner_UserToRemoveIsNotStoreOwner_ReturnsFalse()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsFalse(system.GetUser("user2", "12345").RemoveStoreOwner(system.GetStore("myStore"), user.GetState()));
        }

        [Test]
        public void RemoveStoreOwner_UserIsNotStoreOwner_ReturnsFalse()
        {
            user.LogIn(system.GetUser("user2", "12345"));
            Assert.IsFalse(system.GetUser("user1", "12345").RemoveStoreOwner(system.GetStore("myStore"), user.GetState()));
        }

        [Test]
        public void AddProductToCart_AddNewProduct_ReturnsTrue()
        {
            Assert.IsTrue(user.AddProductToCart(system.GetStore("myStore").GetProducts().First.Value, system.GetStore("myStore")));
            Assert.AreEqual(1, user.GetCarts().First.Value.GetProducts().Count);
        }

        [Test]
        public void AddProductToCart_AddExistingProduct_ReturnsFalse()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsFalse(user.AddProductToCart(system.GetStore("myStore").GetProducts().First.Value, system.GetStore("myStore")));
            Assert.AreEqual(2, user.GetCarts().First.Value.GetProducts().Count);
        }

        [Test]
        public void RemoveProductFromCart_RemoveExistingProduct_ReturnsTrue()
        {
            user.LogIn(system.GetUser("user1", "12345"));
            Assert.IsTrue(user.RemoveProductFromCart(system.GetStore("myStore").GetProducts().First.Value));
            Assert.AreEqual(1, user.GetCarts().First.Value.GetProducts().Count);
        }

        [Test]
        public void RemoveProductFromCart_RemoveNotExistingProduct_ReturnsFalse()
        {
            Assert.IsFalse(user.RemoveProductFromCart(system.GetStore("myStore").GetProducts().First.Value));
            Assert.AreEqual(0, user.GetCarts().Count);
        }

        [TearDown]
        public void Dispose()
        {
            Workshop192.System.Reset();
        }
    }
}
