using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using ServiceLayer.RegisteredUser;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class AssignStoreManagerTest
    {
        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;
 
        bool [] privileges = { true, true, true, true, true, true };
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
            SystemReset.Reset();//the opposite of initalization of the system        
        }
        [Test]
        public void AssignNewStoreManagerTest()
        {
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Orel, "victory", "nati",privileges), true);
        }
        [Test]
        public void Assign_With_Wrong_Or_NotExisiting_UserNameTest()
        {//when the system check if the username exist -if not it returns null->null reference
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Orel,"Victory", "wrong", privileges), false);
        }
        [Test]
        public void DoubleAssignTest()
        {
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "nati", privileges), true);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "nati", privileges), false);
        }
        [Test]
        public void CircularAssignTest()
        {
            LogIn.Login("nati", "Natip", UserId_Nati);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "nati", privileges), true);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Nati, "Victory", "orel", privileges), false);
        }
        [Test]
        public void Someone_Else_Assign_Him_To_Store_Test()
        {
            LogIn.Login("nati", "Natip", UserId_Nati);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "nati", privileges), true);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Nati, "Victory", "saar", privileges), true);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Saar, "Victory", "orel", privileges), false);

        }

    }
}
