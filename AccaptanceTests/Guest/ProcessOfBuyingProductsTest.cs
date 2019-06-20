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
    public class ProcessOfBuyingProductsTest
    {

        int UserId_Orel;
        int UserId_Nati;
        int UserId_Saar;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();

            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            OpenStore.openStore("victory", UserId_Orel);
            OpenStore.openStore("Mega", UserId_Orel);


            ManageProducts.ManageProduct(UserId_Orel, -1, "white bread", "bread", 10, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "black bread", "bread", 15, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "chocolate", "chocolate", 11, 50, "victory", "add");
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
            DbCommerce.GetInstance().EndTests();
            //TODO
            SystemReset.Reset();

        }

        [Test]
        public void BuyingLoggedInUserTest()
        {
            Assert.NotNull(ProcessOfBuyingProducts.ProcessBuyingProducts("1111114444","11","2019","avi-levi","222","208883399","avi","hadkel 6","beit shemesh","israel","99933",UserId_Orel));
        }
        [Test]
        public void BuyingNotRegisteredUserTest()
        {
            Assert.NotNull(ProcessOfBuyingProducts.ProcessBuyingProducts("1111114444", "11", "2019", "avi-levi", "222", "208883399", "avi", "hadkel 6", "beit shemesh", "israel", "99933", UserId_Nati));
        }
        [Test]
        public void BuyingEmptyListcartTest() 
        {
            Assert.NotNull(ProcessOfBuyingProducts.ProcessBuyingProducts("1111114444","11","2019","avi-levi","222","208883399","avi","hadkel 6","beit shemesh","israel","99933",UserId_Orel));
        }
        public void BuyingFailed_Because_Product_isnot_Availabe_Test()
        {
            ManageProducts.ManageProduct(UserId_Orel, -1, "Hummus","Salad",10,50,"Mega","add");

            SaveProductToCart.SaveProduct(7,UserId_Orel,40);
            SaveProductToCart.SaveProduct(7, UserId_Nati, 40);

            Assert.NotNull(ProcessOfBuyingProducts.ProcessBuyingProducts("1111114444", "11", "2019", "avi-levi", "222", "208883399", "avi", "hadkel 6", "beit shemesh", "israel", "99933", UserId_Nati));
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts("1111114444", "11", "2019", "avi-levi", "222", "208883399", "avi", "hadkel 6", "beit shemesh", "israel", "99933", UserId_Orel), new Tuple<int, int>(-1, -1));


        }
        /*[Test]
        public void DoubleBuyingTest()
        {
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(22222, UserId_Nati, "Nati kalontar", "shlomo 2"), true);
            
        //assert failed because maybe Nati buying empty list and 
            Assert.AreEqual(ProcessOfBuyingProducts.ProcessBuyingProducts(22222, UserId_Nati, "Nati kalontar", "shlomo 2"), true);

        }*/

    }
}
