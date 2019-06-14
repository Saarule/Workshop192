using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;
using Workshop192.MarketManagment;
using Workshop192;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class StoreOwnerTests
    {
        private User user1, user2, user3;
        private StoreOwner storeOwner1, storeOwner2, storeOwner3;

        [SetUp]
        public void SetUp()
        {
            AllRegisteredUsers.GetInstance().CreateUser();
            AllRegisteredUsers.GetInstance().CreateUser();
            AllRegisteredUsers.GetInstance().CreateUser();
            user1 = AllRegisteredUsers.GetInstance().GetUser(1);
            user2 = AllRegisteredUsers.GetInstance().GetUser(2);
            user3 = AllRegisteredUsers.GetInstance().GetUser(3);
            AllRegisteredUsers.GetInstance().RegisterUser("user1", "1234567");
            AllRegisteredUsers.GetInstance().RegisterUser("user2", "1234567");
            AllRegisteredUsers.GetInstance().RegisterUser("user3", "1234567");
            user1.LogIn(AllRegisteredUsers.GetInstance().GetUserInfo("user1"));
            user2.LogIn(AllRegisteredUsers.GetInstance().GetUserInfo("user2"));
            user3.LogIn(AllRegisteredUsers.GetInstance().GetUserInfo("user3"));
            user1.OpenStore("store");
        }

        [Test]
        public void AddProducts_AddNewProduct_ReturnsTrue()
        {
            Assert.IsTrue(user1.AddProducts("store", new Product(1, "", "", 1), 1));
            Assert.AreEqual(1, Workshop192.MarketManagment.System.GetInstance().GetStore("store").GetInventory().Count);
        }

        [Test]
        public void AddProducts_AddExistingProduct_ReturnsFalse()
        {
            Product product = new Product(1, "", "", 1);
            user1.AddProducts("store", product, 1);
            Assert.Throws<ErrorMessageException>(() => user1.AddProducts("store", product, 1));
            Assert.AreEqual(1, Workshop192.MarketManagment.System.GetInstance().GetStore("store").GetInventory().Count);
        }

        [TearDown]
        public void TearDown()
        {
            AllRegisteredUsers.Reset();
            Workshop192.MarketManagment.System.Reset();
        }
    }
}
