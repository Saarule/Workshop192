using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Admin
{
    class RemoveUserFromSystem
    {
        public static bool RemoveUser(User admin, User user)
        {
            if ((!admin.IsLoggedIn() || !admin.IsAdmin()) && !Workshop192.System.GetInstance().RemoveUser(user))
                return false;
            return true;
        }
    }
}
