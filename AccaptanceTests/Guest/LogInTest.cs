using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using Workshop192.UserManagment;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class LogInTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Register.Registration("orel", "123456", Orel);
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void SuccessLoginTest()
        {
            Assert.AreEqual(LogIn.Login("orel", "123456", Orel), true);
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.AreEqual(LogIn.Login("nati", "2222", Nati), false);
        }
        [Test]
        public void DoubleLoginTest() // NULL in case that GetUser(username,password) not exist ( == null) 
        {
            Assert.AreEqual(LogIn.Login("orel", "123456", Orel), true);
            Assert.AreEqual(LogIn.Login("orel", "123456", Orel), false);
        }
        [Test]
        public void WrongPasswordTest() // NULL in case that GetUser(username,password) not exist ( == null)
        {
            Assert.AreEqual(LogIn.Login("orel", "111", Orel), false);
        }
        [Test]
        public void WrongUsernameTest() // NULL in case that GetUser(username,password) not exist ( == null)
        {
            Assert.AreEqual(LogIn.Login("ore", "123456", Orel), false);
        }

    }
}
