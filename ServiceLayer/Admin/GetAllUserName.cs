using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Admin
{
    public class GetAllUserName
    {
        public static LinkedList<string> GetAllUser()
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetAllUserNames();
        }
    }
}
