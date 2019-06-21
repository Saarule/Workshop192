using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using Workshop192.UserManagment;
using ServiceLayer.SystemInitializtion;
using ServiceLayer.Store_Owner_User;
using Workshop192;
using System.Collections.Generic;

namespace AccaptanceTests.RegisteredUser
{
    [TestFixture]
    public class GetRolesTest
    {
        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "123456", UserId_Orel);
            Register.Registration("nati", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            Register.Registration("saar", "12345123", UserId_Saar);
            OpenStore.openStore("Victory", UserId_Orel);
            AssignStoreManager.AsssignManager(UserId_Orel,"Victory","saar",new bool[] { true, true, true, true, true, true, true});
            AssignStoreManager.AsssignManager(UserId_Orel,"Victory","nati",new bool[] { true, true, true, true, true, true, true});
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [Test]
        public void SuccessGetRolesTest()
        {
            LinkedList<LinkedList<string>> x = GetRoles.GetRolesOfStore("Victory");
            Assert.NotNull(x);
            int c = 1;
        }
        
    }
}
