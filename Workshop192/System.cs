using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace Workshop192
{
    class System
    {
        private LinkedList<User> users;
        private LinkedList<Store> stores;
        private Security security;

        public System()
        {
            users = new LinkedList<User>();
            stores = new LinkedList<Store>();
            security = new Security();
        }

        public bool AddUser(string userName, string password)
        {
            if (!security.AddUser(userName, password))
                return false;
            User user = new User();
            user.Register(userName);
            users.AddLast(user);
            return true;
        }

        public User GetUser(string userName, string password)
        {
            if (!security.ValidatePassword(userName, password))
                return null;
            foreach (User user in users)
                if (user.GetName() == userName)
                {
                    return user;
                }
            return null;
        }

        public void OpenStore(string storeName, User owner)
        {
            Store store = new Store(storeName, owner);
            owner.AddStore(new StoreOwner(owner, store, null));
        }

        public Store GetStore(string storeName)
        {
            foreach (Store store in stores)
                if (store.GetName() == storeName)
                    return store;
            return null;
        }

        public LinkedList<Store> GetAllStores()
        {
            return stores;
        }
    }
}
