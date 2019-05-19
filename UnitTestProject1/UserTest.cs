using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace UnitTestProject1
{
    
    
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void AddStore()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.Register("user1", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
            Assert.AreEqual("myStore", system.GetUser("user1", "12345").GetStoreOwners().Last.Value.GetStore().GetName());
           // Assert.IsTrue(system.GetUser("user1", "12345").GetStoreOwners().Count == 1);
            system = Workshop192.System.Reset();
        }

        [TestMethod]
        public void RemoveStore()
        {
            Workshop192.System system2 = Workshop192.System.GetInstance();
            system2.Register("user1", "12345");
            system2.OpenStore("myStore", system2.GetUser("user1", "12345"));
            Assert.AreEqual("myStore", system2.GetUser("user1", "12345").GetStoreOwners().Last.Value.GetStore().GetName());
            Assert.AreEqual(system2.GetUser("user1", "12345").GetStoreOwners().Count , 1 );
            system2.CloseStore(system2.GetUser("user1", "12345").GetStoreOwners().First.Value.GetStore());
            Assert.AreEqual(system2.GetUser("user1", "12345").GetStoreOwners().Count , 0);
            system2 = Workshop192.System.Reset();



        }

        [TestMethod]
        public void AddCart()
        {
            Workshop192.System system3 = Workshop192.System.GetInstance();
            system3.Register("user1", "12345");
            system3.OpenStore("myStore", system3.GetUser("user1", "12345"));
            User user1 = system3.GetUser("user1", "12345");
            StoreOwner storeOwner = user1.GetStoreOwners().First.Value;

            Product product1 = new Workshop192.MarketManagment.Product(1, 100, "product");
            storeOwner.AddProduct(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);

            system3.Register("user2", "12345");
            system3.OpenStore("myStore", system3.GetUser("user2", "12345"));
            User user2 = system3.GetUser("user2", "12345");
            system3 = Workshop192.System.Reset();

            
            
            
            

    }
}
