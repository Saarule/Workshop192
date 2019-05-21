using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.Guest;
using ServiceLayer.Store_Owner_User;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;
using System.Linq;

namespace AccaptanceTests.Guest
{
    [TestFixture]
    public class WatchAndEditTest
    {
        Workshop192.System System = null;
        User Orel;
        User Nati;
        Product p1;
        Product p2;
        Product p3;
        Product p4;
        Cart cart;
        Cart cart2;
        LinkedList<Cart> c1;
        
        [SetUp]
        public void SetUp()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            init.Initalize();
            System = Workshop192.System.GetInstance();
            Orel = new User();
            Nati = new User();
            Register.Registration("orel", "123456", Orel);
            LogIn.Login("orel", "123456", Orel);
            System.OpenStore("Victory", Orel.GetState());
            System.OpenStore("Rami-Levi", Orel.GetState());
            p1 = new Product(1, 10, "white bread");
            p2 = new Product(2, 12, "black bread");
            p3 = new Product(3, 15, "bread");
            p4 = new Product(4, 16, "brown bread");
            ManageProducts.ManageProduct(Orel, p1, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p2, System.GetStore("Victory"), "add");
            ManageProducts.ManageProduct(Orel, p3, System.GetStore("Rami-Levi"), "add");
            ManageProducts.ManageProduct(Orel, p4, System.GetStore("Rami-Levi"), "add");
            c1 = new LinkedList<Cart>();
            cart = new Cart(System.GetStore("Victory"));
            cart2 = new Cart(System.GetStore("Rami-Levi"));
        }
        [TearDown]
        public void TearDown()
        {
            System = Workshop192.System.Reset();
        }
        [Test]
        public void WatchSimpleCartTest()
        {
            SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Nati);
            cart.AddProduct(p1);
            cart.AddProduct(p2);
            c1.AddLast(cart);
            for(int i = 0; i < Nati.GetCarts().Count; i++) 
            {
                for (int j = 0; j < Nati.GetCarts().ElementAt(i).GetProducts().Count; j++)
                {
                    Assert.AreEqual(Nati.GetCarts().ElementAt(i).GetProducts().ElementAt(j), c1.ElementAt(i).GetProducts().ElementAt(j));
                }
            }
        }
        [Test]
        public void WatchComplicatedCartTest()
        {
            SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p3, System.GetStore("Rami-Levi"), Nati);
            SaveProductToCart.SaveProduct(p4, System.GetStore("Rami-Levi"), Nati);

            cart.AddProduct(p1);
            cart.AddProduct(p2);
            cart2.AddProduct(p3);
            cart2.AddProduct(p4);
            c1.AddLast(cart);
            c1.AddLast(cart2);
            for (int i = 0; i < Nati.GetCarts().Count; i++)
            {
                for (int j = 0; j < Nati.GetCarts().ElementAt(i).GetProducts().Count; j++)
                {
                    Assert.AreEqual(Nati.GetCarts().ElementAt(i).GetProducts().ElementAt(j), c1.ElementAt(i).GetProducts().ElementAt(j));
                }
            }
        }
        [Test]
        public void WatchEmptyCartTest()
        {
            Assert.AreEqual(WatchAndEdit.Watch(Nati), c1);
        }
        [Test]
        public void DeleteProductsCartTest() 
        {
            SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Nati);
            WatchAndEdit.Edit("delete", p1, Nati);
            c1.AddLast(cart);
            for (int i = 0; i < Nati.GetCarts().Count; i++)
            {
                for (int j = 0; j < Nati.GetCarts().ElementAt(i).GetProducts().Count; j++)
                {
                    Assert.AreEqual(Nati.GetCarts().ElementAt(i).GetProducts().ElementAt(j), c1.ElementAt(i).GetProducts().ElementAt(j));
                }
            }
        }
        [Test]
        public void DeleteAllProductsFromCartTest()
        {
            SaveProductToCart.SaveProduct(p1, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p2, System.GetStore("Victory"), Nati);
            SaveProductToCart.SaveProduct(p3, System.GetStore("Rami-Levi"), Nati);
            SaveProductToCart.SaveProduct(p4, System.GetStore("Rami-Levi"), Nati);

            WatchAndEdit.Edit("delete", p1, Nati);
            WatchAndEdit.Edit("delete", p2, Nati);
            WatchAndEdit.Edit("delete", p3, Nati);
            WatchAndEdit.Edit("delete", p4, Nati);
            c1.AddLast(cart);
            c1.AddLast(cart2);
            for (int i = 0; i < Nati.GetCarts().Count; i++)
            {
                for (int j = 0; j < Nati.GetCarts().ElementAt(i).GetProducts().Count; j++)
                {
                    Assert.AreEqual(Nati.GetCarts().ElementAt(i).GetProducts().ElementAt(j), c1.ElementAt(i).GetProducts().ElementAt(j));
                }
            }
        }
    }
}
