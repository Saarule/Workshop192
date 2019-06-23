using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;
using Workshop192.MarketManagment;
using Workshop192;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class StoreManagerTests
    {

        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            AllRegisteredUsers.GetInstance().RegisterUser("User1", "123456");
            AllRegisteredUsers.GetInstance().RegisterUser("User2", "123456");
            AllRegisteredUsers.GetInstance().RegisterUser("User3", "123456");
            AllRegisteredUsers.GetInstance().GetUserInfo("User1").OpenStore("Store");
            AllRegisteredUsers.GetInstance().GetUserInfo("User1").AddStoreManager("Store", AllRegisteredUsers.GetInstance().GetUserInfo("User2"), new bool [] { false, false, false, false, false, false, false });
            AllRegisteredUsers.GetInstance().GetUserInfo("User1").AddStoreManager("Store", AllRegisteredUsers.GetInstance().GetUserInfo("User3"), new bool[] { true, true, true, true, true, true, true });
        }

        [Test]
        public void AddProducts_ManagerHasPrivilege_ReturnsTrue()
        {
            Assert.IsTrue(AllRegisteredUsers.GetInstance().GetUserInfo("User3").GetManager("Store").AddProducts(new Product(1, "", "", 1), 2));
        }

        [Test]
        public void AddProducts_ManagerDosentHavePrivilege_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => AllRegisteredUsers.GetInstance().GetUserInfo("User2").GetManager("Store").AddProducts(new Product(1, "", "", 1), 2));
        }

        [TearDown]
        public void TearDown()
        {
            AllRegisteredUsers.Reset();
            Workshop192.MarketManagment.System.Reset();
            DbCommerce.GetInstance().EndTests();
        }
    }
}
