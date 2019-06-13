using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Admin;
using ServiceLayer.Guest;
using System;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.Admin
{
    [TestFixture]
    public class RemoveUserFromSystemTest
    {
        int UserId_Orel;
        int UserId_Nati;
        int UserId_Admin;
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);

            UserId_Admin = CreateAndGetUser.CreateUser();
            LogIn.Login("admin", "admin11",UserId_Admin);
            
            UserId_Orel = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "123456",UserId_Orel);
            UserId_Nati = CreateAndGetUser.CreateUser();
            Register.Registration("nati", "123456", UserId_Nati);
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [Test]
        public void SuccessRemoveTest() // NULL in case that GetUser(username,password) not exist ( == null) 
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(UserId_Admin,"orel"),true);
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(UserId_Admin,"nati"),true);
        }
        [Test]
        public void NotAdminRemoveTest()
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(UserId_Orel,"nati"), false);
        }
        [Test]
        public void RemoveNotExistedTest() 
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(UserId_Admin,"ben"), false);
        }
        [Test]
        public void DoubleRemoveTest() 
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(UserId_Admin,"orel"), true);
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(UserId_Admin, "orel"), false);

        }
        
    }
}
