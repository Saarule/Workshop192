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

        public Cart(Store store) { }

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

    }
}
