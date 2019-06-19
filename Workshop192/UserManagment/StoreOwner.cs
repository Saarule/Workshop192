﻿using System;
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
            if (MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount))
            {
                Logger.GetInstance().WriteToEventLog(user.GetUserName() + " Added Product [" + product.GetId() + "] [" + product.GetName() + "] [" + product.GetCategory() + "] [" + product.GetPrice() + "] [" + amount + "] as a owner of store [" + store + "]");
                return true;
            }
            return false;
        }

        public bool RemoveProductFromInventory(int productId)
        {
            if (MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId))
            {
                Logger.GetInstance().WriteToEventLog(user.GetUserName() + " removed Product [" + productId + "] as a owner of store [" + store + "]");
                return true;
            }
            return false;
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            if (MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount))
            {
                Logger.GetInstance().WriteToEventLog(user.GetUserName() + " edited product [" + productId + "] to: [" + name + "] [" + category + "] [" + price + "] [" + amount + "] as owner of store [" + store + "]");
                return true;
            }
            return false;
        }

        public bool AddOwner(UserInfo user)
        {
            if (CheckUserExists(user))
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried adding user " + user.GetUserName() + " as a owner but the given user is already a owner/manager of store [" + store + "]");
                throw new ErrorMessageException("The given user is already a store owner/manager in the store");
            }
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                if (owner.GetUser().Equals(user) || owner.pendingUsers.Contains(user))
                {
                    Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried adding user " + user.GetUserName() + " as a owner but the given user is already a apending owner of store [" + store + "]");
                    throw new ErrorMessageException("The given user is already a pending owner");
                }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " initiated the owner adding proccess to user " + user.GetUserName() + " for store [" + store + "]");
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
            Logger.GetInstance().WriteToEventLog(user.GetUserName() + " Is now a owner of store [" + store + "]");
        }

        public bool AcceptOwner(UserInfo user)
        {
            if (!pendingUsers.Contains(user))
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried accepting user " + user.GetUserName() + " as a owner of store [" + store + "] but the given user wasn't on their pending list");
                throw new ErrorMessageException("The given user isn't in your pending users list");
            }
            pendingUsers.Remove(user);
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " accepted user " + user.GetUserName() + " as a owner in store [" + store + "]");
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                if (owner.pendingUsers.Contains(user))
                    return true;
            AddOwnerFinal(user);
            return true;
        }

        public bool DeclineOwner(UserInfo user)
        {
            if (!pendingUsers.Contains(user))
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried declining user " + user.GetUserName() + " as a owner of store [" + store + "] but the given user wasn't on their pending list");
                throw new ErrorMessageException("The given user isn't in your pending users list");
            }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " declined user " + user.GetUserName() + " as a owner in store [" + store + "]");
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                owner.pendingUsers.Remove(user);
            return true;
        }

        public bool AddManager(UserInfo user, bool[] privileges)
        {
            if (CheckUserExists(user))
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried adding user " + user.GetUserName() + " as a manager but the given user is already a owner/manager of store [" + store + "]");
                throw new ErrorMessageException("The given user is already a store owner/manager in the store");
            }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " added user " + user.GetUserName() + " as a manager in store [" + store + "] with the following privileges " + privileges.ToString());
            StoreManager manager = new StoreManager(user, store, privileges, this);
            user.GetStoreManagers().AddLast(manager);
            appointedManagers.AddLast(manager);
            return true;
        }

        public bool RemoveAppointedManager(UserInfo child)
        {
            foreach (StoreManager manager in appointedManagers)
                if (manager.GetUser().Equals(child))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " removed appointed manager " + child.GetUserName() + " of store [" + store + "]");
                    manager.RemoveSelf();
                    return true;
                }
            Logger.GetInstance().WriteToEventLog(user.GetUserName() + " tried removing user " + child.GetUserName() + " from the store managers but the given user wasn't a manager of store [" + store + "]");
            throw new ErrorMessageException("The given user is not a store manager this user appointed");
        }

        public bool AddDiscountPolicy(LinkedList<string> policy, int discount)
        {
            if (Int32.Parse(policy.ElementAt(2)) == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).AddDiscountPolicy(policy, discount);
                return true;
            }
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(Int32.Parse(policy.ElementAt(2))))
                    {
                        productAmount.Key.AddDiscountPolicy(policy, discount);
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public bool AddSellingPolicy(LinkedList<string> policy)
        {
            if (int.Parse(policy.ElementAt(2)) == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).AddSellingPolicy(policy);
                return true;
            }
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(Int32.Parse(policy.ElementAt(2))))
                    {
                        productAmount.Key.AddSellingPolicy(policy);
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public bool RemoveDiscountPolicy(int productId)
        {
            if (productId == 0)
                return MarketManagment.System.GetInstance().GetStore(store).RemoveDiscountPolicy();
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        return productAmount.Key.RemoveDiscountPolicy();
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public bool RemoveSellingPolicy(int productId)
        {
            if (productId == 0)
                return MarketManagment.System.GetInstance().GetStore(store).RemoveSellingPolicy();
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        return productAmount.Key.RemoveSellingPolicy();
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
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
