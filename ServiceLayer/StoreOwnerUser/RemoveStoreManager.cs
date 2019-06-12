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
    // use case 4.6 - Remove store manager
    public class RemoveStoreManager
    {

        public static bool removeStoreManager(int Im, string store, string toRemove)
        {
            return CreateAndGetUser.GetUser(Im).RemoveStoreOwner(store, AllRegisteredUsers.GetInstance().GetUserInfo(toRemove)); 
        }
    }
}
