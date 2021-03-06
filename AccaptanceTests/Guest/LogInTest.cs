﻿using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;
using Workshop192;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class LogInTest
    {
        int UserId_Nati;
        int UserId_Orel;
        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            //int userIDnati = Allusers.CreateUser();
            Register.Registration("orel", "123456", UserId_Orel);
        }
        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            //TODO
            SystemReset.Reset();//the opposite of initalization of the system
        }
        [Test]
        public void SuccessLoginTest()
        {
            Assert.AreEqual(LogIn.Login("orel", "123456", UserId_Orel), true);
        }
        [Test]
        public void UserNotRegisteredTest()
        {
            Assert.Throws<ErrorMessageException>(() => LogIn.Login("nati", "2222", UserId_Orel));
        }
        [Test]
        public void DoubleLoginTest() // NULL in case that GetUser(username,password) not exist ( == null) 
        {
            Assert.AreEqual(LogIn.Login("orel", "123456", UserId_Orel), true);
            Assert.AreEqual(LogIn.Login("orel", "123456", UserId_Orel), false);
        }
        [Test]
        public void WrongPasswordTest() // NULL in case that GetUser(username,password) not exist ( == null)
        {
            Assert.Throws<ErrorMessageException>(() => LogIn.Login("orel", "111", UserId_Orel));
        }
        [Test]
        public void WrongUsernameTest() // NULL in case that GetUser(username,password) not exist ( == null)
        {
            Assert.Throws<ErrorMessageException>(() => LogIn.Login("ore", "123456", UserId_Orel));
        }

    }
}
