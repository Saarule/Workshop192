using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class ManageProductsTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        Product p1;
        Product p2;
        Product p3;
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
            p1 = new Product(1,20,"Milk");
            p2 = new Product(2, 15,"Pepsi");
            p3 = new Product(2, 15, "Soda");
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void AddCorrectProductsTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel,p1,System.GetStore("Victory"),"add"), true);
        }
        [Test]
        public void AddIncorrectProductTest()
        { 
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add"), false);
        }
        /*[Test]
        public void AddProductsWithSameIDTest() // need to check id and not just equality
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "add"), false);
        }*/
        [Test]
        public void DeleteProductTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "delete"), true);
        }
        [Test]
        public void DeleteProductNotExistsTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "delete"), false);
        }
        [Test]
        public void DeleteProductTwiceTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "delete"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "delete"), false);
        }
        [Test]
        public void EditProductTwiceTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "edit"), true);
        }
        [Test]
        public void EditDeletedProductTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "delete"), true);
            Assert.AreEqual(ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "edit"), false);
        }
    }
}
