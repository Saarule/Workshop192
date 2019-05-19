using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace AccaptanceTests.StoreManagerUser
{
    [TestFixture]
    public class StoreManagerTriesToMakeCommandTest
    {
        Workshop192.System System = null;
        User Orel;
        User Saar;
        Product p1;
        Product p2;
        bool[] Privileges1 = { true, false, true, true, true, true };
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Saar = new User();
            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            Register.Registration("saar", "123456", Saar);
            LogIn.Login("saar", "123456", Saar);

            System.OpenStore("Victory", Orel.GetState());
            AssignStoreManager.AsssignManager(Orel, System.GetStore("Victory"), "saar", Privileges1);
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void SuccessCommandTest()
        {
            Assert.AreEqual(ManageProducts.ManageProduct(Saar, new Product(1, 10, "milk"), System.GetStore("Victory"), "add"),true);
        }
        [Test]
        public void SuccessCommandTest2()
        {
           ManageProducts.ManageProduct(Saar, new Product(1, 10, "milk"), System.GetStore("Victory"), "add");

            Assert.AreEqual(ManageProducts.ManageProduct(Saar, new Product(1, 10, "milk"), System.GetStore("Victory"), "remove"), false);
        }
        
    }
}
