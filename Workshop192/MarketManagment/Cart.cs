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
        private Dictionary<Product, int> products;
        int sum;

        public Cart(Store store)
        {
            this.store = store;
            products = new Dictionary<Product, int>();
            sum = 0;
        }

        public bool AddProductsToCart(Product product, int amount)
        {
            if ((store.GetInventory()[product] < amount) || (products[product] + amount > store.GetInventory()[product]))
                return false;
            products[product] += amount;
            return true;
        }

        public bool RemoveProduct(Product product)
        {
            return products.Remove(product);
        }

        public void SetSum()
        {
            foreach (KeyValuePair<Product, int> product in products)
                sum += product.Key.GetPrice() * product.Value;
        }

        public void SetSum(int sum)
        {
            this.sum = sum;
        }

        public Store GetStore()
        {
            return store;
        }

        public Dictionary<Product, int> GetProducts()
        {
            return products;
        }

        public int GetCartSum()
        {
            return sum;
        }
    }
}