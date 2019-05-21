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
    class StoreOwnerTests
    {
        private UserState state;
        private UserState state2;
        private StoreOwner owner;
        private Store store;
        Product product;

        [SetUp]
        public void SetUp()
        {
            state = new UserState("Ben");
            state2 = new UserState("Saar");
            store = new Store("newStore");
            owner = new StoreOwner(state, store, null);
            state.GetStoreOwners().AddLast(owner);
            product = new Product(1, 1, "air");
        }

        [Test]
        public void AddProduct_AddNewProduct_ReturnsTrue()
        {
            
            Assert.IsTrue(owner.AddProduct(product));
            Assert.AreEqual(1, store.GetProducts().Count);
        }

        [Test]
        public void AddProduct_AddExistingProduct_ReturnsFalse()
        {
            owner.AddProduct(product);
            Assert.IsFalse(owner.AddProduct(product));
            Assert.AreEqual(1, store.GetProducts().Count);
        }

        [Test]
        public void RemoveProduct_RemoveExistingProduct_ReturnsTrue()
        {
            owner.AddProduct(product);
            Assert.IsTrue(owner.RemoveProduct(product));
            Assert.AreEqual(0, store.GetProducts().Count);
        }

        [Test]
        public void RemoveProduct_RemoveNonExistingProduct_ReturnsFalse()
        {
            owner.AddProduct(product);
            Assert.IsFalse(owner.RemoveProduct(new Product(2, 2, "temp")));
            Assert.AreEqual(1, store.GetProducts().Count);
        }

        [Test]
        public void EditProduct_EditExistingProduct_ReturnsTrue()
        {
            owner.AddProduct(product);
            Product p = new Product(2, 2, "temp");
            Assert.IsTrue(owner.EditProduct(product, p));
            Assert.AreEqual(1, store.GetProducts().Count);
            Assert.IsTrue(store.GetProducts().Contains(p));
        }

        [Test]
        public void EditProduct_EditNonExistingProduct_ReturnsFalse()
        {
            owner.AddProduct(product);
            Product p = new Product(2, 2, "temp");
            Assert.IsFalse(owner.EditProduct(p, product));
            Assert.AreEqual(1, store.GetProducts().Count);
            Assert.IsTrue(store.GetProducts().Contains(product));
        }

        [Test]
        public void AddOwner_AddNewOwner_ReturnsTrue()
        {
            Assert.IsTrue(owner.AddOwner(state2));
            Assert.AreEqual(1, owner.GetChildren().Count);
            Assert.AreEqual(1, state2.GetStoreOwners().Count);
        }

        [Test]
        public void AddOwner_AddExistingOwner_ReturnsFalse()
        {
            owner.AddOwner(state2);
            Assert.IsFalse(owner.AddOwner(state2));
            Assert.AreEqual(1, owner.GetChildren().Count);
            Assert.AreEqual(1, state2.GetStoreOwners().Count);
        }

        [Test]
        public void AddManager_AddNewManager_ReturnsTrue()
        {
            Assert.IsTrue(owner.AddManager(state2, new bool[6]));
            Assert.AreEqual(1, owner.GetChildren().Count);
            Assert.AreEqual(1, state2.GetStoreOwners().Count);
        }

        [Test]
        public void RemoveChild_RemoveExistingChild_ReturnsTrue()
        {
            owner.AddOwner(state2);
            Assert.IsTrue(owner.RemoveChild(state2.GetOwner(store)));
            Assert.AreEqual(0, owner.GetChildren().Count);
            Assert.IsNull(state2.GetOwner(store));
        }

        [Test]
        public void RemoveChild_RemoveNonExistingChild_ReturnsFalse()
        {
            Assert.IsFalse(owner.RemoveChild(new StoreOwner(state2, new Store("temp"), null)));
            Assert.AreEqual(0, owner.GetChildren().Count);
            Assert.IsNull(state2.GetOwner(store));
        }
    }
}
