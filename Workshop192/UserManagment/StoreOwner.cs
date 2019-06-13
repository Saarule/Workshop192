using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class StoreOwner
    {
        private UserInfo user;
        private string store;
        private StoreOwnersOfStore storeOwners;
        private LinkedList<StoreManager> appointedManagers;
        private LinkedList<UserInfo> pendingUsers;

        public StoreOwner(UserInfo user, string store, StoreOwnersOfStore storeOwners)
        {
            this.user = user;
            this.store = store;
            if (storeOwners != null)
            {
                this.storeOwners = storeOwners;
                storeOwners.GetStoreOwners().AddLast(this);
            }
            else
                this.storeOwners = new StoreOwnersOfStore(this);
            appointedManagers = new LinkedList<StoreManager>();
            pendingUsers = new LinkedList<UserInfo>();
        }

        public bool AddProducts(Product product, int amount)
        {
            return MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount);
        }

        public bool RemoveProductFromInventory(int productId)
        {
            return MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId);
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            return MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount);
        }

        public bool AddOwner(UserInfo user)
        {
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                if (owner.GetUser().Equals(user) || owner.pendingUsers.Contains(user))
                    return false;
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                owner.pendingUsers.AddLast(user);
            pendingUsers.Remove(user);
            if (storeOwners.GetStoreOwners().Count == 1)
                AddOwnerFinal(user);
            return true;
        }

        private void AddOwnerFinal(UserInfo user)
        {
            user.GetStoreOwners().AddLast(new StoreOwner(user, store, storeOwners));
        }

        public bool AcceptOwner(UserInfo user)
        {
            if (!pendingUsers.Contains(user))
                return false;
            pendingUsers.Remove(user);
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                if (owner.pendingUsers.Contains(user))
                    return true;
            AddOwnerFinal(user);
            return true;
        }

        public bool DeclineOwner(UserInfo user)
        {
            if (!pendingUsers.Contains(user))
                return false;
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                owner.pendingUsers.Remove(user);
            return true;
        }

        public bool AddManager(UserInfo user, bool[] privileges)
        {
            if (CheckUserExists(user))
                return false;
            StoreManager manager = new StoreManager(user, store, privileges, this);
            user.GetStoreManagers().AddLast(manager);
            appointedManagers.AddLast(manager);
            return true;
        }

        public bool RemoveAppointedManager(StoreManager child)
        {
            foreach (StoreManager manager in appointedManagers)
                if (manager.Equals(child))
                {
                    manager.RemoveSelf();
                    return true;
                }
            return false;
        }

        public bool AddDiscountPolicy(PolicyComponent policy, int discount, int productId)
        {
            if (productId == 0)
                MarketManagment.System.GetInstance().GetStore(store).AddDiscountPolicy(policy, discount);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        productAmount.Key.AddDiscountPolicy(policy, discount);
                        return true;
                    }
            return false;
        }

        public bool AddSellingPolicy(PolicyComponent policy, int productId)
        {
            if (productId == 0)
                MarketManagment.System.GetInstance().GetStore(store).AddSellingPolicy(policy);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        productAmount.Key.AddSellingPolicy(policy);
                        return true;
                    }
            return false;
        }

        public bool RemoveDiscountPolicy(int policyId, int productId)
        {
            if (productId == 0)
                return MarketManagment.System.GetInstance().GetStore(store).RemoveDiscountPolicy(policyId);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        return productAmount.Key.RemoveDiscountPolicy(policyId);
                    }
            return false;
        }

        public bool RemoveSellingPolicy(int policyId, int productId)
        {
            if (productId == 0)
                return MarketManagment.System.GetInstance().GetStore(store).RemoveSellingPolicy(policyId);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        return productAmount.Key.RemoveSellingPolicy(policyId);
                    }
            return false;
        }

        public void RemoveSelf()
        {
            while (appointedManagers.Count > 0)
                appointedManagers.First.Value.RemoveSelf();
            user.GetStoreOwners().Remove(this);
            storeOwners.GetStoreOwners().Remove(this);
            if (storeOwners.GetStoreOwners().Count == 0)
                MarketManagment.System.GetInstance().GetAllStores().Remove(MarketManagment.System.GetInstance().GetStore(store));
        }

        public bool CheckUserExists(UserInfo user)
        {
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
            {
                if (owner.user.Equals(user))
                    return true;
                foreach (StoreManager manager in owner.appointedManagers)
                    if (manager.GetUser().Equals(user))
                        return true;
            }
            return false;
        }

        public UserInfo GetUser()
        {
            return user;
        }

        public string GetStore()
        {
            return store;
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            return storeOwners.GetStoreOwners();
        }

        public LinkedList<StoreManager> GetAppointedManagers()
        {
            return appointedManagers;
        }
        public LinkedList<string> GetPendingUsers() {
            LinkedList<string> result = new LinkedList<string>();
            for(int i = 0; i < pendingUsers.Count; i++)
            {
                result.AddLast(pendingUsers.ElementAt(i).GetUserName());
            }
            return result;
        }
    }
}
