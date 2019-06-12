using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.RegisteredUser
{
    [TestFixture]
    public class OpenStoreTest
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
            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            Register.Registration("saar", "12345123", UserId_Saar);
            LogIn.Login("saar", "12345123", UserId_Saar);
            
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();      
        }
        [Test]
        public void SuccessOpenStoreTest()
        {
            Assert.AreEqual(OpenStore.openStore("Victory", UserId_Orel), true);
        }
        [Test]
        public void OpenExistStoreTest()
        {

            Assert.AreEqual(OpenStore.openStore("Victory", UserId_Orel), true);
            Assert.AreEqual(OpenStore.openStore("Victory", UserId_Orel), false);
        }
        [Test]
        public void OpenExistStoreTest2()
        {

            Assert.AreEqual(OpenStore.openStore("Victory", UserId_Orel), true);
            Assert.AreEqual(OpenStore.openStore("Victory", UserId_Saar), false);
        }
        [Test]
        public void UserNotRegisteredOpenStoreTest()
        {
            Assert.AreEqual(OpenStore.openStore("victory", UserId_Nati), false);
        }
    }
}
