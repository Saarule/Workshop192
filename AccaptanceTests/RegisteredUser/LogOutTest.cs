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
        int UserId_Nati;
        int UserId_Orel;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();

            Register.Registration("orel", "Orelp", UserId_Orel);
            LogIn.Login("orel", "Orelp", UserId_Orel);
        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            //SystemReset.Reset();//the opposite of initalization of the system        
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
    }
}
