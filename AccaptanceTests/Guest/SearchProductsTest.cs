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
    public class SearchProductsTest
    {

        int UserId_Orel;
        LinkedList<LinkedList<string>> l1 = new LinkedList<LinkedList<string>>();
        LinkedList<LinkedList<string>> l2 = new LinkedList<LinkedList<string>>();
        LinkedList<string> black_bread = new LinkedList<string>();
        LinkedList<string> white_bread = new LinkedList<string>();
        LinkedList<string> cutted_bread = new LinkedList<string>();

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Orel = CreateAndGetUser.CreateUser();
           

            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            OpenStore.openStore("victory", UserId_Orel);
            ManageProducts.ManageProduct(UserId_Orel, -1, "black bread", "bread", 10, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "white bread", "bread", 15, 50, "victory", "add");
            ManageProducts.ManageProduct(UserId_Orel, -1, "cutted bread", "bread", 20, 50, "victory", "add");

            black_bread.AddLast("1");
            black_bread.AddLast("black bread");
            black_bread.AddLast("bread");
            black_bread.AddLast("10");
            black_bread.AddLast("50");
            black_bread.AddLast("victory");

            white_bread.AddLast("2");
            white_bread.AddLast("white bread");
            white_bread.AddLast("bread");
            white_bread.AddLast("15");
            white_bread.AddLast("50");
            white_bread.AddLast("victory");

            cutted_bread.AddLast("3");
            cutted_bread.AddLast("cutted bread");
            cutted_bread.AddLast("bread");
            cutted_bread.AddLast("20");
            cutted_bread.AddLast("50");
            cutted_bread.AddLast("victory");
        }
        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            white_bread = new LinkedList<string>();
            black_bread = new LinkedList<string>();
            cutted_bread = new LinkedList<string>();
            l2 = new LinkedList<LinkedList<string>>();
            l1 = new LinkedList<LinkedList<string>>();
            SystemReset.Reset();
        }
        [Test]
        public void SearchBreadTest()
        {
            l1.AddLast(black_bread);
            l1.AddLast(white_bread);
            l1.AddLast(cutted_bread);

            Assert.AreEqual(SearchProducts.Search("bread"),l1);
        }
        [Test]
        public void SearchWhiteBreadTest()
        {
            l2.AddLast(white_bread);
            Assert.AreEqual(SearchProducts.Search("white bread"), l2);
        }
        [Test]
        public void SearchBlackBreadTest()
        {
            l2.AddLast(black_bread);
            Assert.AreEqual(SearchProducts.Search("black bread"), l2);
        }
        [Test]
        public void SearchNoResultsTest()
        {
            Assert.AreEqual(SearchProducts.Search("coca cola"), l1);
        }
    }
}
