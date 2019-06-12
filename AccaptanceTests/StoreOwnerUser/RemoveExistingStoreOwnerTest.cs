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
    public class RemoveExistingStoreOwnerTest
    {

        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;
        int UserId_Ben;


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
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "Victory", "saar");
            AssignStoreOwner.assignStoreOwner(UserId_Orel,"Victory", "nati");
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
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel,"Victory","nati"), true);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel,"Victory", "saar"), true);

        }
        [Test]
        public void Remove_NotExisted_Child_Test()
        {//when the system check if the username exist -if not it returns null->null reference
            
            Register.Registration("ben", "Benp", UserId_Ben);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel,"Victory","ben"), false);
        }
        [Test]
        public void Remove_Grandson_Test()
        {
            
            Register.Registration("ben", "Benp", UserId_Ben);
            
            AssignStoreOwner.assignStoreOwner(UserId_Saar, "victory", "ben");

            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel, "Victory", "ben"), false);
        }
        [Test]
        public void DoubleRemoveTest()
        {
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel, "Victory", "saar"), true);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel, "Victory", "saar"), false);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel, "Victory", "nati"), true);
            Assert.AreEqual(RemoveExistingStoreOwner.RemoveStoreOwner(UserId_Orel, "Victory", "nati"), false);



        }


    }
}
