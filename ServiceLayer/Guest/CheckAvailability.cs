using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace ServiceLayer.Guest
{
    // use case - 2.8(1) check availability of products
    class CheckAvailability
    {
        public static bool CheckAvailable(LinkedList<Cart> carts) {
            return Workshop192.System.GetInstance().CheckProductsavailability(carts);
        }
    }
}
