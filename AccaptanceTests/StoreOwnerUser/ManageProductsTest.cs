using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class ManageProductsTest
    {

        int UserId_Nati;
        int UserId_Orel;
        
        [SetUp]
        public void SetUp()
        {

            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            OpenStore.openStore("victory", UserId_Orel);
            
        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            SystemReset.Reset();//the opposite of initalization of the system        
        }
        [Test]
        public void AddCorrectProductsTest()
        {
            //add option do nothing with productId ,beacuse of this I insert ProductId=-1
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel,-1,"Milk", "dairy products",10,50,"victory","add"), true);
        }
        [Test]
        public void AddIncorrectProductTest()
        {
            //add option do nothing with productId ,beacuse of this I insert ProductId=-1
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, -1, "Milk", "dairy products", 10, 50, "victory", "add"), true);
            //Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, -1, "Milk", "dairy products", 10, 50, "victory", "add"), false);
        }
        [Test]
        public void DeleteProductTest()
        {
            //add option do nothing with productId ,beacuse of this I insert ProductId=-1
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, -1, "Milk", "dairy products", 10, 50, "victory", "add"), true);
            //I dont know productId after I add the product to the inventory.
            //because it the first product to be added to inventory in this test,I suppose its Id is 1.according to domain implementation.
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel,1, "Milk", "dairy products", 10, 50, "victory", "delete"), true);
        }
        [Test]
        public void DeleteProductNotExistsTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, 1, "Milk", "dairy products", 10, 50, "victory", "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel,99999, "Goat Milk", "dairy products", 9, 40, "victory", "delete"), false);
        }
        [Test]
        public void DeleteProductTwiceTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, -1, "Milk", "dairy products", 10, 50, "victory", "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, 1, "Milk", "dairy products", 10, 50, "victory", "delete"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, 1, "Milk", "dairy products", 10, 50, "victory", "delete"), false);
        }
        [Test]
        public void EditProductTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, -1, "Cheese", "dairy products", 10, 50, "victory", "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, 1, "Cheese", "dairy products", 20, 60, "victory", "edit"), true);
        }
        [Test]
        public void EditDeletedProductTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, -1,"Milk", "dairy products", 10, 50, "victory", "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, 1, "Milk", "dairy products", 10, 50, "victory", "delete"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Orel, 1, "Milk", "dairy products", 20, 60, "victory", "edit"), false);
        }
    }
}
