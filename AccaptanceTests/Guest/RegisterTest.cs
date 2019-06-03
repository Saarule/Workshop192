using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using Workshop192.UserManagment;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class RegisterTest
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
            system = Workshop192.MarketManagment.System.GetInstance();
            Orel = new User();
            userIDorel = Allusers.CreateUser();
            Nati = new User();
            Register.Registration("orel", "123456", userIDorel);
        }
        [TearDown]
        public void TearDown()
        {
            system = Workshop192.MarketManagment.System.Reset();
            Allusers = AllRegisteredUsers.Reset();
        }
        [Test]
        public void UniqueUserNameTest()
        {
            userIDorel = Allusers.CreateUser();
            Assert.AreEqual(Register.Registration("nati", "5555", userIDnati), true);
        }
        [Test]
        public void UserNameExistTest()
        {
            Assert.AreEqual(Register.Registration("orel", "5555", userIDnati), false);
        }
        [Test]
        public void DoubleRegistrationTest()
        {
            Assert.AreEqual(Register.Registration("orel", "11111", userIDorel), false);
        }

    }
}
