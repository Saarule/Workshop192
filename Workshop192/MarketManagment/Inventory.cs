using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Inventory
    {
        private Dictionary<Product, int> products;

        public Inventory()
        {
            products = new Dictionary<Product, int>();
        }

        public void AddProducts(Product product, int amount)
        {
            if (products.ContainsKey(product))
            {
                products[product] += amount;
                return;
            }
            products.Add(product, amount);
        }

        public bool RemoveProducts(Product product, int amount)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] < amount)
                    return false;
                products[product] -= amount;
                return true;
            }
            return false;
        }

        public bool RemoveProductFromInventory(Product product)
        {
            return products.Remove(product);
        }

        public bool EditProduct(Product product, string name, string category, int price)
        {
            foreach (Product p in products.Keys)
                if (product.Equals(p))
                {
                    product.EditProduct(name, category, price);
                    return true;
                }
            return false;
        }

        public Dictionary<Product, int> GetAllProduct()
        {
            return products;
        }
    }
}
