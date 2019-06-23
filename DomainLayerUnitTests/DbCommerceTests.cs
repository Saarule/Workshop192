using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;
using Workshop192.MarketManagment;

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
            allUsers.RegisterUser("User1", "123456");
            allUsers.RegisterUser("User2", "123456");
            allUsers.RegisterUser("User3", "123456");
            allUsers.RegisterUser("User4", "123456");
            allUsers.GetUserInfo("User1").SetAdmin();
            allUsers.GetUserInfo("User1").OpenStore("Store");
            allUsers.GetUserInfo("User1").AddStoreOwner("Store", allUsers.GetUserInfo("User2"));
            allUsers.GetUserInfo("User1").AddStoreOwner("Store", allUsers.GetUserInfo("User3"));
            allUsers.GetUserInfo("User2").AcceptOwner("Store", allUsers.GetUserInfo("User3"));
            allUsers.GetUserInfo("User1").AddStoreManager("Store", allUsers.GetUserInfo("User4"), new bool[7]);
            allUsers.GetUserInfo("User1").AddProducts("Store", new Product(1, "p1", "c1", 5), 5);
            allUsers.GetUserInfo("User2").RemoveProductFromInventory("Store", 1);
            allUsers.GetUserInfo("User3").AddProducts("Store", new Product(2, "p2", "c2", 5), 5);
            allUsers.GetUserInfo("User1").EditProduct("Store", 2, "p2e", "c2e", 6, 7);
            allUsers.GetUserInfo("User2").OpenStore("Store2");
            allUsers.GetUserInfo("User2").AddProducts("Store2", new Product(3, "p3", "c3", 5), 5);
            allUsers.GetUserInfo("User2").AddProducts("Store2", new Product(4, "p4", "c4", 5), 5);
            Workshop192.UserManagment.User user = new Workshop192.UserManagment.User();
            user.LogIn(allUsers.GetUserInfo("User4"));
            user.AddProductsToMultiCart("Store", 2, 3);
            user.AddProductsToMultiCart("Store", 2, 1);
            user.AddProductsToMultiCart("Store2", 3, 4);
            user.AddProductsToMultiCart("Store2", 4, 2);
            LinkedList<string> policy = new LinkedList<string>();
            policy.AddLast("Ban");
            policy.AddLast("AND");
            policy.AddLast("0");
            policy.AddLast("User4");
            allUsers.GetUserInfo("User1").AddSellingPolicy("Store", policy);
            //Workshop192.MarketManagment.System.GetInstance().ResetMultiCart(4);
        }
    }
}
