using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Store_Owner_User
{
    public class IsOwnerOrManage
    {
        public static bool IsOwner(int userID)
        {
            string userName = Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetUserName();
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(userName).GetStoreOwners().Count != 0;
        }

        public static bool IsManager(int userID)
        {
            string userName = Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetUserName();
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(userName).GetStoreManagers().Count != 0;
        }
    }
}
