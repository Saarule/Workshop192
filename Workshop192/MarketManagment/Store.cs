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
        private DiscountPolicy discountPolicy;
        private SellingPolicy sellingPolicy;

        public Store(string name)
        {
            this.name = name;
            products = new LinkedList<Product>();
            discountPolicy = new DiscountPolicy();
            sellingPolicy = new SellingPolicy();
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
