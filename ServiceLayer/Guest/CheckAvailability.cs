using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace ServiceLayer.Guest
{
    // use case - 2.8(1) check availability of products
    public class CheckAvailability
    {
        public static bool CheckAvailable(int userID)
        {
            MultiCart carts = Workshop192.MarketManagment.System.GetInstance().GetMultiCart(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetMultiCart());
            return Workshop192.MarketManagment.System.GetInstance().CheckProductsAvailability(carts);
        }
    }
}
