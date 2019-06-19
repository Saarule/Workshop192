using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;

namespace DomainLayerUnitTests
{
    [TestFixture]
    class MoneyCollectionSystemProxyTests
    {
        private MoneyCollectionSystemProxy proxy;

        [Test]
        public void CollectFromAccount_ConnectedToRealMoneyCollectionSystem_ReturnsTrue()
        {
            proxy = new MoneyCollectionSystemProxy(new MoneyCollectionSystemReal());
            Assert.AreNotEqual(-1, proxy.CollectFromAccount(1, 1, 2020, "", 111, 111111));
        }

        [Test]
        public void CollectFromAccount_NotConnectedToRealMoneyCollectionSystem_ReturnsFalse()
        {
            proxy = new MoneyCollectionSystemProxy(null);
            Assert.AreEqual(-1, proxy.CollectFromAccount(1, 1, 2020, "", 111, 111111));
        }
    }
}
