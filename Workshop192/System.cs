using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace Workshop192
{
    public class System
    {
        private LinkedList<UserState> users;
        private LinkedList<Store> stores;
        private Security security;

        private static System instance = null;

        private System()
        {
            users = new LinkedList<UserState>();
            stores = new LinkedList<Store>();
            security = new Security();
        }

        public static System GetInstance() {
            if (instance == null) {
                instance = new System();
            }
            return instance;
        }

        public static System Reset()
        {
            instance = new System();
            return instance;
        }

        public bool Register(string userName, string password)
        {
            if (!security.AddUser(userName, password))
                return false;
            UserState user = new UserState(userName);
            users.AddLast(user);
            return true;
        }

        public UserState GetUser(string userName, string password)
        {
            if (!security.ValidatePassword(userName, password))
                return null;
            foreach (UserState user in users)
                if (user.GetUserName() == userName)
                {
                    return user;
                }
            return null;
        }

        public bool OpenStore(string storeName, UserState user)
        {
            if (user == null)
                return false;
            foreach (Store s in stores)
                if (s.GetName().Equals(storeName))
                    return false;
            Store store = new Store(storeName);
            user.GetStoreOwners().AddLast(new StoreOwner(user, store, null));
            stores.AddLast(store);
            return true;
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

        public bool RemoveUser(User user)
        {
            if (user.GetState() == null)
                return false;
            if (!security.RemoveUser(user.GetUserName()))
                return false;
            foreach (StoreOwner storeOwner in user.GetStoreOwners())
            {
                if (!storeOwner.ForceRemoveChild(storeOwner))
                    return false;
                if (storeOwner.GetFather() == null && !CloseStore(storeOwner.GetStore()))
                    return false;
            }
            return true;
        }

        public bool CloseStore(Store store)
        {
            foreach (UserState user in users)
                foreach (Cart cart in user.GetCarts())
                    if (cart.GetStore() == store)
                    {
                        user.GetCarts().Remove(cart);
                        break;
                    }
            return stores.Remove(store);
        }
    }
}
