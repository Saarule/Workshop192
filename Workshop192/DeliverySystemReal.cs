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
        public int Deliver(string name, string address, string city, string country, int zip)
        {
            return new Random().Next(10000, 100000);
        }
    }
}
