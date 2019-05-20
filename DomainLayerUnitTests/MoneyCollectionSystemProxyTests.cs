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
            Assert.IsTrue(proxy.CollectFromAccount(6, 500));
        }

        [Test]
        public void CollectFromAccount_NotConnectedToRealMoneyCollectionSystem_ReturnsFalse()
        {
            proxy = new MoneyCollectionSystemProxy(null);
            Assert.IsFalse(proxy.CollectFromAccount(6, 500));
        }
    }
}
