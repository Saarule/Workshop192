using CommunicationLayer.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Product = CommunicationLayer.Models.Product.Product;

namespace CommunicationLayer.Controllers
{
    public class ProductsController : ApiController
    {
        /* SAAR VERSION
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
        */


        public static bool OpenStore(string storename ,string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.RegisteredUser.OpenStore.openStore(storename, userID);
        }

        public static LinkedList<LinkedList<string>> DisplayCart(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Guest.WatchAndEdit.Watch(userID);
        }

        public static bool SaveToCart(string SessionID, int productID , int amount)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Guest.SaveProductToCart.SaveProduct(productID,userID,amount);
        }

        public static LinkedList<LinkedList<string>> SearchProducts(string input)
        {
            LinkedList<LinkedList<string>> result = ServiceLayer.Guest.SearchProducts.Search(input);
            return result;
        }

        public static LinkedList<string> SearchProductsByID(int productId)
        {
            LinkedList<string> result = ServiceLayer.Guest.SearchProducts.SearchById(productId);
            return result;
        }

        public static bool ManageProducts(string SessionID, int productID, string name, string category, int price, int amount, string store, string option)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.ManageProducts.ManageProduct(userID,productID,name,category,price,amount,store,option);
        }

        public static bool ProcessOfBuying(int AcountID, string SessionID, string Name,string AddresToDelivery)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Guest.ProcessOfBuyingProducts.ProcessBuyingProducts(AcountID,userID,Name,AddresToDelivery);
        }

        public static LinkedList<LinkedList<string>> FilterProducts(string input , LinkedList<LinkedList<string>> toFilter,string option)
        {
            // filter by category OR name (must be identical to  - הפילטר חייב להיות זהה)
            // option need to be :  byName OR byCategory
            return ServiceLayer.Guest.FilterProducts.Filter(input , toFilter, option);
        }

        public static LinkedList<LinkedList<string>> GetProductsOfStore(string storeName)
        {
            return ServiceLayer.Store_Owner_User.AllProductInStore.GetAllProducts(storeName);
        }
        public static LinkedList<LinkedList<string>> GetAllProducts()
        {
            return ServiceLayer.Store_Owner_User.AllProductInStore.GetAll();
        }

        public static bool EditCart(string option, int productID, string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            //EDIT SUPPORT: meantime just "delete" if want to edit num of units form products need to delete and add how many he wants again.  
            return ServiceLayer.Guest.WatchAndEdit.Edit(option, productID, userID);
        }
    }
}
