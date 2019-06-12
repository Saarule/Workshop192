using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using ServiceLayer.RegisteredUser;

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
            System.Initalize();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "Orelp", UserId_Orel);
            LogIn.Login("orel", "Orelp", UserId_Orel);
            Register.Registration("saar", "Saarp", UserId_Saar);
            LogIn.Login("saar", "Saarp", UserId_Saar);
            Register.Registration("nati", "Natip", UserId_Nati);
            OpenStore.openStore("Victory", UserId_Orel);



        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            //SystemReset.Reset();//the opposite of initalization of the system        
        }
        [Test]
        public void AssignNewStoreOwnerTest()
        {
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
        }
        [Test]
        public void Assign_With_Wrong_Or_NotExisiting_UserNameTest()
        {//when the system check if the username exist -if not it returns null->null reference
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "WrongOrNotExisting"), false);
        }
        [Test]
        public void DoubleAssignTest()
        {
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), false);
        }
        [Test]
        public void CircularAssignTest()
        {
            LogIn.Login("nati", "Natip", UserId_Nati);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Nati, "Victory", "Orel"), false);
        }
        [Test]
        public void Someone_Else_Assign_Him_To_Store_Test()
        {
            LogIn.Login("nati", "Natip", UserId_Nati);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Nati, "Victory", "saar"), true);
            Assert.AreEqual(AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "saar"), false);

        }

    }
}
