using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class Admin
    {
        public bool RemoveUser(string userName)
        {
            return AllRegisteredUsers.GetInstance().RemoveUser(userName);
        }
    }
}
