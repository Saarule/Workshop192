using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace Workshop192.MarketManagment
{
    public class Store
    {
        private string name;
        private Inventory inventory;

        public Store(string name)
        {
            this.name = name;
            inventory = new Inventory();
        }

        public void AddProducts(Product product, int amount)
        {
            inventory.AddProducts(product, amount);
        }

        public bool RemoveProducts(Product product, int amount)
        {
            return inventory.RemoveProducts(product, amount);
        }

        public bool RemoveProductFromInventory(Product product)
        {
            return inventory.RemoveProductFromInventory(product);
        }

        public bool EditProduct(Product product, string name, string category, int price)
        {
            return inventory.EditProduct(product, name, category, price);
        }

        public string GetName()
        {
            return name;
        }

        public Dictionary<Product, int> GetInventory()
        {
            return inventory.GetAllProduct();
        }
    }
}
