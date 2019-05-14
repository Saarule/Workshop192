using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.RegisteredUser
{
    public class LogOut
    {
        public LogOut()
        {

        }
        public static bool Logout(User user)
        {
            if (user.GetLoggedIn() == true)
            {
                user.LogOut();
                return true;
            }
            return false;

        }
    }
}
