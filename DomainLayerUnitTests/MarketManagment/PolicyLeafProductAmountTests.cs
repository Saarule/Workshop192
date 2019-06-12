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
    class PolicyLeafProductAmountTests
    {
        PolicyLeafProductAmount policy;
        Product product;
        Cart cart;

        [SetUp]
        public void SetUp()
        {
            Store store = new Store("Temp Store");
            cart = new Cart(store);
            product = new Product(1, "fan", "electronics", 25);
            Product tmp = new Product(2, "computer", "electronics", 200);
            store.AddProducts(product, 10);
            store.AddProducts(tmp, 10);
            cart.AddProductsToCart(1, 10);
            cart.AddProductsToCart(2, 10);
            Workshop192.UserManagment.AllRegisteredUsers.GetInstance().CreateUser();
        }

        [Test]
        public void Validate_EqualProductAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(product, "==", 10);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_EqualProductAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(product, "==", 11);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_EqualAllProductsAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(null, "==", 20);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void Validate_EqualAllProductsAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(null, "==", 2);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void NotEqualValidate_ProductAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(product, "!=", 7);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void NotEqualValidate_ProductAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(product, "!=", 10);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void NotEqualValidate_AllProductsAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(null, "!=", 5);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void NotEqualValidate_AllProductsAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(null, "!=", 20);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void LesserValidate_ProductAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(product, "<", 12);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void LesserValidate_ProductAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(product, "<", 8);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void LesserValidate_AllProductsAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(null, "<", 25);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void LesserValidate_AllProductsAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(null, "<", 20);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void LesserEqualValidate_ProductAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(product, "<=", 10);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void LesserEqualValidate_ProductAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(product, "<=", 8);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void LesserEqualValidate_AllProductsAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(null, "<=", 20);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void LesserEqualValidate_AllProductsAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(null, "<=", 5);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterValidate_ProductAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(product, ">", 5);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterValidate_ProductAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(product, ">", 11);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterValidate_AllProductsAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(null, ">", 17);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterValidate_AllProductsAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(null, ">", 26);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterEqualValidate_ProductAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(product, ">=", 10);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterEqualValidate_ProductAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(product, ">=", 11);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterEqualValidate_AllProductsAmountInCart_ReturnsTrue()
        {
            policy = new PolicyLeafProductAmount(null, ">=", 20);
            Assert.IsTrue(policy.Validate(1, cart));
        }

        [Test]
        public void GreaterEqualValidate_AllProductsAmountInCart_ReturnsFalse()
        {
            policy = new PolicyLeafProductAmount(null, ">=", 28);
            Assert.IsFalse(policy.Validate(1, cart));
        }

        [TearDown]
        public void TearDown()
        {
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
