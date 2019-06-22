using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
    public class IsLoggedIn
    {
        public static bool IsLogged(int userId)
        {
            return (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetUserName()) != null);
        }
    }
}
