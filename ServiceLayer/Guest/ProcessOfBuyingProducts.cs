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
        public static bool ProcessBuyingProducts(int accountId, int userId, string name, string address)
        {
            if (!CheckAvailability.CheckAvailable(userId))
                return false;
            return Workshop192.MarketManagment.System.GetInstance().PurchaseProducts(accountId,userId,name,address);
        }
    }
}
