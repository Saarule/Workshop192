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
    class SecurityTests
    {
        private Security security;

        [SetUp]
        public void SetUp()
        {
            security = new Security();
            security.AddUser("Ben", "12345");
        }

        [Test]
        public void AddUser_AddNewUser_ReturnsTrue()
        {
            Assert.IsTrue(security.AddUser("newGuy", "111111"));
            Assert.IsTrue(security.ValidatePassword("newGuy", "111111"));
        }

        [Test]
        public void AddUser_AddExistingUser_ReturnsFalse()
        {
            Assert.IsFalse(security.AddUser("Ben", "111111"));
        }

        [Test]
        public void ValidatePassword_ValidateCorrectPassword_ReturnsTrue()
        {
            Assert.IsTrue(security.ValidatePassword("Ben", "12345"));
        }

        [Test]
        public void ValidatePassword_ValidateIncorrectPassword_ReturnsFalse()
        {
            Assert.IsFalse(security.ValidatePassword("Ben", "1234567"));
        }

        [Test]
        public void RemoveUser_RemoveExistingUser_ReturnsTrue()
        {
            Assert.IsTrue(security.RemoveUser("Ben"));
            Assert.IsFalse(security.ValidatePassword("Ben", "12345"));
        }

        [Test]
        public void RemoveUser_RemoveNonExistingUser_ReturnsFalse()
        {
            Assert.IsFalse(security.RemoveUser("newGuy"));
        }
    }
}
