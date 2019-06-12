using CommunicationLayer.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Workshop192.MarketManagment;
using Product = CommunicationLayer.Models.Product.Product;

namespace CommunicationLayer.Controllers
{
    public class ProductsController : ApiController
    {
        
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Tomato", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Apple", Category = "Groceries", Price = 3.75M },
            new Product { Id = 3, Name = "Orange", Category = "Groceries", Price = 16.98M },
            new Product { Id = 4, Name = "Laptop", Category = "Hardware", Price = 4 },
            new Product { Id = 5, Name = "TV", Category = "Hardware", Price = 32.75M },
            new Product { Id = 6, Name = "DiskOnKey", Category = "Hardware", Price = 116.79M },
            new Product { Id = 7, Name = "Doll", Category = "Toys", Price = 132 },
            new Product { Id = 8, Name = "Yo-yo", Category = "Toys", Price = 311.25M },
            new Product { Id = 9, Name = "Spiderman", Category = "Toys", Price = 155.99M },
            new Product { Id = 10, Name = "Orange", Category = "Groceries", Price = 17.98M }
        };

        public static LinkedList<LinkedList<string>> GetProductsOfCart(int userNum)
        {
            return ServiceLayer.Guest.WatchAndEdit.Watch(userNum);
        }

        //Get: api/products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //Get: api/products/5
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("api/products/getProductsByName/{name}")]
        [HttpGet]
        public List<Product> GetProductsByName(String name)
        {
            List<Product> list = new List<Product>();
            foreach(var p in products)
            {
                if(p.Name.ToLower() == name.ToLower())
                {
                    list.Add(p);
                }
            }
            return list;
        }

        public static bool DeleteFromCart(int userNum, int v)
        {
            throw new NotImplementedException();
        }

        //Post: api/products
        public void Post(Product product)
        {
            products.Add(product);
        }
        
        public static bool openStore(string storename , int userID)
        {
            return ServiceLayer.RegisteredUser.OpenStore.openStore(storename, userID);
        }

        public LinkedList<LinkedList<string>> displayCart(int userID)
        {
            return ServiceLayer.Guest.WatchAndEdit.Watch(userID);
        }
        public static bool addToCart(int userID , int productID , int amount)
        {
            return ServiceLayer.Guest.SaveProductToCart.SaveProduct(productID,userID,amount);
        }
        public static LinkedList<LinkedList<string>> SearchProducts(string input)
        {
            LinkedList<LinkedList<string>> result = ServiceLayer.Guest.SearchProducts.Search(input);
            return result;
        }
        public static bool ManageProducts(int userID, int productID, string name, string category, int price, int amount, string store, string option)
        {
            return ServiceLayer.Store_Owner_User.ManageProducts.ManageProduct(userID,productID,name,category,price,amount,store,option);
        }
        public static LinkedList<LinkedList<string>> getProductsOfStore(string storeName)
        {
            return ServiceLayer.Store_Owner_User.AllProductInStore.GetAllProducts(storeName);
        }
    }
}
