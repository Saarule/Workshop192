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
    public class ProcessOfBuyingProductsTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        User Saar;

        Product p1;
        Product p2;
        Product p3;
        Product p4;
        Product p5;
        Product p6;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Saar = new User();

            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            System.OpenStore("Victory", Orel.GetState());
            System.OpenStore("Mega", Orel.GetState());
            p1 = new Product(1, 10, "white bread");
            p2 = new Product(2, 12, "black bread");
            p3 = new Product(3, 10, "chocolate");
            p4 = new Product(4, 5, "milki");
            p5 = new Product(5, 15, "humus");
            p6 = new Product(6, 2, "water");
            ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "add");
            SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Orel);
            SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Orel);
            
            ManageProducts.ManageProduct(Orel, p4, System.GetStore("Mega"), "add");
            ManageProducts.ManageProduct(Orel, p5, System.GetStore("Mega"), "add");
            ManageProducts.ManageProduct(Orel, p6, System.GetStore("Mega"), "add");
            SaveProductToCart.SaveProduct(p4, System.GetStore("Mega"), Orel);
            SaveProductToCart.SaveProduct(p5, System.GetStore("Mega"), Orel);

            SaveProductToCart.SaveProduct(p3, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p6, System.GetStore("Mega"), Nati);

        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void BuyingLoggedInUserTest()
        {
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(1111,Orel,"orel kakon","hadekel 2"), true);
        }
        [Test]
        public void BuyingNotRegisteredUserTest()
        {
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(22222, Nati, "Nati kalontar", "shlomo 2"), true);
        }
        [Test]
        public void BuyingEmptyListcartTest() 
        {
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(3333, Saar, "Saar mashehu", "lalalend 6"), false);
        }
        public void BuyingFailed_Because_Product_isnot_Availabe_Test()
        {
            Product p7 = new Product(7, 5, "milk");
            ManageProducts.ManageProduct(Orel, p7, System.GetStore("Mega"), "add");

            SaveProductToCart.SaveProduct(p7, System.GetStore("Mega"), Orel);
            SaveProductToCart.SaveProduct(p7, System.GetStore("Mega"), Nati);

            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(22222, Nati, "Nati kalontar", "shlomo 2"), true);
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(1111, Orel, "orel kakon", "hadekel 2"), false);


        }
        [Test]
        public void DoubleBuyingTest()
        {
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(22222, Nati, "Nati kalontar", "shlomo 2"), true);
            
        //assert failed because maybe Nati buying empty list and 
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(22222, Nati, "Nati kalontar", "shlomo 2"), false);

        }

    }
}
