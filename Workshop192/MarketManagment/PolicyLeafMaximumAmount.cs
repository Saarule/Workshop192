using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyLeafMaximumAmount : PolicyComponent
    {
        public int productId { get; set; }
        public int amount { get; set; }
        public int policyId { get; set; }
        public string policyProductId { get; set; }

        public PolicyLeafMaximumAmount(int productId, int amount, int policyId, string policyProductId)
        {
            this.productId = productId;
            this.amount = amount;
            this.policyId = policyId;
            this.policyProductId = policyProductId;
        }

        public PolicyLeafMaximumAmount() //Only for Entity Framework references should be 0
        { }

        public bool Validate(int userId, Cart cart)
        {
            if (productId == 0)
                if (GetTotalProductAmount(cart) <= amount)
                    return true;
            foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                if (productAmount.Key.GetId().Equals(productId))
                    if (productAmount.Value <= amount)
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
                return "(Maximum Amount Of Products in cart is " + amount + ")";
            return "(Maximum Amount Of Product Id [" + productId + "] in cart is " + amount + ")";
        }
    }
}
