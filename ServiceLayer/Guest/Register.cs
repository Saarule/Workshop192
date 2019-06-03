using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    // use case 2.2 - Register
    public class Register
    {
        public static bool Registration(string username, string password, int userNum)
        {

            if (CreateAndGetUser.GetUser(userNum).GetInfo() == null) // if the user logged in will return false 
            {
                // if the user registerd will return false , otherwise true
                return AllRegisteredUsers.GetInstance().RegisterUser(username, password);
            }
            return false;
        }
    }
}
