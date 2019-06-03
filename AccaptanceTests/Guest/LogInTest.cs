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
        AllRegisteredUsers Allusers = null;
        Workshop192.MarketManagment.System system = null;
        User Orel;
        User Nati;
        int userIDorel;
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            Allusers = AllRegisteredUsers.GetInstance();
            system = Workshop192.MarketManagment.System.GetInstance();
            Orel = new User();
            userIDorel = Allusers.CreateUser();
            Nati = new User();
            //int userIDnati = Allusers.CreateUser();
            Register.Registration("orel", "123456", userIDorel);
        }
        [TearDown]
        public void TearDown()
        {
            system = Workshop192.MarketManagment.System.Reset();
            Allusers = AllRegisteredUsers.Reset();
        }
        [Test]
        public void SuccessLoginTest()
        {
            Assert.AreEqual(LogIn.Login("orel", "123456", userIDorel), true);
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.AreEqual(LogIn.Login("nati", "2222", userIDorel), false);
        }
        [Test]
        public void DoubleLoginTest() // NULL in case that GetUser(username,password) not exist ( == null) 
        {
            Assert.AreEqual(LogIn.Login("orel", "123456", userIDorel), true);
            Assert.AreEqual(LogIn.Login("orel", "123456", userIDorel), false);
        }
        [Test]
        public void WrongPasswordTest() // NULL in case that GetUser(username,password) not exist ( == null)
        {
            Assert.AreEqual(LogIn.Login("orel", "111", userIDorel), false);
        }
        [Test]
        public void WrongUsernameTest() // NULL in case that GetUser(username,password) not exist ( == null)
        {
            Assert.AreEqual(LogIn.Login("ore", "123456", userIDorel), false);
        }

    }
}
