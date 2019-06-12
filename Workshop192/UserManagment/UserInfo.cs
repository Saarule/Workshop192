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
        private Admin admin;
        private LinkedList<StoreOwner> storeOwners;
        private LinkedList<StoreManager> storeManagers;
        private int multiCartId;

        public UserInfo(string userName)
        {
            this.userName = userName;
            admin = null;
            storeOwners = new LinkedList<StoreOwner>();
            storeManagers = new LinkedList<StoreManager>();
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
        }

        public bool SetAdmin()
        {
            if (!IsAdmin())
                return false;
            admin = new Admin();
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

        public bool AddProducts(string store, Product product, int amount)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
            {
                return owner.AddProducts(product, amount);
            }
            if (manager != null)
                return manager.AddProducts(product, amount);
            return false;
        }

        public bool RemoveProductFromInventory(string store, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveProductFromInventory(productId);
            if (manager != null)
                return manager.RemoveProductFromInventory(productId);
            return false;
        }

        public bool EditProduct(string store, int productId, string name, string category, int price, int amount)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.EditProduct(productId, name, category, price, amount);
            if (manager != null)
                return manager.EditProduct(productId, name, category, price, amount);
            return false;
        }

        public bool AddStoreOwner(string store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AddOwner(user);
        }

        public bool AcceptOwner(string store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AcceptOwner(user);
        }

        public bool DeclineOwner(string store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.DeclineOwner(user);
        }

        public bool AddDiscountPolicy(string store, PolicyComponent policy, int discount, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.AddDiscountPolicy(policy, discount, productId);
            if (manager != null)
                return manager.AddDiscountPolicy(policy, discount, productId);
            return false;
        }

        public bool AddSellingPolicy(string store, PolicyComponent policy, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.AddSellingPolicy(policy, productId);
            if (manager != null)
                return manager.AddSellingPolicy(policy, productId);
            return false;
        }

        public bool RemoveDiscountPolicy(string store, int policyId, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveDiscountPolicy(policyId, productId);
            if (manager != null)
                return manager.RemoveDiscountPolicy(policyId, productId);
            return false;
        }

        public bool RemoveSellingPolicy(string store, int policyId, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveSellingPolicy(policyId, productId);
            if (manager != null)
                return manager.RemoveSellingPolicy(policyId, productId);
            return false;
        }

        public bool AddStoreManager(string store, UserInfo user, bool[] privileges)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                return false;
            return s.AddManager(user, privileges);
        }

        public bool RemoveStoreManager(string store, UserInfo user)
        {
            StoreOwner owner = GetOwner(store);
            if (owner == null)
                return false;
            foreach (StoreManager manager in owner.GetAppointedManagers())
                if (manager.GetUser().Equals(user))
                    return owner.RemoveAppointedManager(manager);
            return false;
        }

        public bool RemoveUser(string userName)
        {
            if (!IsAdmin())
                return false;
            return admin.RemoveUser(userName);
        }

        public int GetMultiCart()
        {
            return multiCartId;
        }

        public string GetUserName()
        {
            return userName;
        }

        public bool IsAdmin()
        {
            return admin != null;
        }

        public Admin GetAdmin()
        {
            return admin;
        }

        public StoreOwner GetOwner(string store)
        {
            foreach (StoreOwner owner in storeOwners)
                if (owner.GetStore().Equals(store))
                    return owner;
            return null;
        }

        public StoreManager GetManager(string store)
        {
            foreach (StoreManager manager in storeManagers)
                if (manager.GetStore().Equals(store))
                    return manager;
            return null;
        }
    }
}
