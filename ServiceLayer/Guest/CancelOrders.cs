using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
    public class CancelOrders
    {
        public static int CancelPay(string transID)
        {
            return Workshop192.MarketManagment.System.GetInstance().CancelPay(transID);
        }

        public static int CancelDelivery(string transID)
        {
            return Workshop192.MarketManagment.System.GetInstance().CancelDelivery(transID);
        }
    }
}
