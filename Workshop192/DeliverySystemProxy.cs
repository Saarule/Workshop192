﻿using System;
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

        public int CancelDelivery(string transactionSupplyID)
        {
            if (real == null)
                return -1;
            return real.CancelDelivery(transactionSupplyID);
        }

        public int Deliver(string name, string address, string city, string country, string zip)
        {
            if (real == null)
                return -1;
            return real.Deliver(name, address, city, country, zip);
        }
    }
}
