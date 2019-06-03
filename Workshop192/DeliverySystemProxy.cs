using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192
{
    public class DeliverySystemProxy : DeliverySystemInterface
    {
        private DeliverySystemReal real;

        public DeliverySystemProxy(DeliverySystemReal real)
        {
            this.real = real;
        }

        public bool Deliver(string name, string address, MultiCart multiCart)
        {
            if (real == null)
                return false;
            return real.Deliver(name, address, multiCart);
        }
    }
}
