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
            truePolicy = new PolicyLeafBannedUser("user");
            falsePolicy = new PolicyLeafBannedUser("");
        }

        [Test]
        public void Validate_ValidateOrComposite_ReturnsTrue()
        {
            Assert.IsFalse((new PolicyCompositeOr(falsePolicy, falsePolicy)).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeOr(falsePolicy, truePolicy)).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeOr(truePolicy, falsePolicy)).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeOr(truePolicy, truePolicy)).Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateXorComposite_ReturnsTrue()
        {
            Assert.IsFalse((new PolicyCompositeXor(falsePolicy, falsePolicy)).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeXor(falsePolicy, truePolicy)).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeXor(truePolicy, falsePolicy)).Validate(1, cart));
            Assert.IsFalse((new PolicyCompositeXor(truePolicy, truePolicy)).Validate(1, cart));
        }

        [Test]
        public void Validate_ValidateAndComposite_ReturnsTrue()
        {
            Assert.IsFalse((new PolicyCompositeAnd(falsePolicy, falsePolicy)).Validate(1, cart));
            Assert.IsFalse((new PolicyCompositeAnd(falsePolicy, truePolicy)).Validate(1, cart));
            Assert.IsFalse((new PolicyCompositeAnd(truePolicy, falsePolicy)).Validate(1, cart));
            Assert.IsTrue((new PolicyCompositeAnd(truePolicy, truePolicy)).Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
