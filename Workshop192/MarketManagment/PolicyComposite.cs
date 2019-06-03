using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyComposite : PolicyComponent
    {
        private PolicyComponent left;
        private string operation;
        private PolicyComponent right;

        public PolicyComposite(PolicyComponent left, string operation, PolicyComponent right)
        {
            this.left = left;
            this.operation = operation;
            this.right = right;
        }

        public bool Validate(int userId, Cart cart)
        {
            switch (operation)
            {
                case "OR":
                    return left.Validate(userId, cart) || right.Validate(userId, cart);
                case "AND":
                    return left.Validate(userId, cart) && right.Validate(userId, cart);
                case "XOR":
                    return left.Validate(userId, cart) ^ right.Validate(userId, cart);
                default:
                    return false;
            }
        }
    }
}
