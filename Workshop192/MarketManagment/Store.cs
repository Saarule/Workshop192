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
        private LinkedList<Tuple<PolicyComponent, int>> discountPolicies;
        private LinkedList<PolicyComponent> sellingPolicies;

        public Store(string name)
        {
            this.name = name;
            inventory = new Inventory();
            discountPolicies = new LinkedList<Tuple<PolicyComponent, int>>();
            sellingPolicies = new LinkedList<PolicyComponent>();
        }

        public void AddProducts(Product product, int amount)
        {
            inventory.AddProducts(product, amount);
        }

        public bool RemoveProducts(Product product, int amount)
        {
            return inventory.RemoveProducts(product, amount);
        }

        public bool RemoveProductFromInventory(int productId)
        {
            return inventory.RemoveProductFromInventory(productId);
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            return inventory.EditProduct(productId, name, category, price, amount);
        }

        public string GetName()
        {
            return name;
        }

        public Dictionary<Product, int> GetInventory()
        {
            return inventory.GetAllProduct();
        }

        public LinkedList<Tuple<PolicyComponent, int>> GetDiscountPolicies()
        {
            return discountPolicies;
        }

        public LinkedList<PolicyComponent> GetSellingPolicies()
        {
            return sellingPolicies;
        }
    }
}
