using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Product
    {
        private string name;
        private string category;
        private int price;

        public Product(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public void EditProduct(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
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
    }
}
