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
        private LinkedList<Product> products;

        public Store(string name)
        {
            this.name = name;
            products = new LinkedList<Product>();
        }

        public LinkedList<Product> GetProducts()
        {
            return products;
        }

        public string GetName()
        {
            return name;
        }
    }
}
