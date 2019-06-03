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
        AllRegisteredUsers Allusers = null;
        Workshop192.MarketManagment.System system = null;

        User Orel;
        User Nati;
        int userIDorel;
        int userIDnati;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            Allusers = AllRegisteredUsers.GetInstance();
            system = Workshop192.MarketManagment.System.GetInstance(); Orel = new User();
            Nati = new User();
            userIDorel = Allusers.CreateUser();
            userIDnati = Allusers.CreateUser();
            Register.Registration("orel", "123456", userIDorel);
            LogIn.Login("orel", "123456", userIDorel);
        }
        [TearDown]
        public void TearDown()
        {
            system = Workshop192.MarketManagment.System.Reset();
            Allusers = AllRegisteredUsers.Reset();
        }
        [Test]
        public void SuccessLogOutTest()
        {
            Assert.AreEqual(LogOut.Logout(userIDorel), true);
        }
        [Test]
        public void DoubleLogOutTest()
        {
            Assert.AreEqual(LogOut.Logout(userIDorel), true);
            Assert.AreEqual(LogOut.Logout(userIDorel), false);
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.AreEqual(LogOut.Logout(userIDnati), false);
        }
    }
}
