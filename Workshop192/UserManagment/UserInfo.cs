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
        public string userName { get; set; }
        public string password { get; set; }
        public virtual Admin admin { get; set; }
        public virtual LinkedList<StoreOwner> storeOwners { get; set; }
        public virtual LinkedList<StoreManager> storeManagers { get; set; }
        public int multiCartId { get; set; }

        public UserInfo(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            admin = null;
            storeOwners = new LinkedList<StoreOwner>();
            storeManagers = new LinkedList<StoreManager>();
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
        }

        public bool SetAdmin()
        {
            if (IsAdmin())
                throw new ErrorMessageException("This user is already admin");
            admin = new Admin(this);
            DbCommerce.GetInstance().SaveDb();
            return true;
        }

        public bool MakeAdmin(UserInfo user)
        {
            if (!IsAdmin())
                throw new ErrorMessageException("This user doesnt have admin rights");
            return admin.MakeAdmin(user);
        }

        public bool OpenStore(string storeName)
        {
            if (storeName.Equals("") || MarketManagment.System.GetInstance().GetStore(storeName) != null)
                throw new ErrorMessageException("A store with the given name already exists");
            MarketManagment.System.GetInstance().OpenStore(storeName);
            storeOwners.AddLast(new StoreOwner(this, storeName, null));
            for(int i=0;i< AllRegisteredUsers.GetInstance().GetAllUserNames().Count; i++)
            {
                Notifications.Notification.GetInstance().SendMessageToUser(AllRegisteredUsers.GetInstance().GetAllUserNames().ElementAt(i), "the shop " + storeName + " was opened now!");
            }
            DbCommerce.GetInstance().SaveDb();
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
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool RemoveProductFromInventory(string store, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveProductFromInventory(productId);
            if (manager != null)
                return manager.RemoveProductFromInventory(productId);
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool EditProduct(string store, int productId, string name, string category, int price, int amount)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.EditProduct(productId, name, category, price, amount);
            if (manager != null)
                return manager.EditProduct(productId, name, category, price, amount);
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool AddStoreOwner(string store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
            return s.AddOwner(user);
        }

        public bool AcceptOwner(string store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
            return s.AcceptOwner(user);
        }

        public bool DeclineOwner(string store, UserInfo user)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
            return s.DeclineOwner(user);
        }

        public bool AddDiscountPolicy(string store, LinkedList<string> policy, int discount)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.AddDiscountPolicy(policy, discount);
            if (manager != null)
                return manager.AddDiscountPolicy(policy, discount);
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool AddSellingPolicy(string store, LinkedList<string> policy)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.AddSellingPolicy(policy);
            if (manager != null)
                return manager.AddSellingPolicy(policy);
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool RemoveDiscountPolicy(string store, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveDiscountPolicy(productId);
            if (manager != null)
                return manager.RemoveDiscountPolicy(productId);
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool RemoveSellingPolicy(string store, int productId)
        {
            StoreOwner owner = GetOwner(store);
            StoreManager manager = GetManager(store);
            if (owner != null)
                return owner.RemoveSellingPolicy(productId);
            if (manager != null)
                return manager.RemoveSellingPolicy(productId);
            throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
        }

        public bool AddStoreManager(string store, UserInfo user, bool[] privileges)
        {
            StoreOwner s = GetOwner(store);
            if (s == null)
                throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
            return s.AddManager(user, privileges);
        }

        public bool RemoveStoreManager(string store, UserInfo user)
        {
            StoreOwner owner = GetOwner(store);
            if (owner == null)
                throw new ErrorMessageException("This user isnt a store owner/manager of store [" + store + "]");
            return owner.RemoveAppointedManager(user);
            throw new ErrorMessageException("The given user isnt a store manager of store [" + store + "]");
        }

        public bool RemoveUser(UserInfo user)
        {
            if (!IsAdmin())
                throw new ErrorMessageException("This user doesnt have admin rights");
            return admin.RemoveUser(user);
        }

        public int GetMultiCart()
        {
            return multiCartId;
        }

        public string GetUserName()
        {
            return userName;
        }

        public string GetPassword()
        {
            return password;
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
