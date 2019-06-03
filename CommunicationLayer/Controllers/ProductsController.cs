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
            LinkedList<LinkedList<string>> result = new LinkedList<LinkedList<string>>();
            MultiCart carts = ServiceLayer.Guest.WatchAndEdit.Watch(userID);
            for(int i = 0; i < carts.GetCarts().Count; i++)
            {
                for(int j = 0; j < carts.GetCarts().ElementAt(i).GetProducts().Count; j++)
                {
                    LinkedList<string> toAdd = new LinkedList<string>();
                    toAdd.AddLast(carts.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetId() + "");
                    toAdd.AddLast(carts.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetName() + "");
                    toAdd.AddLast(carts.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetCategory() + "");
                    toAdd.AddLast(carts.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetPrice() + "");
                    toAdd.AddLast(carts.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Value + "");
                    toAdd.AddLast(carts.GetCarts().ElementAt(i).GetStore().GetName());
                    result.AddLast(toAdd);
                }
            }
            return result;
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
    }
}
