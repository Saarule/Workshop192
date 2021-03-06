﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class PolicyLeafMaximumAmountTests
    {
        PolicyLeafMaximumAmount policy;
        Cart cart;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store");
            Store store = Workshop192.MarketManagment.System.GetInstance().GetStore("store");
            Product p1 = new Product(1, "1", "1", 1);
            Product p2 = new Product(2, "2", "2", 2);
            store.AddProducts(p1, 10);
            store.AddProducts(p2, 10);
            cart = new Cart(store, new MultiCart(1));
            cart.AddProductsToCart(1, 10);
            cart.AddProductsToCart(2, 10);
        }

        [Test]
        public void Validate_ValidateProductCorrect_ReturnsTrue()
        {
            policy = new PolicyLeafMaximumAmount(1, 12);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateStoreCorrect_ReturnsTrue()
        {
            policy = new PolicyLeafMaximumAmount(0, 25);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateProductIncorrect_ReturnsFalse()
        {
            policy = new PolicyLeafMaximumAmount(1, 7);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateStoreIncorrect_ReturnsFalse()
        {
            policy = new PolicyLeafMaximumAmount(0, 15);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
            Workshop192.MarketManagment.System.Reset();
        }
    }
}
