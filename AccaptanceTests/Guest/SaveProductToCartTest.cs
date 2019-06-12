using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using ServiceLayer.RegisteredUser;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class SaveProductsToCartTest
    {
       int UserId_Orel;
        int UserId_Nati;
        

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Nati = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "Orelp", UserId_Orel);
            LogIn.Login("orel", "Orelp",UserId_Orel);
            OpenStore.openStore("Victory", UserId_Orel);
            ManageProducts.ManageProduct(UserId_Orel, -1, " black bread", "bread", 10, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, " white bread", "bread", 15, 50, "victory", "add");


         

        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            SystemReset.Reset();//the opposite of initalization of the system
        }
        [Test]
        public void AddProductToCartNonRegisteredTest()
        {
            Assert.AreEqual(SaveProductToCart.SaveProduct(1,UserId_Nati,10),true);
        }
        [Test]
        public void AddProductToCartRegistedUserTest()
        {
            Assert.AreEqual(SaveProductToCart.SaveProduct(1,UserId_Orel,5), true);
        }
        [Test]
        public void AddNotExistedProductTest() 
        {
            Assert.AreEqual(SaveProductToCart.SaveProduct(99999, UserId_Orel, 5), false);
        }
    }
}

