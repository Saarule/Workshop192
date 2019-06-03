using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class UserTests
    {
        private User user;

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Dispose()
        {
            Workshop192.MarketManagment.System.Reset();
        }
    }
}
