using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class Admin
    {
        public bool RemoveUser(UserInfo user)
        {
            return AllRegisteredUsers.GetInstance().RemoveUser(user);
        }

        public bool MakeAdmin(UserInfo user)
        {
            if (user.IsAdmin())
                return false;
            return user.SetAdmin();
        }
    }
}
