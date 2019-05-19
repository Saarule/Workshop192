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
    public class FilterProductsTest
    {
        Workshop192.System System = null;
        User Orel;
        Product p1;
        Product p2;
        Product p3;
        Product p4;
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            System.OpenStore("Victory", Orel.GetState());
            p1 = new Product(1, 10, "white bread");
            p2 = new Product(2, 12, "black bread");
            p3 = new Product(3, 10, "white bread");
            p4 = new Product(4, 10, "brown bread");
            ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p4, System.GetStore("Victory"), "add");
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void SearchWhiteBreadTest()
        {
            LinkedList<Product> l1 = new LinkedList<Product>();
            l1.AddLast(p1);
            l1.AddLast(p3);
            Assert.AreEqual(FilterProducts.Filter(SearchProducts.Search("bread"),"white"), l1);
        }
        [Test]
        public void SearchBrownBreadTest()
        {
            LinkedList<Product> l2 = new LinkedList<Product>();
            l2.AddLast(p4);
            Assert.AreEqual(FilterProducts.Filter(SearchProducts.Search("bread"), "brown"), l2);
        }
        [Test]
        public void SearchNoResultsTest()
        {
            LinkedList<Product> l3 = new LinkedList<Product>();
            Assert.AreEqual(FilterProducts.Filter(SearchProducts.Search("bread"), "light"), l3);
        }
    }
}
