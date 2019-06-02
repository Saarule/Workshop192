using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace Workshop192.MarketManagment
{
    class SellingPolicy
    {
        private LinkedList<UserInfo> bannedUser;
        private bool guestPurchase;
        private int minProducts;
        private Dictionary<int, string> minAmountOfProduct;
    }
}
