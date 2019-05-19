using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    // use case 2.8 - Process of buying policy
    class ProcessOfBuyingProducts
    {
        public static bool ProcessBuyingProducts(User user , LinkedList<Cart> carts)
        {
            return Workshop192.System.GetInstance().PurchaseProducts(1111, user); /// "1111" is Account ID 
        }
    }
}
