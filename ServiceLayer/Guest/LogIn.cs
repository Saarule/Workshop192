using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;

namespace ServiceLayer.Guest
{
    // use case 2.3 - Log In
    public class LogIn
    {
        public static bool Login(string username, string password, string userID)
        {   
            if (user.GetState() == null) // if the user logged in will return false
            {
                // if the user not registerd will return false , otherwise true
                return user.LogIn(Workshop192.MarketManagment.System.GetInstance().GetUser(username,password));
            }
            return false; 
        }
    }
}
