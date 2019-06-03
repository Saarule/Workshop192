using ServiceLayer.Guest;
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
        public static bool assignStoreOwner(int I_storeOwner, string store, string username)
        {
            return CreateAndGetUser.GetUser(I_storeOwner).AddStoreOwner(store, AllRegisteredUsers.GetInstance().GetUserInfo(username));
        }
    }
}
