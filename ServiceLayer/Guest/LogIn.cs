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
        public static bool Login(string username, string password, int userNum)
        {   
            if (CreateAndGetUser.GetUser(userNum).GetState() == null) // if the user logged in will return false
            {
                // if the user not registerd will return false , otherwise true
                return CreateAndGetUser.GetUser(userNum).LogIn(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(username,password));
            }
            return false; 
        }
    }
}
