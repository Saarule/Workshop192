using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;
using Workshop192;

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
            DbCommerce.GetInstance().StartTests();
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
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
            DbCommerce.GetInstance().EndTests();
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
            Assert.Throws<ErrorMessageException>(() => OpenStore.openStore("Victory", UserId_Orel));
        }
        [Test]
        public void OpenExistStoreTest2()
        {

            Assert.AreEqual(OpenStore.openStore("Victory", UserId_Orel), true);
            Assert.Throws<ErrorMessageException>(() => OpenStore.openStore("Victory", UserId_Saar));
        }
        [Test]
        public void UserNotRegisteredOpenStoreTest()
        {
            Assert.Throws<ErrorMessageException>(() => OpenStore.openStore("victory", UserId_Nati));
        }
    }
}
