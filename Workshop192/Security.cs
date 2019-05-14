using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class Security
    {
        private Dictionary<string, string> users;

        public Security()
        {
            users = new Dictionary<string, string>();
        }

        public bool AddUser(string userName, string password)
        {
            if (users.ContainsKey(userName))
                return false;
            users.Add(userName, password);
            return true;
        }

        public bool ValidatePassword(string userName, string password)
        {
            if (users.ContainsKey(userName) && users[userName] == password)
                return true;
            return false;
        }
    }
}
