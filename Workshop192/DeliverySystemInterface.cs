﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192
{
    public interface DeliverySystemInterface
    {
        bool Deliver(string name, string address, LinkedList<Cart> carts);
    }
}
