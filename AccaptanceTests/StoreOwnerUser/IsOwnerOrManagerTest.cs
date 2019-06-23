using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using ServiceLayer.RegisteredUser;
using ServiceLayer.SystemInitializtion;
using Workshop192;

namespace AccaptanceTests.StoreOwnerUser
{
    /*[TestFixture]
    public class IsOwnerOrManagerTest
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
            Register.Registration("nati", "123456", UserId_Nati);
            Register.Registration("saar", "123456", UserId_Saar);
            LogIn.Login("orel", "123456", UserId_Orel);
            LogIn.Login("nati", "123456", UserId_Nati);
            OpenStore.openStore("victory", UserId_Orel);

        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }

        [Test]
        public void IsOwnerTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "saar");
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Orel),true);
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Nati),true);
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Nati),true);
        }
        [Test]
        public void IsNotOwnerTest()
        {
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Orel), true);
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Nati), false);
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Nati), false);
        }
        [Test]
        public void IsManagerTest()
        {
            AssignStoreManager.AsssignManager(UserId_Orel, "victory", "nati", new bool[] { true, true, true, true, true, true, true });
            AssignStoreManager.AsssignManager(UserId_Orel, "victory", "saar", new bool[] { true, true, true, true, true, true, true });
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Nati), false);
            Assert.AreEqual(IsOwnerOrManage.IsOwner(UserId_Nati), false);
        }
        [Test]
        public void IsNotManagerTest()
        {
            Assert.AreEqual(IsOwnerOrManage.IsManager(UserId_Orel), false);
            Assert.AreEqual(IsOwnerOrManage.IsManager(UserId_Nati), false);
            Assert.AreEqual(IsOwnerOrManage.IsManager(UserId_Nati), false);
        }
        
    }*/
}
