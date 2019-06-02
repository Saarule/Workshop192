using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class UserInfo
    {
        private string userName;
        private bool admin;
        private LinkedList<StoreOwner> storeOwners;
        private LinkedList<StoreManager> storeManagers;
        private int multiCartId;

        public UserInfo(string userName)
        {
            this.userName = userName;
            admin = false;
            storeOwners = new LinkedList<StoreOwner>();
            storeManagers = new LinkedList<StoreManager>();
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
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

        public LinkedList<StoreManager> GetStoreManagers()
        {
            return storeManagers;
        }

        public bool AddStoreOwner(Store store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AddOwner(user);
        }

        public bool AddStoreManager(Store store, UserInfo user, bool[] privileges)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AddManager(user, privileges);
        }

        public bool RemoveStoreOwner(Store store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            StoreOwner owner = null;
            foreach (Appointment appointmnet in s.GetAppointedOwners())
                if (appointmnet.GetChild().GetUser().Equals(user))
                {
                    owner = appointmnet.GetChild();
                    break;
                }
            if (owner == null)
                return false;
            return s.RemoveAppointedOwner(owner);
        }

        public int GetMultiCart()
        {
            return multiCartId;
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
