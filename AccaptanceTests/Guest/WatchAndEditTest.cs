using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using System.Linq;
using ServiceLayer.RegisteredUser;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class WatchAndEditTest
    {

        int UserId_Nati;
        int UserId_Orel;
        string[] product1 =new string[] {"white bread","bread","10","100"};
        string[] product2 = new string[] { "black bread", "bread", "10", "100" };
        string[] product3 = new string[] {  "cutted bread", "bread", "10", "100" };
        string[] product4 = new string[] { "brown bread", "bread", "10", "100" };



        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();

             UserId_Nati=CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "Orelp", UserId_Orel);
            LogIn.Login("orel", "Orelp", UserId_Orel);
            OpenStore.openStore("victory", UserId_Orel);
            OpenStore.openStore("Rami-Levi", UserId_Orel);
            
            
            ManageProducts.ManageProduct(UserId_Orel, -1, "black bread","bread",10,100,"Victory", "add");
            ManageProducts.ManageProduct(UserId_Orel,-1,"black bread","bread",15,100, "Victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "cutted bread", "bread", 20, 100, "Rami-Levi", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "brown bread", "bread", 25, 100, "Rami-Levi", "add");
           
           
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [Test]
        public void WatchSimpleCartTest()
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel,10);
            SaveProductToCart.SaveProduct(2, UserId_Orel,10);
            WatchAndEdit.Watch(UserId_Orel);
           
        }
        [Test]
        public void WatchComplicatedCartTest()
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel, 10);
            SaveProductToCart.SaveProduct(2, UserId_Orel, 10);
            SaveProductToCart.SaveProduct(3, UserId_Orel, 15);
            SaveProductToCart.SaveProduct(4, UserId_Orel, 20);
            WatchAndEdit.Watch(UserId_Orel);
          
        }
        [Test]
        public void WatchEmptyCartTest()
        {
            WatchAndEdit.Watch(UserId_Orel);

        }
        [Test]
        public void DeleteProductsCartTest() 
        {
            SaveProductToCart.SaveProduct(1, UserId_Orel, 10);
            SaveProductToCart.SaveProduct(2, UserId_Orel, 10);

            WatchAndEdit.Edit("delete", 1, UserId_Orel);
            
        }
    }
}
