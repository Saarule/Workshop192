using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace Workshop192.MarketManagment
{
    class Store
    {
        private string name;
        private User creator;
        private LinkedList<Product> products;

        public Store(string name, User creator)
        {
            this.name = name;
            this.creator = creator;
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

        public User GetCreator()
        {
            return creator;
        }
    }
}
