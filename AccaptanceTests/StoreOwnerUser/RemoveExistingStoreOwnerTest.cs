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
    public class RemoveExistingStoreOwnerTest
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
            System.OpenStore("Victory", Orel.GetInfo());
            AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "saar");
            AssignStoreOwner.assignStoreOwner(Orel, System.GetStore("Victory"), "nati");
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void RemoveChildTest()
        {
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), System.GetUser("nati", "123456")), true);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), Saar.GetInfo()), true);

        }
        [Test]
        public void Remove_NotExisted_Child_Test()
        {//when the system check if the username exist -if not it returns null->null reference
            User Ben = new User();
            Register.Registration("Ben", "55", Ben);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), Ben.GetInfo()), false);
        }
        [Test]
        public void Remove_Grandson_Test()
        {
            User Ben = new User();
            Register.Registration("Ben", "55", Ben);
            LogIn.Login("Ben", "55", Ben);
            AssignStoreOwner.assignStoreOwner(Saar, System.GetStore("Victory"), "Ben");

            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), Ben.GetInfo()), false);
        }
        [Test]
        public void DoubleRemoveTest()
        {
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), Saar.GetInfo()), true);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), Saar.GetInfo()), false);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), System.GetUser("nati", "123456")), true);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(Orel, System.GetStore("Victory"), System.GetUser("nati", "123456")), false);



        }
        

    }
}
