using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using ServiceLayer.RegisteredUser;
using ServiceLayer.SystemInitializtion;
using Workshop192;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class RemoveStoreManagerTest
    {
        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;
        int UserId_Ben;


        bool[] Privileges1 = { true, true, true, true, true, true,true };


        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();
            UserId_Ben = CreateAndGetUser.CreateUser();

            Register.Registration("orel", "123456", UserId_Orel);
            LogIn.Login("orel", "123456", UserId_Orel);
            Register.Registration("saar", "123456", UserId_Saar);
            LogIn.Login("saar", "123456", UserId_Saar);
            Register.Registration("nati", "123456", UserId_Nati);
            OpenStore.openStore("Victory", UserId_Orel);

            AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "saar",Privileges1);
            
           
        }
        [TearDown]
        public void TearDown()
        {
            //TODO
            SystemReset.Reset();//the opposite of initalization of the system        
        }
        [Test]
        public void RemoveChildTest()
        {
            
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "saar"), true);

        }
        [Test]
        public void Remove_NotExisted_Child_Test()
        {//when the system check if the username exist -if not it returns null->null reference
            
            Register.Registration("ben", "123456", UserId_Ben);
            Assert.Throws<ErrorMessageException>(() => RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory","ben"));
        }
        [Test]
        public void Remove_Grandson_Test()
        {
            Register.Registration("ben", "123456", UserId_Ben);
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati");
            LogIn.Login("nati", "123456", UserId_Nati);
            Assert.AreEqual( AssignStoreManager.AsssignManager(UserId_Nati,"Victory","ben",Privileges1),true);

            Assert.Throws<ErrorMessageException>(() => RemoveStoreManager.removeStoreManager(UserId_Orel,"Victory", "ben"));
        }
        [Test]
        public void Remove_Manager_Test2()
        {
            Register.Registration("ben", "123456", UserId_Ben);
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "nati");
            LogIn.Login("nati", "123456", UserId_Nati);
            Assert.AreEqual(AssignStoreManager.AsssignManager(UserId_Nati, "Victory", "ben", Privileges1), true);

            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Nati, "Victory", "ben"), true);
        }
        [Test]
        public void DoubleRemoveTest()
        {
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel,"Victory", "saar"), true);
            Assert.Throws<ErrorMessageException>(() => RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "saar"));
            
        }
    }
}
