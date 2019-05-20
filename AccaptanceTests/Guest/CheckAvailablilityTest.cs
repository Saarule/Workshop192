using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class CheckAvailablilityTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        User Saar;

        Product p1;
        Product p2;
        Product p3;
        Product p4;
        Product p5;
        Product p6;

        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Saar = new User();

            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            System.OpenStore("Victory", Orel.GetState());
            System.OpenStore("Mega", Orel.GetState());
            p1 = new Product(1, 10, "white bread");
            p2 = new Product(2, 12, "black bread");
            p3 = new Product(3, 10, "chocolate");
            p4 = new Product(4, 5, "milki");
            p5 = new Product(5, 15, "humus");
            p6 = new Product(6, 2, "water");
            ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p3, System.GetStore("Victory"), "add");
            //SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Orel);
            //SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Orel);

            ManageProducts.ManageProduct(Orel, p4, System.GetStore("Mega"), "add");
            ManageProducts.ManageProduct(Orel, p5, System.GetStore("Mega"), "add");
            ManageProducts.ManageProduct(Orel, p6, System.GetStore("Mega"), "add");
            SaveProductToCart.SaveProduct(p4, System.GetStore("Mega"), Orel);
            SaveProductToCart.SaveProduct(p5, System.GetStore("Mega"), Orel);
            SaveProductToCart.SaveProduct(p5, System.GetStore("Mega"), Nati);
            SaveProductToCart.SaveProduct(p3, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p6, System.GetStore("Mega"), Nati);

        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void AvailableFromOneShopTest()
        {
            Assert.AreEqual(CheckAvailability.CheckAvailable(Orel.GetCarts()), true);
        }
        [Test]
        public void AvailableFromTwoShopTest()
        {
            Assert.AreEqual(CheckAvailability.CheckAvailable(Nati.GetCarts()), true);
        }
        [Test]
        public void NotAvailableProductShopTest()//doesnt remove the product from store after check_availability returb true;
        {
            Assert.AreEqual(CheckAvailability.CheckAvailable(Orel.GetCarts()), true);
            Assert.AreEqual(CheckAvailability.CheckAvailable(Nati.GetCarts()), false);
        }
    }
}
