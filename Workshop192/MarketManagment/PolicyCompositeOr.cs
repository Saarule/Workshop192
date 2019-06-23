using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyCompositeOr : PolicyComponent
    {
        private PolicyComponent left;
        private PolicyComponent right;

        public PolicyCompositeOr(PolicyComponent left, PolicyComponent right)
        {
            this.left = left;
            this.right = right;
        }

        public PolicyCompositeOr() //Only for Entity Framework references should be 0
        { }

        public bool Validate(int userId, Cart cart)
        {
            return left.Validate(userId, cart) || right.Validate(userId, cart);
        }
        public override string ToString()
        {
            return "(" + left.ToString() + " Or " + right.ToString() + ")";
        }
    }
}
