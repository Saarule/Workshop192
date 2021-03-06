﻿using System;
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
            foreach (UserInfo info in DbCommerce.GetInstance().GetUserInfos())
            {
                passwords[info.userName] = info.password;
                userInfos[info.userName] = info;
            }
        }
        
        public LinkedList<string> GetAllUserNames()
        {
            return new LinkedList<string>(passwords.Keys);     
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
            if (passwords.ContainsKey(userName) || userName.Equals(""))
            {
                Logger.GetInstance().WriteToErrorLog("A user failed to register " + userName + " " + password);
                throw new ErrorMessageException("user name already exists");
            }
            if (!Security.Security.CheckPasswordSecurity(password))
            {
                Logger.GetInstance().WriteToErrorLog("A user failed to register " + userName + " " + password);
                throw new ErrorMessageException("password is too weak");
            }
            Logger.GetInstance().WriteToEventLog("A new user was registered " + userName + " " + password);
            passwords.Add(userName, password);
            UserInfo info = new UserInfo(userName, password);
            userInfos.Add(userName, info);
            DbCommerce.GetInstance().AddUserInfo(info);
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

        public LinkedList<UserInfo> getUserInfo()
        {
            LinkedList<UserInfo> userInfo = new LinkedList<UserInfo>();
            for(int i=0;i< userInfos.Count; i++)
            {
                userInfo.AddLast(userInfos.ElementAt(i).Value);
            }
            return userInfo;
        }

        public bool RemoveUser(UserInfo user)
        {
            while (user.GetStoreManagers().Count > 0)
                user.GetStoreManagers().First.Value.RemoveSelf();
            while (user.GetStoreOwners().Count > 0)
                user.GetStoreOwners().First.Value.RemoveSelf();
            userInfos.Remove(user.GetUserName());
            passwords.Remove(user.GetUserName());
            foreach (KeyValuePair<int, User> u in users)
                if (u.Value.GetInfo() != null && u.Value.GetInfo().userName == user.userName)
                    u.Value.LogOut();
            DbCommerce.GetInstance().RemoveUserInfo(user);
            return true;
        }
    }
}
