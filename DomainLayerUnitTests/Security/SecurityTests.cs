using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayerUnitTests.Security
{
    [TestFixture]
    class SecurityTests
    {
        [Test]
        public void CheckPasswordSecurity_SecurePassword_ReturnsTrue()
        {
            Assert.IsTrue(Workshop192.Security.Security.CheckPasswordSecurity("123456"));
        }

        [Test]
        public void CheckPasswordSecurity_UnsecurePassword_ReturnsFalse()
        {
            Assert.IsFalse(Workshop192.Security.Security.CheckPasswordSecurity("12d"));
            Assert.IsFalse(Workshop192.Security.Security.CheckPasswordSecurity("asdfqer"));
        }
    }
}
