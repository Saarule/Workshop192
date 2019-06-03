using ServiceLayer.Guest;
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
        // use case 3.1 - Log Out
        public static bool Logout(int userNum)
        {
            // if the user not logged in will return false
            return CreateAndGetUser.GetUser(userNum).LogOut();
        }
    }
}
