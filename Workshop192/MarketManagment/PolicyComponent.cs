using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public interface PolicyComponent
    {
        int policyId { get; set; }
        string policyProductId { get; set; }

        bool Validate(int userId, Cart cart);
    }
}
