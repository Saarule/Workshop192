using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace UnitTestProject1
{
    [TestClass]
    public class CartTests
    {
        //Use Case 4.1
        [TestMethod]
        public void AddProductTest()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.AddUser("user1", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
            User user = system.GetUser("user1", "12345");
            StoreOwner storeOwner = user.GetStores().First.Value;

            Product product1 = new Workshop192.MarketManagment.Product(1,100,"product");
            storeOwner.AddProduct(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);
            Product product2 = new Workshop192.MarketManagment.Product(2, 100, "product2");
            storeOwner.AddProduct(product2);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 2);

            system = null;
        }

        [TestMethod]
        public void RemoveProductTest()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.AddUser("user3", "12345");
            system.OpenStore("myStore", system.GetUser("user3", "12345"));
            User user = system.GetUser("user3", "12345");
            StoreOwner storeOwner = user.GetStores().First.Value;

            Product product1 = new Workshop192.MarketManagment.Product(1, 100, "product");
            storeOwner.AddProduct(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);

            Product product2 = new Workshop192.MarketManagment.Product(2, 100, "product2");
            storeOwner.AddProduct(product2);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 2);

            storeOwner.RemoveProduct(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);

            storeOwner.RemoveProduct(product2);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 0);

            system = null;

        }

        [TestMethod]
        public void EditProduct()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.AddUser("user4", "12345");
            system.OpenStore("myStore2", system.GetUser("user4", "12345"));
            User user = system.GetUser("user4", "12345");
            StoreOwner storeOwner = user.GetStores().First.Value;

            Product product1 = new Workshop192.MarketManagment.Product(1, 100, "product");
            storeOwner.AddProduct(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);

            Product product2 = new Workshop192.MarketManagment.Product(2, 100, "product2");
            storeOwner.AddProduct(product2);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 2);

            Product product3 = new Workshop192.MarketManagment.Product(2, 100, "product3");
            storeOwner.EditProduct(product1, product3);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Contains(product3));


            system = null;

        }

    }
}
