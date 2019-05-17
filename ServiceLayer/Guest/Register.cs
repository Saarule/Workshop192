using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
    public class Register
    {
        public Register()
        {
              
        }
        public static bool Registertion(string username, string password)
        {
            if (Workshop192.System.GetInstance().GetUser(username, password).IsLoggedIn() == false && Workshop192.System.GetInstance().GetUser(username, password).GetUserName().Equals(""))
            {
                Workshop192.System.GetInstance().GetUser(username, password).Register(username);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
