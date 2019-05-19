using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class AssignStoreOwnerTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        User Saar;
        Product p1;
        Product p2;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Saar = new User();
            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            Register.Registration("saar", "123456", Saar);
            LogIn.Login("saar", "123456", Saar);
            Register.Registration("nati", "123456", Nati);
            System.OpenStore("Victory", Orel.GetState());
            p1 = new Product(1, 10, "white bread");
            p2 = new Product(2, 12, "black bread");
            ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add");

        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void AssignNewStoreOwnerTest()
        {
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "nati"), true);
        }
        [Test]
        public void Assign_With_Wrong_Or_NotExisiting_UserNameTest()
        {//when the system check if the username exist -if not it returns null->null reference
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "WrongOrNotExisting"), false);
        }
        [Test]
        public void DoubleAssignTest()
        {
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "nati"), false);
        }
        [Test]
        public void CircularAssignTest()
        {
            LogIn.Login("nati", "123456", Nati);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Nati, System.GetStore("Victory"), "Orel"), false);
        }
        [Test]
        public void Someone_Else_Assign_Him_To_Store_Test()
        {
            LogIn.Login("nati", "123456", Nati);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Nati, System.GetStore("Victory"), "saar"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "saar"), false);

        }

    }
}
