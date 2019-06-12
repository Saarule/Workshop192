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

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class RemoveStoreManagerTest
    {
        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;
        int UserId_Ben;


        bool[] Privileges1 = { true, true, true, true, true, true };
        bool[] Privileges2 = { true, true, true, true, true, true };


        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize();
            UserId_Nati = CreateAndGetUser.CreateUser();
            UserId_Orel = CreateAndGetUser.CreateUser();
            UserId_Saar = CreateAndGetUser.CreateUser();
            UserId_Ben = CreateAndGetUser.CreateUser();

            Register.Registration("orel", "Orelp", UserId_Orel);
            LogIn.Login("orel", "Orelp", UserId_Orel);
            Register.Registration("saar", "Saarp", UserId_Saar);
            LogIn.Login("saar", "Saarp", UserId_Saar);
            Register.Registration("nati", "Natip", UserId_Nati);
            OpenStore.openStore("Victory", UserId_Orel);

            AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "saar",Privileges1);
            AssignStoreManager.AsssignManager(UserId_Orel, "Victory", "nati",Privileges2);
           
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
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "saar"), true);

        }
        [Test]
        public void Remove_NotExisted_Child_Test()
        {//when the system check if the username exist -if not it returns null->null reference
            
            Register.Registration("ben", "Benp", UserId_Ben);
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory","ben"), false);
        }
        [Test]
        public void Remove_Grandson_Test()
        {
            Register.Registration("ben", "Benp", UserId_Ben);

            Assert.AreEqual( AssignStoreManager.AsssignManager(UserId_Saar,"Victory","ben",Privileges2),true);

            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel,"Victory", "ben"), false);
        }
        [Test]
        public void DoubleRemoveTest()
        {
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel,"Victory", "saar"), true);
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "saar"), false);
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(RemoveStoreManager.removeStoreManager(UserId_Orel, "Victory", "nati"), false);
        }
    }
}
