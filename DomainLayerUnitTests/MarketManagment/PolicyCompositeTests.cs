using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;
using Workshop192.MarketManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class PolicyCompositeTests
    {
        PolicyComponent truePolicy;
        PolicyComponent falsePolicy;
        Cart cart;

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            Store store = new Store("Temp Store");
            cart = new Cart(store, new MultiCart(1));
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
            truePolicy = new PolicyLeafBannedUser("user", 0, "");
            falsePolicy = new PolicyLeafBannedUser("", 0, "");
        }

        [Test]
        public void Validate_ValidateOrComposite_ReturnsTrue()
        {
            Assert.IsFalse((new PolicyCompositeOr(falsePolicy, falsePolicy,0,"")).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeOr(falsePolicy, truePolicy, 0, "")).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeOr(truePolicy, falsePolicy, 0, "")).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeOr(truePolicy, truePolicy, 0, "")).Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateXorComposite_ReturnsTrue()
        {
            Assert.IsFalse((new PolicyCompositeXor(falsePolicy, falsePolicy, 0, "")).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeXor(falsePolicy, truePolicy, 0, "")).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeXor(truePolicy, falsePolicy, 0, "")).Validate(1, cart));
            Assert.IsFalse((new PolicyCompositeXor(truePolicy, truePolicy, 0, "")).Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateAndComposite_ReturnsTrue()
        {
            Assert.IsFalse((new PolicyCompositeAnd(falsePolicy, falsePolicy, 0, "")).Validate(1, cart));
            Assert.IsFalse((new PolicyCompositeAnd(falsePolicy, truePolicy, 0, "")).Validate(1, cart));
            Assert.IsFalse((new PolicyCompositeAnd(truePolicy, falsePolicy, 0, "")).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeAnd(truePolicy, truePolicy, 0, "")).Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
