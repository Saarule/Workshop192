using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void AddStore()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.AddUser("user1", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
            Assert.AreEqual("myStore", system.GetUser("user1", "12345").GetStores().Last.Value.GetStore().GetName());
            Assert.IsTrue(system.GetUser("user1", "12345").GetStores().Count == 1);
            system = null;
        }

        [TestMethod]
        public void RemoveStore()
        {
            Workshop192.System system2 = Workshop192.System.GetInstance();
            system2.AddUser("user1", "12345");
            system2.OpenStore("myStore", system2.GetUser("user1", "12345"));
            Assert.AreEqual("myStore", system2.GetUser("user1", "12345").GetStores().Last.Value.GetStore().GetName());
            Assert.IsTrue(system2.GetUser("user1", "12345").GetStores().Count == 1);
           // system2.



        }

        [TestMethod]
        public void AddCart()
        {
        }
        [TestMethod]
        public void RemoveCart()
        {
        }

    }
}
