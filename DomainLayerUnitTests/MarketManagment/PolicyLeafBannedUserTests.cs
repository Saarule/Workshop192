using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Workshop192;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class PolicyLeafBannedUserTests
    {
        private PolicyLeafBannedUser policy;
        private Cart cart;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().RegisterUser("user", "123456");
            cart = new Cart(new Store("store"), new MultiCart(1));
        }

        [Test]
        public void Validate_UserNotLoggedInBanned_ReturnsFalse()
        {
            policy = new PolicyLeafBannedUser("", 0, "");
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_UserNotLoggedInNotBanned_ReturnsTrue()
        {
            policy = new PolicyLeafBannedUser("user", 0, "");
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_UserLoggedInNotBanned_ReturnsTrue()
        {
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(1).LogIn(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo("user"));
            policy = new PolicyLeafBannedUser("user2", 0, "");
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
