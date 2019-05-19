using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    public class AssignStoreOwner
    {
        // use case 4.3 - Assign store owner
        public static bool assignStoreOwner(User I_storeOwner, Store store, string username)
        {
            return Workshop192.System.GetInstance().AddStoreOwner(I_storeOwner, store, username);
        }
    }
}
