using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;

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
            System.Initalize();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            /*InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            Allusers = AllRegisteredUsers.GetInstance();
            system = Workshop192.MarketManagment.System.GetInstance();
            Orel = new User();
            userIDorel = Allusers.CreateUser();
            Nati = new User();
            Register.Registration("orel", "123456", userIDorel);*/
        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            SystemReset.Reset();//the opposite of initalization of the system
            
        }
        [Test]
        public void UniqueUserNameTest()
        {
            Assert.AreEqual(Register.Registration("nati", "5555", UserId_Nati), true);
        }
        [Test]
        public void UserNameExistTest()
        {
            Assert.AreEqual(Register.Registration("orel", "5555", UserId_Orel), false);
        }
        [Test]
        public void DoubleRegistrationTest()
        {
            Assert.AreEqual(Register.Registration("orel", "11111", UserId_Orel), false);
        }

    }
}
