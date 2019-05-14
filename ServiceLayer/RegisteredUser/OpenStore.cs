using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.RegisteredUser
{
    public class OpenStore
    {
        public OpenStore()
        {

        }
        public static bool OpenS(User user , string storeName)
        {
            if (user.GetLoggedIn() == false)
                return false;
            else
            {
                Workshop192.System.GetInstance().OpenStore(storeName,user);
                return true;
            }
        }

    }
}
