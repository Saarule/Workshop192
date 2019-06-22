using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyLeafMinimumAmount : PolicyComponent
    {
        private int productId;
        private int amount;

        public PolicyLeafMinimumAmount(int productId, int amount)
        {
            this.productId = productId;
            this.amount = amount;
        }

        public bool Validate(int userId, Cart cart)
        {
            if (productId == 0)
                if (GetTotalProductAmount(cart) >= amount)
                    return true;
            foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                if (productAmount.Key.GetId().Equals(productId))
                    if (productAmount.Value >= amount)
                        return true;
            return false;
        }

        private int GetTotalProductAmount(Cart cart)
        {
            int amount = 0;
            foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                amount += productAmount.Value;
            return amount;
        }

        public override string ToString()
        {
            if (productId == 0)
                return "(Minimum Amount Of Products in cart is " + amount + ")";
            return "(Minimum Amount Of Product Id [" + productId + "] in cart is " + amount + ")";
        }
    }
}
