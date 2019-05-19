using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class Register
    {
        public static bool Registration(string username, string password, User user)
        {
            if (user.GetState() == null) // if the user logged in will return false 
            {
                // if the user registerd will return false , otherwise true
                return Workshop192.System.GetInstance().Register(username, password);
            }
            return false;
        }
    }
}
