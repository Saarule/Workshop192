using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class AllRegisteredUsers
    {
        private Dictionary<string, string> passwords;
        private Dictionary<string, UserInfo> users;

        private static AllRegisteredUsers instance = null;

        private AllRegisteredUsers()
        {
            passwords = new Dictionary<string, string>();
            users = new Dictionary<string, UserInfo>();
        }

        public static AllRegisteredUsers GetInstance()
        {
            if (instance == null)
            {
                instance = new AllRegisteredUsers();
            }
            return instance;
        }

        public bool RegisterUser(string userName, string password)
        {
            if (passwords.ContainsKey(userName) || Security.Security.CheckPasswordSecurity(password))
                return false;
            passwords.Add(userName, password);
            users.Add(userName, new UserInfo(userName));
            return true;
        }

        public UserInfo GetUser(string userName, string password)
        {
            if (!passwords.ContainsKey(userName) || !passwords[userName].Equals(password))
                return null;
            return users[userName];
        }

        public UserInfo GetUser(string userName)
        {
            if (!users.ContainsKey(userName))
                return null;
            return users[userName];
        }

        public bool RemoveUser(string userName)
        {
            //TODO
        }
    }
}
