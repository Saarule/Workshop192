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

        public bool AddProduct(Product product)
        {
            foreach (Product p in products)
                if (p.Equals(product))
                    return false;
            products.AddLast(product);
            return true;
        }

        public bool RemoveProduct(Product product)
        {
            return products.Remove(product);
        }

        public Store GetStore()
        {
            return store;
        }

        public LinkedList<Product> GetProducts()
        {
            return products;
        }

    }
}