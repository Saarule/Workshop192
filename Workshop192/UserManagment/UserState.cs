using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class UserState
    {
        private string userName;
        private bool admin;
        private LinkedList<StoreOwner> storeOwners;
        private LinkedList<Cart> carts;

        public UserState(string userName)
        {
            this.userName = userName;
            admin = false;
            storeOwners = new LinkedList<StoreOwner>();
            carts = new LinkedList<Cart>();
        }

        public bool SetAdmin()
        {
            if (admin)
                return false;
            admin = true;
            return true;
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            return storeOwners;
        }

        public bool AddStoreOwner(Store store, UserState user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AddOwner(user);
        }

        public bool AddStoreManager(Store store, UserState user, bool[] privileges)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AddManager(user, privileges);
        }

        public bool RemoveStoreOwner(Store store, UserState user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            StoreOwner owner = null;
            foreach (StoreOwner so in s.GetChildren())
                if (so.GetUser().Equals(user))
                {
                    owner = so;
                    break;
                }
            if (owner == null)
                return false;
            return s.RemoveChild(owner);
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }

        public string GetUserName()
        {
            return userName;
        }

        public bool GetAdmin()
        {
            return admin;
        }

        public StoreOwner GetOwner(Store store)
        {
            foreach (StoreOwner s in storeOwners)
                if (s.GetStore().Equals(store))
                    return s;
            return null;
        }
    }
}
