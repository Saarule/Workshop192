using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    // use case 4.6 - Remove store manager
    class RemoveStoreManager
    {
        public static bool removeStoreManager(User Im, Store store, UserState toRemove)
        {
            return Im.RemoveStoreOwner(store, toRemove);
        }
    }
}
