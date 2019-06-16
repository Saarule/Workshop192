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
    public class LogOutTest
    {
        int UserId_Nati;
        int UserId_Orel;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "111111", UserId_Orel);
            LogIn.Login("orel", "111111", UserId_Orel);
        }
        [TearDown]
        public void TearDown()
        { 
            SystemReset.Reset();      
        }
        [Test]
        public void SuccessLogOutTest()
        {
            Assert.AreEqual(LogOut.Logout(UserId_Orel), true);
        }
        [Test]
        public void DoubleLogOutTest()
        {
            Assert.AreEqual(LogOut.Logout(UserId_Orel), true);
            Assert.Throws<ErrorMessageException>(() => LogOut.Logout(UserId_Orel));
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.Throws<ErrorMessageException>(() => LogOut.Logout(UserId_Nati));
        }
        [Test]
        public void UserNotLoggedInTest()
        {
            Register.Registration("nati", "1111111", UserId_Nati);
            Assert.Throws<ErrorMessageException>(() => LogOut.Logout(UserId_Nati));
        }
    }
}
