using System;
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
    public class CheckAvailablilityTest
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
           // OpenStore.openStore("Mega", UserId_Orel);


            ManageProducts.ManageProduct(UserId_Orel, -1, " white bread", "bread", 10, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, " black bread", "bread", 15, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, " chocolate", "chocolate", 11, 50, "victory", "add");
           // ManageProducts.ManageProduct(UserId_Orel, -1, "milki", "dairy products", 12, 50, "Mega", "add");
            //ManageProducts.ManageProduct(UserId_Orel, -1, "humus", "humus", 15, 50, "Mega", "add");
           // ManageProducts.ManageProduct(UserId_Orel, -1, "water", "water", 7, 50, "Mega", "add");


          

        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            //SystemReset.Reset();//the opposite of initalization of the system
        }

        [Test]
        public void AvailableFromOneShopTest()
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel, 20);
            Assert.AreEqual(CheckAvailability.CheckAvailable(UserId_Orel), true);
        }
        /*[Test]
        public void AvailableFromTwoShopTest()
        {
            Assert.AreEqual(CheckAvailability.CheckAvailable(Nati.GetCarts()), true);
        }*/
        [Test]
        public void NotAvailableProductShopTest()
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel, 60);
            Assert.AreEqual(CheckAvailability.CheckAvailable(UserId_Orel),false);
           
        }
    }
}
