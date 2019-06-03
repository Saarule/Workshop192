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
    class ProductTests
    {
        Product product;

        [SetUp]
        public void SetUp()
        {
            product = new Product(1, "cake", "food", 12);
        }

        [Test]
        public void EditProduct_SuccesfulyEditProduct_ReturnsTrue()
        {
            Assert.AreEqual("cake", product.GetName());
            Assert.AreEqual("food", product.GetCategory());
            Assert.AreEqual(12, product.GetPrice());
            product.EditProduct("cheese cake", "good food", 15);
            Assert.AreEqual("cheese cake", product.GetName());
            Assert.AreEqual("good food", product.GetCategory());
            Assert.AreEqual(15, product.GetPrice());
        }
    }
}
