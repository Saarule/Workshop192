using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Admin
{
    public class IsAdmin
    {
        public static bool isAdmin(int userNum)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userNum).IsAdmin();
        }
    }
}
