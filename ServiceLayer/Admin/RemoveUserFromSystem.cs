using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Admin
{
    // use case 6.2 - Remove user from system
    public class RemoveUserFromSystem
    {
        public static bool RemoveUser(int adminID, string nameToDelete)
        {
            if (AllRegisteredUsers.GetInstance().GetUser(adminID).GetInfo() == null || !AllRegisteredUsers.GetInstance().GetUser(adminID).IsAdmin())
                return false;
            return AllRegisteredUsers.GetInstance().RemoveUser(nameToDelete);
        }
    }
}
