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
            if (Workshop192.System.GetInstance().GetUser(username, password).GetLoggedIn() == false && Workshop192.System.GetInstance().GetUser(username, password).GetName().Equals(""))
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
