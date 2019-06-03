using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192
{
    public class DeliverySystemReal : DeliverySystemInterface
    {
        public bool Deliver(string name, string address, MultiCart multiCart)
        {
            return true;
        }
    }
}
