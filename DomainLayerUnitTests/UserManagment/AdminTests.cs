using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;
using Workshop192;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class AdminTests
    {
        Admin admin;
        UserInfo user1, user2, user3;

        [SetUp]
        public void SetUp()
        {
            AllRegisteredUsers.GetInstance().RegisterUser("admin", "admin12");
            admin = new Admin(AllRegisteredUsers.GetInstance().GetUserInfo("admin"));
            AllRegisteredUsers.GetInstance().RegisterUser("asd", "12345567");
            AllRegisteredUsers.GetInstance().RegisterUser("asdf", "111111111");
            AllRegisteredUsers.GetInstance().RegisterUser("qwe", "111222434");
            user1 = AllRegisteredUsers.GetInstance().GetUserInfo("asd");
            user2 = AllRegisteredUsers.GetInstance().GetUserInfo("asdf");
            user3 = AllRegisteredUsers.GetInstance().GetUserInfo("qwe");
            user1.OpenStore("tmp");
            user1.AddStoreManager("tmp", user2, new bool[7]);
            user1.AddStoreOwner("tmp", user3);
        }

        [Test]
        public void RemoveUser_FullyRemoveUser_ReturnsTrue()
        {
            admin.RemoveUser(user1);
            Assert.AreEqual(0, user1.GetStoreOwners().Count);
            Assert.AreEqual(0, user2.GetStoreManagers().Count);
            Assert.AreEqual(1, user3.GetStoreOwners().Count);
        }

        [Test]
        public void MakeAdmin_MakeUserAdmin_ReturnsTrue()
        {
            Assert.IsTrue(admin.MakeAdmin(user1));
            Assert.IsTrue(user1.IsAdmin());
        }

        [Test]
        public void MakeAdmin_UserAlreadyAdmin_ReturnsFalse()
        {
            admin.MakeAdmin(user1);
            Assert.Throws<ErrorMessageException>(() => admin.MakeAdmin(user1));
            Assert.IsTrue(user1.IsAdmin());
        }

        [TearDown]
        public void TearDown()
        {
            AllRegisteredUsers.Reset();
            Workshop192.MarketManagment.System.Reset();
        }
    }
}
