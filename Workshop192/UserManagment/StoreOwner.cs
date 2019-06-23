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
        public string userName { get; set; }
        public virtual UserInfo user { get; set; }
        public string store { get; set; }
        public virtual StoreOwnersOfStore storeOwners { get; set; }
        public virtual LinkedList<StoreManager> appointedManagers { get; set; }
        public string pendingUsers { get; set; }

        public StoreOwner(UserInfo user, string store, StoreOwnersOfStore storeOwners)
        {
            userName = user.GetUserName();
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
            pendingUsers = null;
        }

        public StoreOwner() //Only for Entity Framework references should be 0
        { }

        public bool AddProducts(Product product, int amount)
        {
            if (MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount))
            {
                Logger.GetInstance().WriteToEventLog(user.GetUserName() + " Added Product [" + product.GetId() + "] [" + product.GetName() + "] [" + product.GetCategory() + "] [" + product.GetPrice() + "] [" + amount + "] as a owner of store [" + store + "]");
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            return false;
        }

        public bool RemoveProductFromInventory(int productId)
        {
            if (MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId))
            {
                Logger.GetInstance().WriteToEventLog(user.GetUserName() + " removed Product [" + productId + "] as a owner of store [" + store + "]");
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            return false;
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            if (MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount))
            {
                Logger.GetInstance().WriteToEventLog(user.GetUserName() + " edited product [" + productId + "] to: [" + name + "] [" + category + "] [" + price + "] [" + amount + "] as owner of store [" + store + "]");
                DbCommerce.GetInstance().SaveDb();
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
                if (owner.GetUser().Equals(user) || owner.GetPendingUsers().Contains(user))
                {
                    Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried adding user " + user.GetUserName() + " as a owner but the given user is already a apending owner of store [" + store + "]");
                    throw new ErrorMessageException("The given user is already a pending owner");
                }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " initiated the owner adding proccess to user " + user.GetUserName() + " for store [" + store + "]");
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                owner.pendingUsers += "$" + user.GetUserName();
            pendingUsers = pendingUsers.Replace(user.GetUserName(), "");
            if (storeOwners.GetStoreOwners().Count == 1)
                AddOwnerFinal(user);
            else//push notifications to store owners for accept the appointment
                foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                    Notifications.Notification.GetInstance().SendMessageToUser(owner.GetUser().GetUserName(), user.GetUserName() + " is waiting for you to accept his appointment to be store owner in store:" + store);
            DbCommerce.GetInstance().SaveDb();
            return true;
        }

        private void AddOwnerFinal(UserInfo user)
        {
            user.GetStoreOwners().AddLast(new StoreOwner(user, store, storeOwners));
            Logger.GetInstance().WriteToEventLog(user.GetUserName() + " Is now a owner of store [" + store + "]");
            try//push notifications
            {
                string message = user.GetUserName() + " is added to be owner in store:" + store;
                
                for (int i = 0; i < storeOwners.GetStoreOwners().Count; i++)
                {
                    Notifications.Notification.GetInstance().SendMessageToUser(storeOwners.GetStoreOwners().ElementAt(i).GetUser().GetUserName(), message);
                }
                Notifications.Notification.GetInstance().SendMessageToUser(user.GetUserName(), "You assigned to be owner in store:" + store);


            }
            catch (Exception)
            { }
        }

        public bool AcceptOwner(UserInfo user)
        {
            if (!GetPendingUsers().Contains(user))
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried accepting user " + user.GetUserName() + " as a owner of store [" + store + "] but the given user wasn't on their pending list");
                throw new ErrorMessageException("The given user isnt in your pending users list");
            }
            pendingUsers = pendingUsers.Replace(user.GetUserName(), "");
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " accepted user " + user.GetUserName() + " as a owner in store [" + store + "]");
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                if (owner.GetPendingUsers().Contains(user))
                {
                    DbCommerce.GetInstance().SaveDb();
                    return true;
                }
            AddOwnerFinal(user);
            DbCommerce.GetInstance().SaveDb();
            return true;
        }

        public bool DeclineOwner(UserInfo user)
        {
            if (!GetPendingUsers().Contains(user))
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried declining user " + user.GetUserName() + " as a owner of store [" + store + "] but the given user wasn't on their pending list");
                throw new ErrorMessageException("The given user isnt in your pending users list");
            }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " declined user " + user.GetUserName() + " as a owner in store [" + store + "]");
            foreach (StoreOwner owner in storeOwners.GetStoreOwners())
                owner.pendingUsers = owner.pendingUsers.Replace(user.GetUserName(), "");
            DbCommerce.GetInstance().SaveDb();
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
            DbCommerce.GetInstance().SaveDb();
            try {//push notifications
                string message = user.GetUserName() + " is added to be manager in store:" + store;
                for(int i=0;i< storeOwners.GetStoreOwners().Count; i++)
                {
                    Notifications.Notification.GetInstance().SendMessageToUser(storeOwners.GetStoreOwners().ElementAt(i).GetUser().GetUserName(), message);

                }
                Notifications.Notification.GetInstance().SendMessageToUser(user.GetUserName(), "you assigned to be manager in store:" + store);

            }
            catch (Exception)
            { }
            return true;
        }

        public bool RemoveAppointedManager(UserInfo child)
        {
            foreach (StoreManager manager in appointedManagers)
                if (manager.GetUser().Equals(child))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " removed appointed manager " + child.GetUserName() + " of store [" + store + "]");
                    manager.RemoveSelf();
                    DbCommerce.GetInstance().SaveDb();
                    try//push notifications
                    {
                        string message = child.GetUserName() + " is removed from being a manager in store:" + store;

                        for (int i = 0; i < storeOwners.GetStoreOwners().Count; i++)
                        {
                            Notifications.Notification.GetInstance().SendMessageToUser(storeOwners.GetStoreOwners().ElementAt(i).GetUser().GetUserName(), message);

                        }
                        Notifications.Notification.GetInstance().SendMessageToUser(child.GetUserName(), "you removed from being  manager in store:" + store);

                    }
                    catch (Exception)
                    { }
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
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(Int32.Parse(policy.ElementAt(2))))
                    {
                        productAmount.product.AddDiscountPolicy(policy, discount);
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public bool AddSellingPolicy(LinkedList<string> policy)
        {
            if (int.Parse(policy.ElementAt(2)) == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).AddSellingPolicy(policy);
                return true;
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(Int32.Parse(policy.ElementAt(2))))
                    {
                        productAmount.product.AddSellingPolicy(policy);
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public bool RemoveDiscountPolicy(int productId)
        {
            if (productId == 0)
            {
                return MarketManagment.System.GetInstance().GetStore(store).RemoveDiscountPolicy();
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(productId))
                    {
                        return productAmount.product.RemoveDiscountPolicy();
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public bool RemoveSellingPolicy(int productId)
        {
            if (productId == 0)
            {
                return MarketManagment.System.GetInstance().GetStore(store).RemoveSellingPolicy();
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(productId))
                    {
                        return productAmount.product.RemoveSellingPolicy();
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

        public LinkedList<UserInfo> GetPendingUsers() {
            LinkedList<UserInfo> users = new LinkedList<UserInfo>();
            if (pendingUsers != null)
            {
                foreach (string str in pendingUsers.Split('$'))
                    users.AddLast(AllRegisteredUsers.GetInstance().GetUserInfo(str));
            }
            return users;
        }


    }
}
