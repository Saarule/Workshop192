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
    [TestFixture]
    public class HandlerRequestAppointmentTest
    {
        int UserId_Nati;
        int UserId_Orel;
        int UserId_Saar;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
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
            DbCommerce.GetInstance().EndTests();
            SystemReset.Reset();        
        }
        [Test]
        public void AcceptOwnerTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "saar");
            Assert.AreEqual(HandlerRequestAppointment.AcceptAppointment("victory",UserId_Nati,"saar") , true);
        }
        [Test]
        public void AcceptOwnerTwiceTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "saar");
            Assert.AreEqual(HandlerRequestAppointment.AcceptAppointment("victory", UserId_Nati, "saar"), true);
            Assert.Throws<ErrorMessageException>(() => HandlerRequestAppointment.AcceptAppointment("victory", UserId_Nati, "saar"));

        }
        [Test]
        public void AcceptOwnerNotExistUserTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            Assert.Throws<ErrorMessageException>(() => HandlerRequestAppointment.AcceptAppointment("victory", UserId_Nati, "dan"));
        }
        [Test]
        public void AcceptOwnerNotExistStoreTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            Assert.Throws<ErrorMessageException>(() => HandlerRequestAppointment.AcceptAppointment("Mega", UserId_Nati, "saar"));
        }
        [Test]
        public void DeclineOwnerTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "saar");
            Assert.AreEqual(HandlerRequestAppointment.DeclineAppointment("victory", UserId_Nati, "saar"), true);
        }
        [Test]
        public void DeclineOwnerTwiceTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "saar");
            Assert.AreEqual(HandlerRequestAppointment.DeclineAppointment("victory", UserId_Nati, "saar"), true);
            Assert.Throws<ErrorMessageException>(() => HandlerRequestAppointment.DeclineAppointment("victory", UserId_Nati, "saar"));
        }
        [Test]
        public void DeclineOwnerNotExistUserTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            Assert.Throws<ErrorMessageException>(() => HandlerRequestAppointment.DeclineAppointment("victory", UserId_Nati, "dan"));
        }
        [Test]
        public void DeclineOwnerNotExistStoreTest()
        {
            AssignStoreOwner.assignStoreOwner(UserId_Orel, "victory", "nati");
            Assert.Throws<ErrorMessageException>(() => HandlerRequestAppointment.DeclineAppointment("Mega", UserId_Nati, "saar"));
        }
    }
}
