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
    public class LogOutTest
    {
        int UserId_Nati;
        int UserId_Orel;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
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
            Assert.AreEqual(LogOut.Logout(UserId_Orel), false);
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.AreEqual(LogOut.Logout(UserId_Nati), false);
        }
        [Test]
        public void UserNotLoggedInTest()
        {
            Register.Registration("nati", "1111111", UserId_Nati);
            Assert.AreEqual(LogOut.Logout(UserId_Nati), false);
        }
    }
}
