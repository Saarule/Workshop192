﻿using NUnit.Framework;
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
    class MultiCartTests
    {
        private MultiCart multiCart;
        private Store store1;
        private Store store2;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store1");
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store2");
            store1 = Workshop192.MarketManagment.System.GetInstance().GetStore("store1");
            store2 = Workshop192.MarketManagment.System.GetInstance().GetStore("store2");
            multiCart = new MultiCart(1);
            store1.AddProducts(new Product(1, "can", "tin", 5), 5);
            store1.AddProducts(new Product(2, "floor", "wood", 10), 10);
            store2.AddProducts(new Product(3, "nike", "shoes", 25), 5);
        }

        [Test]
        public void AddProductsToMultiCart_AddProductFromStore_ReturnsTrue()
        {
            Assert.IsTrue(multiCart.AddProductsToMultiCart(store1, 1, 2));
            Assert.IsTrue(multiCart.AddProductsToMultiCart(store2, 3, 2));
            Assert.AreEqual(2, multiCart.GetCarts().Count);
        }

        [Test]
        public void AddProductsToMultiCart_AddProductNotFromStore_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => multiCart.AddProductsToMultiCart(store1, 3, 2));
            Assert.AreEqual(0, multiCart.GetCarts().Count);
        }

        [Test]
        public void RemoveProductFromMultiCart_RemoveExistingProduct_ReturnsTrue()
        {
            multiCart.AddProductsToMultiCart(store1, 1, 2);
            multiCart.AddProductsToMultiCart(store2, 3, 2);
            Assert.IsTrue(multiCart.RemoveProductFromMultiCart(1));
            Assert.AreEqual(1, multiCart.GetCarts().Count);
        }

        [Test]
        public void RemoveProductFromMultiCart_RemoveNonExistingProduct_ReturnsFalse()
        {
            multiCart.AddProductsToMultiCart(store1, 1, 2);
            multiCart.AddProductsToMultiCart(store2, 3, 2);
            Assert.Throws<ErrorMessageException>(() => multiCart.RemoveProductFromMultiCart(2));
            Assert.AreEqual(2, multiCart.GetCarts().Count);
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.MarketManagment.System.Reset();
            DbCommerce.GetInstance().EndTests();
        }
    }
}
