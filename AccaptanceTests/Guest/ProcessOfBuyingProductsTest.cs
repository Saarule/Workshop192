/*using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using ServiceLayer.RegisteredUser;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class ProcessOfBuyingProductsTest
    {

        int UserId_Orel;
        int UserId_Nati;
        int UserId_Saar;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();

            Register.Registration("orel", "Orelp", UserId_Orel);
            LogIn.Login("orel", "OrelP", UserId_Orel);
            OpenStore.openStore("Victory", UserId_Orel);
            OpenStore.openStore("Mega", UserId_Orel);


            ManageProducts.ManageProduct(UserId_Orel, -1, " white bread", "bread", 10, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, " black bread", "bread", 15, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, " chocolate", "chocolate", 11, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "milki", "dairy products", 12, 50, "Mega", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "humus", "humus", 15, 50, "Mega", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "water", "water", 7, 50, "Mega", "add");


            SaveProductToCart.SaveProduct(1,UserId_Orel,10);
            SaveProductToCart.SaveProduct(2, UserId_Orel, 10);
            SaveProductToCart.SaveProduct(4, UserId_Orel, 10);
            SaveProductToCart.SaveProduct(5, UserId_Orel, 10);
            SaveProductToCart.SaveProduct(3, UserId_Nati, 10);
            SaveProductToCart.SaveProduct(6, UserId_Nati, 10);

        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            //SystemReset.Reset();//the opposite of initalization of the system

        }

        /*[Test]
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
}*/
