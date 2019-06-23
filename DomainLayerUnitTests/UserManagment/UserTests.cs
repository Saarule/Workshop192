using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using Workshop192;

namespace DomainLayerUnitTests.UserManagment
{
    [TestFixture]
    class UserTests
    {
        private User user;
        private UserInfo info;
        int userId;
        [SetUp]
        public void Init()
        {
            userId = AllRegisteredUsers.GetInstance().CreateUser(); 
            DbCommerce.GetInstance().StartTests();
            AllRegisteredUsers.GetInstance().CreateUser();
            user = AllRegisteredUsers.GetInstance().GetUser(1);
            AllRegisteredUsers.GetInstance().RegisterUser("user", "123456");
            info = AllRegisteredUsers.GetInstance().GetUserInfo("user");
        }

        [Test]
        public void LogIn_UserNotLoggedIn_ReturnsTrue()
        {
            Assert.IsTrue(user.LogIn(info));
            Assert.IsNotNull(user.GetInfo());
        }

        [Test]
        public void LogIn_UserAlreadyLoggedIn_ReturnsFalse()
        {
            user.LogIn(info);
            Assert.Throws<ErrorMessageException>(() => user.LogIn(info));
            Assert.IsNotNull(user.GetInfo());
        }

        [Test]
        public void LogOut_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.LogOut());
            Assert.IsNull(user.GetInfo());
        }

        [Test]
        public void LogOut_UserLoggedIn_ReturnsTrue()
        {
            user.LogIn(info);
            Assert.IsTrue(user.LogOut());
            Assert.IsNull(user.GetInfo());
        }

        [Test]
        public void MakeAdmin_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.MakeAdmin(null));
        }

        [Test]
        public void OpenStore_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.OpenStore("temp",userId));
        }

        [Test]
        public void AddProducts_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.AddProducts("temp", new Product(1, "", "", 1), 5));
        }

        [Test]
        public void RemoveProductFromInventory_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.RemoveProductFromInventory("temp", 1));
        }

        [Test]
        public void EditProduct_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.EditProduct("", 1, "", "", 1, 1));
        }

        [Test]
        public void AddStoreOwner_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.AddStoreOwner("", null));
        }

        [Test]
        public void AcceptOwner_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.AcceptOwner("", null));
        }

        [Test]
        public void DeclineOwner_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.DeclineOwner("", null));
        }

        [Test]
        public void AddDiscountPolicy_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.AddDiscountPolicy("", new LinkedList<string>(), 10));
        }

        [Test]
        public void AddSellingPolicy_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.AddSellingPolicy("", new LinkedList<string>()));
        }

        [Test]
        public void RemoveDiscountPolicy_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.RemoveDiscountPolicy("", 1));
        }

        [Test]
        public void RemoveSellingPolicy_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.RemoveSellingPolicy("", 1));
        }

        [Test]
        public void AddStoreManager_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.AddStoreManager("", null, new bool[7]));
        }

        [Test]
        public void RemoveStoreManager_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.RemoveStoreManager("", null));
        }

        [Test]
        public void AddProductsToMultiCart_SuccesfullyAddProducts_ReturnsTrue()
        {
            Store store1, store2;
            Product product1, product2, product3;
            MultiCart multiCart;
            product1 = new Product(1, "", "", 1);
            product2 = new Product(2, "", "", 5);
            product3 = new Product(3, "", "", 10);
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store1");
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store2");
            store1 = Workshop192.MarketManagment.System.GetInstance().GetStore("store1");
            store2 = Workshop192.MarketManagment.System.GetInstance().GetStore("store2");
            store1.AddProducts(product1, 5);
            store1.AddProducts(product2, 5);
            store2.AddProducts(product3, 5);
            Assert.IsTrue(user.AddProductsToMultiCart("store1", 1, 1));
            Assert.IsTrue(user.AddProductsToMultiCart("store1", 1, 1));
            Assert.IsTrue(user.AddProductsToMultiCart("store1", 2, 1));
            Assert.IsTrue(user.AddProductsToMultiCart("store2", 3, 1));
            multiCart = Workshop192.MarketManagment.System.GetInstance().GetMultiCart(user.GetMultiCart());
            Assert.AreEqual(2, multiCart.GetCarts().Count);
            Assert.AreEqual(2, multiCart.GetCarts().First.Value.GetProducts().Count);
            Assert.AreEqual(1, multiCart.GetCarts().Last.Value.GetProducts().Count);
            Assert.AreEqual(2, multiCart.GetCarts().First.Value.GetProducts()[product1]);
            Assert.AreEqual(1, multiCart.GetCarts().First.Value.GetProducts()[product2]);
            Assert.AreEqual(1, multiCart.GetCarts().Last.Value.GetProducts()[product3]);
        }

        [Test]
        public void RemoveProductFromCart_SuccesfullyAddProducts_ReturnsTrue()
        {
            Store store1, store2;
            Product product1, product2, product3;
            MultiCart multiCart;
            product1 = new Product(1, "", "", 1);
            product2 = new Product(2, "", "", 5);
            product3 = new Product(3, "", "", 10);
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store1");
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store2");
            store1 = Workshop192.MarketManagment.System.GetInstance().GetStore("store1");
            store2 = Workshop192.MarketManagment.System.GetInstance().GetStore("store2");
            store1.AddProducts(product1, 5);
            store1.AddProducts(product2, 5);
            store2.AddProducts(product3, 5);
            user.AddProductsToMultiCart("store1", 1, 1);
            user.AddProductsToMultiCart("store1", 2, 1);
            user.AddProductsToMultiCart("store2", 3, 1);
            Assert.IsTrue(user.RemoveProductFromCart(1));
            Assert.IsTrue(user.RemoveProductFromCart(3));
            multiCart = Workshop192.MarketManagment.System.GetInstance().GetMultiCart(user.GetMultiCart());
            Assert.AreEqual(1, multiCart.GetCarts().Count);
            Assert.AreEqual("store1", multiCart.GetCarts().First.Value.GetStore().GetName());
        }

        [Test]
        public void LogIn_ChangeMultiCartToLoggedInUserCart_ReturnsTrue()
        {
            Workshop192.MarketManagment.System.GetInstance().OpenStore("store");
            Workshop192.MarketManagment.System.GetInstance().GetStore("store").AddProducts(new Product(1, "", "", 1), 5);
            user.LogIn(info);
            user.AddProductsToMultiCart("store", 1, 3);
            user.LogOut();
            Assert.AreEqual(0, Workshop192.MarketManagment.System.GetInstance().GetMultiCart(user.GetMultiCart()).GetCarts().Count);
            user.LogIn(info);
            Assert.AreEqual(1, Workshop192.MarketManagment.System.GetInstance().GetMultiCart(user.GetMultiCart()).GetCarts().Count);
        }

        [Test]
        public void RemoveUser_UserNotLoggedIn_ReturnsFalse()
        {
            Assert.Throws<ErrorMessageException>(() => user.RemoveUser(null));
        }

        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            Workshop192.MarketManagment.System.Reset();
            AllRegisteredUsers.Reset();
        }
    }
}
