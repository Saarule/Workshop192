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

        public bool AddProducts(Product product, int amount)
        {
            if (products.ContainsKey(product))
                throw new ErrorMessageException("Product already exists");
            products.Add(product, amount);
            return true;
        }

        public bool RemoveProducts(Product product, int amount)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] < amount)
                    throw new ErrorMessageException("Product doesn't have the given amount exists");
                products[product] -= amount;
                return true;
            }
            throw new ErrorMessageException("Product doesn't exists");
        }

        public bool RemoveProductFromInventory(int productId)
        {
            foreach (Product product in products.Keys)
                if (product.GetId() == productId)
                    return products.Remove(product);
            throw new ErrorMessageException("Product doesn't exists");
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            foreach (Product p in products.Keys)
                if (p.GetId() == productId)
                {
                    products[p] = amount;
                    p.EditProduct(name, category, price);
                    return true;
                }
            throw new ErrorMessageException("Product doesn't exists");
        }

        public Dictionary<Product, int> GetAllProduct()
        {
            return products;
        }
    }
}
