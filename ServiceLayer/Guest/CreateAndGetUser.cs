using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class CreateAndGetUser
    {
        public static int CreateUser()
        {
            return AllRegisteredUsers.GetInstance().CreateUser();
        }

        public static User GetUser(int userNum)
        {
            return AllRegisteredUsers.GetInstance().GetUser(userNum);
        }
    }
}
