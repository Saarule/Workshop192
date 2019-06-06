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
        private Dictionary<string, UserInfo> userInfos;
        private int userId;
        private Dictionary<int, User> users;

        private static AllRegisteredUsers instance = null;

        private AllRegisteredUsers()
        {
            passwords = new Dictionary<string, string>();
            userInfos = new Dictionary<string, UserInfo>();
            userId = 0;
            users = new Dictionary<int, User>();
        }

        public static AllRegisteredUsers GetInstance()
        {
            if (instance == null)
            {
                instance = new AllRegisteredUsers();
            }
            return instance;
        }

        public static AllRegisteredUsers Reset()
        {
            instance = new AllRegisteredUsers();
            return instance;
        }

        public bool RegisterUser(string userName, string password)
        {
            if (passwords.ContainsKey(userName) || !Security.Security.CheckPasswordSecurity(password))
                return false;
            passwords.Add(userName, password);
            userInfos.Add(userName, new UserInfo(userName));
            return true;
        }

        public int CreateUser()
        {
            userId++;
            users.Add(userId, new User());
            return userId;
        }

        public User GetUser(int userId)
        {
            if (!users.ContainsKey(userId))
                return null;
            return users[userId];
        }

        public UserInfo GetUserInfo(string userName, string password)
        {
            if (!passwords.ContainsKey(userName) || !passwords[userName].Equals(password))
                return null;
            return userInfos[userName];
        }

        public UserInfo GetUserInfo(string userName)
        {
            if (!userInfos.ContainsKey(userName))
                return null;
            return userInfos[userName];
        }

        public bool RemoveUser(string userName)
        {
            if (!userInfos.ContainsKey(userName))
                return false;
            UserInfo user = userInfos[userName];
            while (user.GetStoreManagers().Count > 0)
                user.GetStoreManagers().First.Value.RemoveSelf();
            while (user.GetStoreOwners().Count > 0)
                user.GetStoreOwners().First.Value.RemoveSelf();
            userInfos.Remove(userName);
            passwords.Remove(userName);
            return true;
        }
    }
}
