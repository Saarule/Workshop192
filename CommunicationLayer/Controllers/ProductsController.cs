using CommunicationLayer.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CommunicationLayer.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Apple", Category = "Groceries", Price = 3.75M },
            new Product { Id = 3, Name = "Orange", Category = "Groceries", Price = 16.98M },
            new Product { Id = 4, Name = "Laptop", Category = "Hardware", Price = 4 },
            new Product { Id = 5, Name = "TV", Category = "Hardware", Price = 32.75M },
            new Product { Id = 6, Name = "DiskOnKey", Category = "Hardware", Price = 116.79M },
            new Product { Id = 7, Name = "Doll", Category = "Toys", Price = 132 },
            new Product { Id = 8, Name = "Yo-yo", Category = "Toys", Price = 311.25M },
            new Product { Id = 9, Name = "Spiderman", Category = "Toys", Price = 155.99M }
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}