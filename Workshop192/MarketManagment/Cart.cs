using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    class Cart
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
    }
}
