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
    public class SearchProductsTest
    {

        AllRegisteredUsers Allusers = null;
        Workshop192.MarketManagment.System system = null;
        User Orel;
        int userIDorel;
        Product p1;
        Product p2;
        Product p3;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            Allusers = AllRegisteredUsers.GetInstance();
            system = Workshop192.MarketManagment.System.GetInstance(); Orel = new User();
            userIDorel = Allusers.CreateUser();

            Register.Registration("orel", "123456", userIDorel);
            LogIn.Login("orel", "123456", userIDorel);
            Allusers.GetUser(userIDorel).OpenStore("Victory");
            p1 = system.CreateProduct("black bread","bread",10);
            p2 = system.CreateProduct("white bread", "bread", 20);
            p3 = system.CreateProduct("cutted bread", "bread", 30);
            Allusers.GetUser(userIDorel).AddProducts("Victory",p1,5);
            Allusers.GetUser(userIDorel).AddProducts("Victory", p2, 10);
            Allusers.GetUser(userIDorel).AddProducts("Victory", p3, 15);

        }
        [TearDown]
        public void TearDown()
        {
            system = Workshop192.MarketManagment.System.Reset();
            Allusers = AllRegisteredUsers.Reset();
        }
        [Test]
        public void SearchBreadTest()
        {
            LinkedList<Product> l1 = new LinkedList<Product>();
            l1.AddLast(p1);
            l1.AddLast(p2);
            l1.AddLast(p3);
            Assert.AreEqual(SearchProducts.Search("bread"),l1);
        }
        [Test]
        public void SearchWhiteBreadTest()
        {
            LinkedList<LinkedList<string>> list = new LinkedList<LinkedList<string>>();
            LinkedList<string> l1 = new LinkedList<string>();
            l1.AddLast(p2.GetId()+ "");
            l1.AddLast(p2.GetName() + "");
            l1.AddLast(p2.GetCategory() + "");
            l1.AddLast(p2.GetPrice() + "");
            list.AddLast(l1);
            Assert.AreEqual(SearchProducts.Search("white bread"), l1);
        }
        [Test]
        public void SearchNoResultsTest()
        {
            LinkedList<Product> l3 = new LinkedList<Product>();
            Assert.AreEqual(SearchProducts.Search("coca cola"), l3);
        }
    }
}
