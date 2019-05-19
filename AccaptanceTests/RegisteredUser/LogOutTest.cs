using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using Workshop192.UserManagment;

namespace AccaptanceTests.RegisteredUser
{
    [TestFixture]
    public class LogOutTest
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
            LogIn.Login("orel", "123456", Orel);
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void SuccessLogOutTest()
        {
            Assert.AreEqual(LogOut.Logout(Orel), true);
        }
        [Test]
        public void DoubleLogOutTest()
        {
            Assert.AreEqual(LogOut.Logout(Orel), true);
            Assert.AreEqual(LogOut.Logout(Orel), false);
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.AreEqual(LogOut.Logout(Nati), false);
        }
    }
}
