using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceLayer.SystemInitializtion;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using ServiceLayer.RegisteredUser;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class ManagePoliciesTest
    {
        int UserId_Orel;
        int UserId_Nati;
        [SetUp]
        public void SetUp()
        {

            InitializationOfTheSystem System = new InitializationOfTheSystem();
            System.Initalize(null);
            UserId_Orel = CreateAndGetUser.CreateUser();
            Register.Registration("orel", "123456", UserId_Orel);
            UserId_Nati = CreateAndGetUser.CreateUser();
            Register.Registration("nati", "123456", UserId_Nati);
            LogIn.Login("orel", "123456", UserId_Orel);
            OpenStore.openStore("Victory", UserId_Orel);


        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [Test]
        public void AddSellingPolicyTest()
        {
            LinkedList<string> toAdd = new LinkedList<string>();
            toAdd.AddLast("Ban");
            toAdd.AddLast("AND");
            toAdd.AddLast("0");
            toAdd.AddLast("nati");
            Assert.True(ManagePolicies.AddBuyingPolicy(toAdd, "Victory", UserId_Orel));
        }
        [Test]
        public void AddDiscountTest()
        {
            LinkedList<string> toAdd = new LinkedList<string>();
            toAdd.AddLast("Min");
            toAdd.AddLast("AND");
            toAdd.AddLast("0");
            toAdd.AddLast("0");
            toAdd.AddLast("2");
            Assert.True(ManagePolicies.AddDiscountPolicy(toAdd, "Victory", 20, UserId_Orel));
        }
    }
}
