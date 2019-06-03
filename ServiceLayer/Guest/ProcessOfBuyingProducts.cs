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
    public class ProcessOfBuyingProducts
    {
        public static bool ProcessBuyingProducts(int accountId, User user, string name, string address)
        {/*
            if (user.GetCarts().Count == 0)
                return false;
            if (!CheckAvailability.CheckAvailable(user.GetCarts()))
                return false;
            return Workshop192.System.GetInstance().PurchaseProducts(accountId, user, name, address); 
        */
            return true;
        }
    }
}
