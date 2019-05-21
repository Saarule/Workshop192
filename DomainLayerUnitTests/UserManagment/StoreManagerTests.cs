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
    class StoreManagerTests
    {
        private UserState state;
        private UserState stateT;
        private UserState stateF;
        private StoreOwner owner;
        private Store store;
        Product product;

        [SetUp]
        public void SetUp()
        {
            state = new UserState("Ben");
            stateT = new UserState("Saar");
            stateF = new UserState("Orel");
            store = new Store("newStore");
            owner = new StoreOwner(state, store, null);
            state.GetStoreOwners().AddLast(owner);
            bool[] t = { true, true, true, true, true, true };
            bool[] f = { false, false, false, false, false, false };
            owner.AddManager(stateT, t);
            owner.AddManager(stateF, f);
            product = new Product(1, 1, "air");
        }

        [Test]
        public void AddProduct_HasPrivilege_ReturnsTrue()
        {
            Assert.IsTrue(stateT.GetOwner(store).AddProduct(product));
        }

        [Test]
        public void AddProduct_DoesntHavePrivilege_ReturnsFalse()
        {
            Assert.IsFalse(stateF.GetOwner(store).AddProduct(product));
        }

        [Test]
        public void RemoveProduct_HasPrivilege_ReturnsTrue()
        {
            owner.AddProduct(product);
            Assert.IsTrue(stateT.GetOwner(store).RemoveProduct(product));
        }

        [Test]
        public void RemoveProduct_DoesntHavePrivilege_ReturnsFalse()
        {
            owner.AddProduct(product);
            Assert.IsFalse(stateF.GetOwner(store).RemoveProduct(product));
        }

        [Test]
        public void EditProduct_HasPrivilege_ReturnsTrue()
        {
            owner.AddProduct(product);
            Assert.IsTrue(stateT.GetOwner(store).EditProduct(product, new Product(2, 2, "temp")));
        }

        [Test]
        public void EditProduct_DoesntHavePrivilege_ReturnsFalse()
        {
            owner.AddProduct(product);
            Assert.IsFalse(stateF.GetOwner(store).EditProduct(product, new Product(2, 2, "temp")));
        }

        [Test]
        public void AddOwner_HasPrivilege_ReturnsTrue()
        {
            Assert.IsTrue(stateT.GetOwner(store).AddOwner(new UserState("temp")));
        }

        [Test]
        public void AddOwner_DoesntHavePrivilege_ReturnsFalse()
        {
            Assert.IsFalse(stateF.GetOwner(store).AddOwner(new UserState("temp")));
        }

        [Test]
        public void AddManager_HasPrivilege_ReturnsTrue()
        {
            Assert.IsTrue(stateT.GetOwner(store).AddManager(new UserState("temp"), new bool[6]));
        }

        [Test]
        public void AddManager_DoesntHavePrivilege_ReturnsFalse()
        {
            Assert.IsFalse(stateF.GetOwner(store).AddManager(new UserState("temp"), new bool[6]));
        }

        [Test]
        public void RemoveChild_HasPrivilege_ReturnsTrue()
        {
            UserState temp = new UserState("temp");
            stateT.GetOwner(store).AddOwner(temp);
            Assert.IsTrue(stateT.GetOwner(store).RemoveChild(temp.GetOwner(store)));
        }

        [Test]
        public void RemoveChild_DoesntHavePrivilege_ReturnsFalse()
        {
            UserState temp = new UserState("temp");
            stateF.GetOwner(store).AddOwner(temp);
            Assert.IsFalse(stateF.GetOwner(store).RemoveChild(temp.GetOwner(store)));
        }
    }
}
