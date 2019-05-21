using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    public class AssignStoreManager
    {
        // use case 4.5 - Assign store Manager
        public static bool AsssignManager(User user,Store store,string username,bool [] privileges)
        {
            return Workshop192.System.GetInstance().AddStoreManager(user ,store, username,privileges);
        }
    }
}
