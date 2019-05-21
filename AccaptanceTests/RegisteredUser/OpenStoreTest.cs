using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using Workshop192.UserManagment;

namespace AccaptanceTests.RegisteredUser
{
    [TestFixture]
    public class OpenStoreTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        User Saar;
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
            Register.Registration("saar", "313", Saar);
            LogIn.Login("saar", "313", Saar);
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void SuccessOpenStoreTest()
        {
            Assert.AreEqual(OpenStore.openStore("Victory",Orel), true);
        }
        [Test]
        public void OpenExistStoreTest()
        {

            Assert.AreEqual(OpenStore.openStore("Victory",Orel), true);
            Assert.AreEqual(OpenStore.openStore("Victory", Orel), false);
        }
        public void OpenExistStoreTest2()
        {

            Assert.AreEqual(OpenStore.openStore("Victory", Orel), true);
            Assert.AreEqual(OpenStore.openStore("Victory", Saar), false);
        }
        [Test]
        public void UserNotRegisteredOpenStoreTest()
        {
            Assert.AreEqual(OpenStore.openStore("victory",Nati), false);
        }
    }
}
