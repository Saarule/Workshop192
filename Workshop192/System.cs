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

        public bool RemoveUser(UserState user)
        {
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

        public void OpenStore(string storeName, UserState owner)
        {
            Store store = new Store(storeName, owner);
            owner.AddStoreOwner(new StoreOwner(owner, store, null));
            stores.AddLast(store);
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

        public bool CloseStore(Store store)
        {
            User creator = store.GetCreator();
            foreach (StoreOwner storeOwner in creator.GetStoreOwners())
                if (storeOwner.GetStore().Equals(store))
                {
                    storeOwner.RemoveChild(storeOwner);
                    break;
                }
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
