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
        // use case 3.1 - Open Store
        public static bool openStore(string storeName, User user)
        {
           return Workshop192.System.GetInstance().OpenStore(storeName, user.GetState());
        }

    }
}
