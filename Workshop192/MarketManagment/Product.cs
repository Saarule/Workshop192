using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    class Product
    {
        private int productId;
        private int price;
        private string name;

        public Product(int productId, int price, string name)
        {
            this.productId = productId;
            this.price = price;
            this.name = name;
        }

        public int GetPrice()
        {
            return price;
        }

        public string GetName()
        {
            return name;
        }
    }
}
