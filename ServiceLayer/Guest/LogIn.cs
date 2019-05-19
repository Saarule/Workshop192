using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class LogIn
    {
        public static bool Login(string username, string password, User user)
        {
            if (Workshop192.System)
            {
                // if the user registerd will return false , otherwise true
                return user.LogIn(Workshop192.System.GetInstance().GetUser(username,password));
            }
            return false; 
        }
    }
}
