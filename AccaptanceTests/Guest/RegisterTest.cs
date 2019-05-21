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
            Register.Registration("orel", "123456",Orel);
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void UniqueUserNameTest()
        {
            Assert.AreEqual(Register.Registration("nati", "5555", Nati), true);
        }
        [Test]
        public void UserNameExistTest()
        {
            Assert.AreEqual(Register.Registration("orel", "5555", Nati), false);
        }
        [Test]
        public void DoubleRegistrationTest()
        {
            Assert.AreEqual(Register.Registration("orel", "11111", Orel), false);
        }

    }
}
