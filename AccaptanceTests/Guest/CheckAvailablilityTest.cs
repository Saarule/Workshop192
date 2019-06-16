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
using Workshop192;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class CheckAvailablilityTest
    {
        int UserId_Orel;
        int UserId_Nati;
        int UserId_Saar;
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();

            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            OpenStore.openStore("victory", UserId_Orel);


            ManageProducts.ManageProduct(UserId_Orel, -1, "white bread", "bread", 10, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "black bread", "bread", 15, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "chocolate", "chocolate", 11, 50, "victory", "add");
           
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [Test]
        public void AvailableFromOneShopTest()
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel, 20);
            Assert.AreEqual(CheckAvailability.CheckAvailable(UserId_Orel), true);
        } 
        [Test]
        public void NotAvailableProductShopTest()
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel, 40);
            ManageProducts.ManageProduct(UserId_Orel, 1, "white bread", "bread", 10, 30, "victory", "edit");
            Assert.Throws<ErrorMessageException>(() => CheckAvailability.CheckAvailable(UserId_Orel));  
        }
    }
}
