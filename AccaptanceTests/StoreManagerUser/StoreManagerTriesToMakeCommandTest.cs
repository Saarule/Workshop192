using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using ServiceLayer.Store_Owner_User;
using ServiceLayer.SystemInitializtion;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace AccaptanceTests.StoreManagerUser
{
    [TestFixture]
    public class StoreManagerTriesToMakeCommandTest
    {
        int UserId_Orel;
        int UserId_Saar;
        bool[] Privileges1 = { true, false, true, true, true, true,true};

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            Register.Registration("saar", "123456", UserId_Saar);
            LogIn.Login("saar", "123456", UserId_Saar);

            OpenStore.openStore("Victory", UserId_Orel);
            AssignStoreManager.AsssignManager(UserId_Orel,"Victory","saar", Privileges1);
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [Test]
        public void PermittedCommandTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Saar, -1,"Milki","dairy products",10,50,"Victory","add"),true);
        }
        [Test]
        public void NotPermittedCommandTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Saar, -1, "Milki", "dairy products", 10, 50, "Victory", "add"),true);
            Assert.AreEqual(ManageProducts.ManageProduct(UserId_Saar, 1, "Milki", "dairy products", 10, 50, "Victory", "delete"), false);
        }
        
    }
}
