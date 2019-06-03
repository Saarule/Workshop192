﻿using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Admin;
using ServiceLayer.Guest;
using System;
using Workshop192.UserManagment;

namespace AccaptanceTests.Admin
{
    [TestFixture]
    public class RemoveUserFromSystemTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        User Admin;
        User NotRegisteredUser;
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Admin = new User();
            NotRegisteredUser = new User();

            Register.Registration("orel", "123456", Orel);
            Register.Registration("nati", "12345", Nati);
            LogIn.Login("orel", "123456",Orel);
            LogIn.Login("admin", "admin", Admin);
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void SuccessRemoveTest() // NULL in case that GetUser(username,password) not exist ( == null) 
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(Admin, System.GetUser("nati", "12345")),true);
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(Admin, System.GetUser("orel", "123456")), true);
        }
        [Test]
        public void NotAdminRemoveTest()
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(Orel, System.GetUser("nati", "12345")), false);
        }
        [Test]
        public void RemoveNotExistedTest() 
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(Admin, NotRegisteredUser.GetInfo()), false);
        }
        [Test]
        public void DoubleRemoveTest() 
        {
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(Admin, System.GetUser("orel", "123456")), true);
            Assert.AreEqual(RemoveUserFromSystem.RemoveUser(Admin, System.GetUser("orel", "123456")), false);

        }
        
    }
}
