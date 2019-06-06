using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyCompositeAnd : PolicyComponent
    {
        private PolicyComponent left;
        private PolicyComponent right;

        public PolicyCompositeAnd(PolicyComponent left, PolicyComponent right)
        {
            this.left = left;
            this.right = right;
        }

        public bool Validate(int userId, Cart cart)
        {
            return left.Validate(userId, cart) && right.Validate(userId, cart);
        }
    }
}
