using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class UserStateTests
    {
        UserInfo state;
        UserInfo state2;
        UserInfo state3;
        Store store;
        StoreOwner owner;
        StoreOwner owner2;

        [SetUp]
        public void SetUp()
        {
            state = new UserInfo("me");
            state2 = new UserInfo("him");
            state3 = new UserInfo("her");
            store = new Store("newStore");
            owner = new StoreOwner(state, store, null);
            state.GetStoreOwners().AddFirst(owner);
            owner2 = new StoreOwner(state2, store, owner);
            state.GetStoreOwners().First.Value.GetAppointedOwners().AddFirst(owner2);
            state2.GetStoreOwners().AddFirst(owner2);
        }

        [Test]
        public void SetAdmin_NotAdmin_ReturnsTrue()
        {
            Assert.IsTrue(state.SetAdmin());
            Assert.IsTrue(state.GetAdmin());
        }

        [Test]
        public void SetAdmin_AllreadyAdmin_ReturnsFalse()
        {
            Assert.IsTrue(state.SetAdmin());
            Assert.IsFalse(state.SetAdmin());
        }

        [Test]
        public void AddStoreOwner_AddNewStoreOwner_ReturnsTrue()
        {
            Assert.IsTrue(state.AddStoreOwner(store, state3));
            Assert.AreEqual(2, owner.GetAppointedOwners().Count);
        }

        [Test]
        public void AddStoreOwner_AddExistingStoreOwner_ReturnsFalse()
        {
            Assert.IsFalse(state.AddStoreOwner(store, state2));
            Assert.AreEqual(1, owner.GetAppointedOwners().Count);
        }

        [Test]
        public void AddStoreOwner_UserStateIsNotStoreOwner_ReturnsFalse()
        {
            Assert.IsFalse(state3.AddStoreOwner(store, state2));
        }

        [Test]
        public void AddStoreManager_AddNewStoreManager_ReturnsTrue()
        {
            Assert.IsTrue(state.AddStoreManager(store, state3, new bool[6]));
            Assert.AreEqual(2, owner.GetAppointedOwners().Count);
        }

        [Test]
        public void AddStoreManager_AddExistingStoreManager_ReturnsFalse()
        {
            Assert.IsFalse(state.AddStoreManager(store, state2, new bool[6]));
            Assert.AreEqual(1, owner.GetAppointedOwners().Count);
        }

        [Test]
        public void RemoveStoreOwner_RemoveExistingStoreOwner_ReturnsTrue()
        {
            Assert.IsTrue(state.RemoveStoreOwner(store, state2));
            Assert.AreEqual(0, owner.GetAppointedOwners().Count);
        }

        [Test]
        public void RemoveStoreOwner_RemoveNonExistingStoreOwner_ReturnsFalse()
        {
            Assert.IsFalse(state.RemoveStoreOwner(store, state3));
            Assert.AreEqual(1, owner.GetAppointedOwners().Count);
        }
    }
}
