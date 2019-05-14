using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace UnitTestProject1
{
    [TestClass]
    public class CartTests
    {
        Workshop192.System system = Workshop192.System.GetInstance();
        StoreOwner storeOwner;
        Product product1 = new Workshop192.MarketManagment.Product(1, 100, "product");
        Product product2;

        [TestInitialize]
        public void Init()
        {
            system.AddUser("user1", "12345");
            system.OpenStore("myStore", system.GetUser("user1", "12345"));
           
        }

        [TestMethod]
        public void AddProductTest()
        {
            User user = system.GetUser("user1", "12345");
            storeOwner = user.GetStores().First.Value;
            product1 = new Workshop192.MarketManagment.Product(1,100,"product");
            storeOwner.AddProduct(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);
            product2 = new Workshop192.MarketManagment.Product(2, 100, "product2");
            storeOwner.AddProduct(product2);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 2);
        }

        [TestMethod]
        public void RemoveProductTest()
        {
            storeOwner.RemoveProduct(product1);
            //sstoreOwner.(product1);
            Assert.IsTrue(storeOwner.GetStore().GetProducts().Count == 1);

        }

    }
}
