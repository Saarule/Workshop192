using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class PolicyLeafUserNameTests
    {
        PolicyLeafUserName policy;
        Cart cart;

        [SetUp]
        public void SetUp()
        {
            Store store = new Store("Temp Store");
            cart = new Cart(store);
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
        }

        [Test]
        public void Validate_NotLoggedInPolicy_ReturnsTrue()
        {
            policy = new PolicyLeafUserName("", "==");
            Assert.IsTrue(policy.Validate(1, cart));
        }


        [Test]
        public void Validate_NotLoggedInPolicy_ReturnsFalse()
        {
            policy = new PolicyLeafUserName("", "!=");
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_NotLoggedInPolicyNotEqual_ReturnsFalse()
        {
            policy = new PolicyLeafUserName("user", "==");
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_NotLoggedInPolicyNotEqual_ReturnsTrue()
        {
            policy = new PolicyLeafUserName("user", "!=");
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_LoggedInPolicy_ReturnsTrue()
        {
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().RegisterUser("user", "123456");
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(1).LogIn(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo("user"));
            policy = new PolicyLeafUserName("user", "==");
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_LoggedInPolicy_ReturnsFalse()
        {
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().RegisterUser("user", "123456");
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(1).LogIn(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo("user"));
            policy = new PolicyLeafUserName("user", "!=");
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
