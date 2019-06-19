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
    class DeliverySystemProxyTests
    {
        private DeliverySystemProxy proxy;
        
        [Test]
        public void Deliver_ConnectedToRealDeliverySystem_ReturnsTrue()
        {
            proxy = new DeliverySystemProxy(new DeliverySystemReal());
            Assert.AreNotEqual(-1, proxy.Deliver("Me", "Here", "", "", 1));
        }

        [Test]
        public void Deliver_NotConnectedToRealDeliverySystem_ReturnsFalse()
        {
            proxy = new DeliverySystemProxy(null);
            Assert.AreEqual(-1, proxy.Deliver("Me", "Here", "", "", 1));
        }
    }
}
