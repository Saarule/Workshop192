using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
    public class LogIn
    {
        public LogIn()
        {
            
        }

        public static bool Login(string username, string password)
        {
            if (Workshop192.System.GetInstance().GetUser(username, password).GetLoggedIn() == false && !(Workshop192.System.GetInstance().GetUser(username, password).GetName().Equals("")) )
            {
                Workshop192.System.GetInstance().GetUser(username, password).LogIn();
                return true;
            }
            else
                return false; 
        }
    }
}
