using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;
using Workshop192;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class RegisterTest
    {
       // AllRegisteredUsers Allusers = null;
       // Workshop192.MarketManagment.System system = null;
        int UserId_Nati;
        int UserId_Orel;
 
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
           
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();//the opposite of initalization of the system
            
        }
        [Test]
        public void UniqueUserNameTest()
        {
            Assert.AreEqual(Register.Registration("nati", "5555555", UserId_Nati), true);
        }
        [Test]
        public void UserNameExistTest()
        {
            Assert.AreEqual(Register.Registration("orel", "5555555", UserId_Nati), true);
            Assert.Throws<ErrorMessageException>(() => Register.Registration("orel", "5555", UserId_Orel));
        }
        [Test]
        public void DoubleRegistrationTest()
        {
            Assert.AreEqual(Register.Registration("orel", "11111", UserId_Orel), true);
            Assert.Throws<ErrorMessageException>(() => Register.Registration("orel", "11111", UserId_Orel));
        }

    }
}
