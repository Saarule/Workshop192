using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyCompositeAnd : PolicyComponent
    {
        public virtual PolicyComponent left { get; set; }
        public virtual PolicyComponent right { get; set; }
        public int policyId { get; set; }
        public string policyProductId { get; set; }

        public PolicyCompositeAnd(PolicyComponent left, PolicyComponent right, int policyId, string policyProductId)
        {
            this.left = left;
            this.right = right;
            this.policyId = policyId;
            this.policyProductId = policyProductId;
        }

        public PolicyCompositeAnd() //Only for Entity Framework references should be 0
        { }

        public bool Validate(int userId, Cart cart)
        {
            return left.Validate(userId, cart) && right.Validate(userId, cart);
        }

        public override string ToString()
        {
            return "(" + left.ToString() +  " And " + right.ToString() + ")";
        }
    }
}
