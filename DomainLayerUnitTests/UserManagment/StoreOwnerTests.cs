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

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            int user_1= AllRegisteredUsers.GetInstance().CreateUser();
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
            user1.OpenStore("store", user_1);
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

        [Test]
        public void RemoveProductFromInventory_RemoveExistingProduct_ReturnsTrue()
        {
            Product product = new Product(1, "", "", 1);
            user1.AddProducts("store", product, 1);
            Assert.IsTrue(user1.RemoveProductFromInventory("store", 1));
            Assert.AreEqual(0, Workshop192.MarketManagment.System.GetInstance().GetStore("store").inventory.Count);
        }

        [Test]
        public void RemoveProductFromInventory_RemoveNonExistingProduct_ReturnsFalse()
        {
            Product product = new Product(1, "", "", 1);
            user1.AddProducts("store", product, 1);
            user1.RemoveProductFromInventory("store", 1);
            Assert.Throws<ErrorMessageException>(() => user1.RemoveProductFromInventory("store", 1));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            AllRegisteredUsers.Reset();
            Workshop192.MarketManagment.System.Reset();
        }
    }
}
