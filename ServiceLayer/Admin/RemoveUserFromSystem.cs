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
        public static bool RemoveUser(User admin, UserInfo toDelete)
        {
            if (admin.GetState() == null || !admin.IsAdmin())
                return false;
            return AllRegisteredUsers.GetInstance().RemoveUser(toDelete.GetUserName());
        }
    }
}
