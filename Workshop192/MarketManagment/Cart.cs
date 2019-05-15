using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Cart
    {
        private Store store;
        private LinkedList<Product> products;

        public Cart(Store store)
        {
            this.store = store;
            products = new LinkedList<Product>();
        }

        public void AddProduct(Product product)
        {
            products.AddLast(product);
        }

        public bool RemoveProduct(Product product)
        {
            return products.Remove(product);
        }
=========
        public void AddProduct(Product product) { }

        public bool RemoveProduct(Product product) { }

        public LinkedList<Product> GetProductsOfCart()
        {
            return products;
        }
        public Store GetStoreOfCart()
        {
            return store;
        }

>>>>>>>>> Temporary merge branch 2
    }
}


        public Store GetStore()
        {
            return store;
        }

        public LinkedList<Product> GetProducts()
        {
            return products;
        }