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
    class CartTests
    {
        private Cart cart;
        private Product product;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            Workshop192.MarketManagment.System.GetInstance().OpenStore("newStore");
            product = new Product(1, "air", "element", 5);
            Workshop192.MarketManagment.System.GetInstance().GetStore("newStore").AddProducts(product, 4);
            cart = new Cart(Workshop192.MarketManagment.System.GetInstance().GetStore("newStore"), new MultiCart(1));
        }

        [Test]
        public void AddProductsToCart_AddNewProductToCart_ReturnsTrue()
        {
            Assert.IsTrue(cart.AddProductsToCart(1, 3));
            Assert.AreEqual(1, cart.GetProducts().Count);
            Assert.AreEqual(3, cart.GetProducts()[product]);
        }

        [Test]
        public void AddProductsToCart_AddExistingProductToCart_ReturnsTrue()
        {
            cart.AddProductsToCart(1, 2);
            Assert.IsTrue(cart.AddProductsToCart(1, 1));
            Assert.AreEqual(1, cart.GetProducts().Count);
            Assert.AreEqual(3, cart.GetProducts()[product]);
        }

        [Test]
        public void AddProductsToCart_AddProductToCartOverAmount_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => cart.AddProductsToCart(1, 5));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }
        
        [Test]
        public void AddProductsToCart_ProductNotInInventory_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => cart.AddProductsToCart(3, 2));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }

        [Test]
        public void RemoveProduct_RemoveExistingProductFromCart_ReturnsTrue()
        {
            cart.AddProductsToCart(1, 3);
            Assert.IsTrue(cart.RemoveProduct(1));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }

        [Test]
        public void RemoveProduct_RemoveNonExistingProductFromCart_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => cart.RemoveProduct(1));
            Assert.AreEqual(0, cart.GetProducts().Count);
        }

        [Test]
        public void SetSum_SuccesfulySetsTheFullPriceOfAllProducts_ReturnsTrue()
        {
            cart.AddProductsToCart(1, 2);
            cart.SetSum();
            Assert.AreEqual(10, cart.GetCartSum());
            cart.AddProductsToCart(1, 2);
            cart.SetSum();
            Assert.AreEqual(20, cart.GetCartSum());
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.MarketManagment.System.Reset();
            DbCommerce.GetInstance().EndTests();
        }
    }
}
