using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class StoreManager
    {
        public bool p0 { get; set; }
        public bool p1 { get; set; }
        public bool p2 { get; set; }
        public bool p3 { get; set; }
        public bool p4 { get; set; }
        public bool p5 { get; set; }
        public bool p6 { get; set; }
        public virtual UserInfo user { get; set; }
        public string store { get; set; }
        public string owner { get; set; }
        public string userName { get; set; }

        public StoreManager(UserInfo user, string store, bool[] privileges, StoreOwner owner)
        {
            p0 = privileges[0]; p1 = privileges[1]; p2 = privileges[2]; p3 = privileges[3];
            p4 = privileges[4]; p5 = privileges[5]; p6 = privileges[6];
            this.user = user;
            this.store = store;
            this.owner = owner.userName;
            userName = user.GetUserName();
        }

        public StoreManager() //Only for Entity Framework references should be 0
        { }

        public bool AddProducts(Product product, int amount)
        {
            if (p0)
            {
                if (MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " Added Product [" + product.GetId() + "] [" + product.GetName() + "] [" + product.GetCategory() + "] [" + product.GetPrice() + "] [" + amount + "] as a manager of store [" + store + "]");
                    DbCommerce.GetInstance().SaveDb();
                    return true;
                }
                return false;
            }
            Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried adding products to store [" + store + "] without privileges");
            throw new ErrorMessageException("This manager dosent have the privilege to preform the given action");
        }

        public bool RemoveProductFromInventory(int productId)
        {
            if (p1)
            {
                if (MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " removed Product [" + productId  + "] as a manager of store [" + store + "]");
                    DbCommerce.GetInstance().SaveDb();
                    return true;
                }
                return false;
            }
            Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried removing products from store [" + store + "] without privileges");
            throw new ErrorMessageException("This manager dosent have the privilege to preform the given action");
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            if (p2)
            {
                if (MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " edited product [" + productId + "] to: [" + name + "] [" + category + "] [" + price + "] [" + amount + "] as manager of store [" + store + "]");
                    DbCommerce.GetInstance().SaveDb();
                    return true;
                }
                return false;
            }
            Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried editing products of store [" + store + "] without privileges");
            throw new ErrorMessageException("This manager dosent have the privilege to preform the given action");
        }

        public bool AddDiscountPolicy(LinkedList<string> policy, int discount)
        {
            if (!p3)
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried adding discount policy to store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosent have the privilege to preform the given action");
            }
            if (Int32.Parse(policy.ElementAt(2)) == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).AddDiscountPolicy(policy, discount);
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(Int32.Parse(policy.ElementAt(2))))
                    {
                        productAmount.product.AddDiscountPolicy(policy, discount);
                        DbCommerce.GetInstance().SaveDb();
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public bool AddSellingPolicy(LinkedList<string> policy)
        {
            if (!p4)
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried adding selling policy to store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosent have the privilege to preform the given action");
            }
            if (Int32.Parse(policy.ElementAt(2)) == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).AddSellingPolicy(policy);
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(Int32.Parse(policy.ElementAt(2))))
                    {
                        productAmount.product.AddSellingPolicy(policy);
                        DbCommerce.GetInstance().SaveDb();
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public bool RemoveDiscountPolicy(int productId)
        {
            if (!p5)
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried removing discount policy of store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
            }
            if (productId == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).RemoveDiscountPolicy();
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(productId))
                    {
                        productAmount.product.RemoveDiscountPolicy();
                        DbCommerce.GetInstance().SaveDb();
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public bool RemoveSellingPolicy(int productId)
        {
            if (!p6)
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried removing selling policy of store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosent have the privilege to preform the given action");
            }
            if (productId == 0)
            {
                MarketManagment.System.GetInstance().GetStore(store).RemoveSellingPolicy();
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            else
                foreach (ProductAmountInventory productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.productId.Equals(productId))
                    {
                        productAmount.product.RemoveSellingPolicy();
                        DbCommerce.GetInstance().SaveDb();
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesnt exist in store");
        }

        public void RemoveSelf()
        {
            user.GetStoreManagers().Remove(this);
            GetOwner().GetAppointedManagers().Remove(this);
        }

        public UserInfo GetUser()
        {
            return user;
        }

        public string GetStore()
        {
            return store;
        }

        public bool[] GetPrivileges()
        {
            return new bool[] { p0, p1, p2, p3, p4, p5, p6 };
        }

        public StoreOwner GetOwner()
        {
            return AllRegisteredUsers.GetInstance().GetUserInfo(owner).GetOwner(store);
        }
    }
}
