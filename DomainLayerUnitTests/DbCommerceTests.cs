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
    class DbCommerceTests
    {
        private Workshop192.UserManagment.AllRegisteredUsers allUsers;

        [SetUp]
        public void SetUp()
        {
            allUsers = Workshop192.UserManagment.AllRegisteredUsers.GetInstance();
        }

        [Test]
        public void DbCommerceTest()
        {

        }
    }
}
