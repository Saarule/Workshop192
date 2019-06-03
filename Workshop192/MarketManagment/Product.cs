using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Product
    {
        private int Id;
        private string name;
        private string category;
        private int price;
        private LinkedList<Tuple<PolicyComponent, int>> discountPolicies;
        private LinkedList<PolicyComponent> sellingPolicies;

        public Product(int Id, string name, string category, int price)
        {
            this.Id = Id;
            this.name = name;
            this.category = category;
            this.price = price;
            discountPolicies = new LinkedList<Tuple<PolicyComponent, int>>();
            sellingPolicies = new LinkedList<PolicyComponent>();
        }

        public void EditProduct(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetCategory()
        {
            return category;
        }

        public string GetName()
        {
            return name;
        }

        public int GetPrice()
        {
            return price;
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
