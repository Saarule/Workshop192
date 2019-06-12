using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyLeafProductAmount : PolicyComponent
    {
        private string operation;
        private Product product;
        int amount;

        public PolicyLeafProductAmount(Product product, string operation, int amount)
        {
            this.product = product;
            this.operation = operation;
            this.amount = amount;
        }

        public bool Validate(int userId, Cart cart)
        {
            switch (operation)
            {
                case "==":
                    if (product == null)
                        if (GetTotalProductAmount(cart) == amount)
                            return true;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                        if (productAmount.Key.Equals(product))
                            if (productAmount.Value == amount)
                                return true;
                    break;
                case "!=":
                    if (product == null)
                        if (GetTotalProductAmount(cart) != amount)
                            return true;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                        if (productAmount.Key.Equals(product))
                            if (productAmount.Value != amount)
                                return true;
                    break;
                case "<":
                    if (product == null)
                        if (GetTotalProductAmount(cart) < amount)
                            return true;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                        if (productAmount.Key.Equals(product))
                            if (productAmount.Value < amount)
                                return true;
                    break;
                case "<=":
                    if (product == null)
                        if (GetTotalProductAmount(cart) <= amount)
                            return true;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                        if (productAmount.Key.Equals(product))
                            if (productAmount.Value <= amount)
                                return true;
                    break;
                case ">":
                    if (product == null)
                        if (GetTotalProductAmount(cart) > amount)
                            return true;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                        if (productAmount.Key.Equals(product))
                            if (productAmount.Value > amount)
                                return true;
                    break;
                case ">=":
                    if (product == null)
                        if (GetTotalProductAmount(cart) >= amount)
                            return true;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                        if (productAmount.Key.Equals(product))
                            if (productAmount.Value >= amount)
                                return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        private int GetTotalProductAmount(Cart cart)
        {
            int amount = 0;
            foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                amount += productAmount.Value;
            return amount;
        }
    }
}
