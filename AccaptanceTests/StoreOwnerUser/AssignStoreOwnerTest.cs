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

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class AssignStoreOwnerTest
    {
        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            Register.Registration("saar", "123456", UserId_Saar);
            LogIn.Login("saar", "123456", UserId_Saar);
            Register.Registration("nati", "123456", UserId_Nati);
            OpenStore.openStore("Victory", UserId_Orel);

        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            SystemReset.Reset();       
        }
        [Test]
        public void AssignNewStoreOwnerTest()
        {
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
        }
        [Test]
        public void Assign_With_Wrong_Or_NotExisiting_UserNameTest()
        {//when the system check if the username exist -if not it returns null->null reference
            Assert.Throws<ErrorMessageException>(() => AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "WrongOrNotExisting"));
        }
        [Test]
        public void DoubleAssignTest()
        {
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.Throws<ErrorMessageException>(() => AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"));
        }
        [Test]
        public void CircularAssignTest()
        {
            LogIn.Login("nati", "123456", UserId_Nati);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.Throws<ErrorMessageException>(() => AssignStoreOwner.assignStoreOwner(UserId_Nati, "Victory", "Orel"));
        }
        [Test]
        public void Someone_Else_Assign_Him_To_Store_Test()
        {
            LogIn.Login("nati", "123456", UserId_Nati);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Nati, "Victory", "saar"), true);
            Assert.Throws<ErrorMessageException>(() => AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "saar"));

        }

    }
}
