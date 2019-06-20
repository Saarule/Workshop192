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
using Workshop192;

namespace AccaptanceTests.StoreOwnerUser
{
    [TestFixture]
    public class GetPoliciesOfStoreTest
    {
        int UserId_Orel;
        int UserId_Nati;
        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();

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
            DbCommerce.GetInstance().EndTests();
            SystemReset.Reset();
        }
        [Test]
        public void DisplaySellingPolicyTest()
        { 
            LinkedList<string> toAdd = new LinkedList<string>();
            toAdd.AddLast("Ban");
            toAdd.AddLast("AND");
            toAdd.AddLast("0");
            toAdd.AddLast("nati");
            ManagePolicies.AddBuyingPolicy(toAdd, "Victory", UserId_Orel);
            Assert.NotNull( GetPolicies.GetPoliciesOfStore("Victory"));
        }
        [Test]
        public void DisplayDiscountTest()
        {
            LinkedList<string> toAdd = new LinkedList<string>();
            toAdd.AddLast("Min");
            toAdd.AddLast("AND");
            toAdd.AddLast("0");
            toAdd.AddLast("0");
            toAdd.AddLast("2");
            ManagePolicies.AddDiscountPolicy(toAdd,"Victory", 20 , UserId_Orel);

            Assert.NotNull(GetPolicies.GetPoliciesOfStore("Victory"));
        }
    }
}
