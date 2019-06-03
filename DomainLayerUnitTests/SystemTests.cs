using System;
using NUnit.Framework;
using Workshop192;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests
{
    
    [TestFixture]
    public class SystemTests
    {
        private Workshop192.MarketManagment.System system;
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