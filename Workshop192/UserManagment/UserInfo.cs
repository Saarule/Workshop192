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

        public bool OpenStore(string storeName)
        {
            if (storeName.Equals("") || MarketManagment.System.GetInstance().GetStore(storeName) != null)
                return false;
            MarketManagment.System.GetInstance().OpenStore(storeName);
            storeOwners.AddLast(new StoreOwner(this, storeName, null));
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

        public bool AddProducts(Store store, Product product, int amount)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
            {
                owner.AddProducts(product, amount);
                return true;
            }
            if (manager != null)
                return manager.AddProducts(product, amount);
            return false;
        }

        public bool RemoveProductFromInventory(Store store, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveProductFromInventory(productId);
            if (manager != null)
                return manager.RemoveProductFromInventory(productId);
            return false;
        }

        public bool EditProduct(Store store, int productId, string name, string category, int price, int amount)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.EditProduct(productId, name, category, price, amount);
            if (manager != null)
                return manager.EditProduct(productId, name, category, price, amount);
            return false;
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

        public bool RemoveStoreManager(Store store, UserInfo user)
        {
            StoreOwner owner = GetOwner(store);
            if (owner == null)
                return false;
            foreach (StoreManager manager in owner.GetAppointedManagers())
                if (manager.GetUser().Equals(user))
                    return owner.RemoveAppointedManager(manager);
            return false;
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
            foreach (StoreOwner owner in storeOwners)
                if (owner.GetStore().Equals(store))
                    return owner;
            return null;
        }

        public StoreManager GetManager(Store store)
        {
            foreach (StoreManager manager in storeManagers)
                if (manager.GetStore().Equals(store))
                    return manager;
            return null;
        }
    }
}
