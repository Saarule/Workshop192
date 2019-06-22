using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Store_Owner_User
{
    public class IsOwnerOrManage
    {
        public static bool IsOwner(int userID, string storename)
        {
            string userName = Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetUserName();
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(userName).GetOwner(storename) != null;
        }
        public static bool IsOwner2(int userID)
        {
            string userName = Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetUserName();
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(userName).GetStoreOwners() != null;
        }

        public static bool IsManager(int userID, string storename)
        {
            string userName = Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetUserName();
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(userName).GetManager(storename) != null;
        }
        public static bool IsManager2(int userID)
        {
            string userName = Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetUserName();
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(userName).GetStoreManagers() != null;
        }

    }
}
