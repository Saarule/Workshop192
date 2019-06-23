using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192
{
    public interface DeliverySystemInterface
    {
        int Deliver(string name, string address, string city, string country, string zip);
        int CancelDelivery(string transactionSupplyID);
    }
}
