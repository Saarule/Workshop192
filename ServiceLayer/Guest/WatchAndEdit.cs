using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class WatchAndEdit
    {
        // use case 2.7 - watch and edit to cart
        public static LinkedList<Cart> Watch(User user)
        {
            return user.GetCarts();
        }

        public static bool Edit(string option , Product product , User user)
        {
            if (option.Equals("delete"))
            {
                user.RemoveProductFromCart(product);
                return true;
            }
            // not support in edit product now.
            return false;
        }

    }
}
