using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class InventoryTests
    {
        private Inventory inventory;
        private Product product1;
        private Product product2;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            product1 = new Product(1, "a", "a", 1);
            product2 = new Product(2, "b", "b", 2);
            inventory.AddProducts(product1, 10);
        }

        [Test]
        public void AddProducts_AddNewProducts_ReturnsTrue()
        {
            Assert.IsTrue(inventory.AddProducts(product2, 5));
            Assert.AreEqual(2, inventory.GetAllProduct().Count);
            Assert.AreEqual(5, inventory.GetAllProduct()[product2]);
        }

        [Test]
        public void AddProducts_AddExistingProducts_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => inventory.AddProducts(product1, 5));
            Assert.AreEqual(1, inventory.GetAllProduct().Count);
            Assert.AreEqual(10, inventory.GetAllProduct()[product1]);
        }

        [Test]
        public void RemoveProducts_RemoveExistingProducts_ReturnsTrue()
        {
            Assert.IsTrue(inventory.RemoveProducts(product1, 2));
            Assert.AreEqual(1, inventory.GetAllProduct().Count);
            Assert.AreEqual(8, inventory.GetAllProduct()[product1]);
        }

        [Test]
        public void RemoveProducts_RemoveNonExistingProducts_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => inventory.RemoveProducts(product2, 2));
            Assert.AreEqual(1, inventory.GetAllProduct().Count);
            Assert.AreEqual(10, inventory.GetAllProduct()[product1]);
        }

        [Test]
        public void RemoveProductFromInventory_RemoveExistingProducts_ReturnsTrue()
        {
            Assert.IsTrue(inventory.RemoveProductFromInventory(product1.GetId()));
            Assert.AreEqual(0, inventory.GetAllProduct().Count);
        }

        [Test]
        public void RemoveProductFromInventory_RemoveNonExistingProducts_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => inventory.RemoveProductFromInventory(product2.GetId()));
            Assert.AreEqual(1, inventory.GetAllProduct().Count);
        }

        [Test]
        public void EditProduct_EditExistingProduct_ReturnsTrue()
        {
            Assert.IsTrue(inventory.EditProduct(product1.GetId(), "c", "c", 3, 30));
            Assert.AreEqual(1, inventory.GetAllProduct().Count);
            Assert.AreEqual(30, inventory.GetAllProduct()[product1]);
        }

        [Test]
        public void EditProduct_EditNonExistingProduct_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => inventory.EditProduct(product2.GetId(), "c", "c", 3, 30));
            Assert.AreEqual(1, inventory.GetAllProduct().Count);
            Assert.AreEqual(10, inventory.GetAllProduct()[product1]);
        }
    }
}
