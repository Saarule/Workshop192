using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class SaveProductsToCartTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        Product p1;
        Product p2;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            System.OpenStore("Victory", Orel.GetState());
            p1 = new Product(1, 10, "white bread");
            p2 = new Product(2, 12, "black bread");
            ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add");

        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void AddProductToCartNonRegisteredTest()
        {
            Assert.AreEqual(SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Nati),true);
        }
        [Test]
        public void AddProductToCartRegistedUserTest()
        {
            Assert.AreEqual(SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Orel), true);
        }
        [Test]
        public void AddCatchedProductTest() 
        {
            Assert.AreEqual(SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Orel), true);
            Assert.AreEqual(SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Nati), false);
        }
    }
}
