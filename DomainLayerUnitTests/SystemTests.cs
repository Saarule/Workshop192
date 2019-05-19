using System;
using NUnit.Framework;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests
{
    
    [TestFixture]
    public class SuccessTests
    {
        private Workshop192.System system;

        [OneTimeSetUp]
        public void Init()
        {
            system = Workshop192.System.GetInstance();
            system.Register("user1", "12345");
            system.Register("user2", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));  
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
            //TODO Check store is removed properly
        }
        
        [OneTimeTearDown]
        public void Dispose()
        {
            Workshop192.System.Reset();
        }
    }
}