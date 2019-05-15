using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace UnitTestProject1
{
    [TestClass]
    public class StoreOwnerTests
    {
        [TestMethod]
        public void AddOwner()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.AddUser("user1", "12345");
            system.AddUser("user2", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
            User user = system.GetUser("user1", "12345");
            StoreOwner storeOwner = user.GetStoreOwners().First.Value;
            User user2 = system.GetUser("user2", "12345");
            storeOwner.AddOwner(user2);
            Assert.IsTrue(storeOwner.GetChildren().Count == 1);
            system = Workshop192.System.Reset();
        }

        [TestMethod]
        public void AddManager()
        {
            Workshop192.System system2 = Workshop192.System.GetInstance();
            system2.AddUser("user1", "12345");
            system2.AddUser("user2", "12345");
            system2.OpenStore("myStore", system2.GetUser("user1", "12345"));
            User user = system2.GetUser("user1", "12345");
            StoreOwner storeOwner = user.GetStoreOwners().First.Value;
            User user2 = system2.GetUser("user2", "12345");
            storeOwner.AddManager(user2,null);
            Assert.IsTrue(storeOwner.GetChildren().Count == 1);
            system2 = Workshop192.System.Reset();
        }

        [TestMethod]
        public void RemoveChild()
        {
        }
    }
}
