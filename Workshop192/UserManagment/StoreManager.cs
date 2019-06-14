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
        private bool[] privileges;
        private UserInfo user;
        private string store;
        private StoreOwner owner;

        public StoreManager(UserInfo user, string store, bool[] privileges, StoreOwner owner)
        {
            this.privileges = privileges;
            this.user = user;
            this.store = store;
            this.owner = owner;
        }

        public bool AddProducts(Product product, int amount)
        {
            if (privileges[0])
            {
                if (MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " Added Product [" + product.GetId() + "] [" + product.GetName() + "] [" + product.GetCategory() + "] [" + product.GetPrice() + "] [" + amount + "] as a manager of store [" + store + "]");
                    return true;
                }
                return false;
            }
            Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried adding products to store [" + store + "] without privileges");
            throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
        }

        public bool RemoveProductFromInventory(int productId)
        {
            if (privileges[1])
            {
                if (MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " removed Product [" + productId  + "] as a manager of store [" + store + "]");
                    return true;
                }
                return false;
            }
            Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried removing products from store [" + store + "] without privileges");
            throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            if (privileges[2])
            {
                if (MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount))
                {
                    Logger.GetInstance().WriteToEventLog(user.GetUserName() + " edited product [" + productId + "] to: [" + name + "] [" + category + "] [" + price + "] [" + amount + "] as manager of store [" + store + "]");
                    return true;
                }
                return false;
            }
            Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried editing products of store [" + store + "] without privileges");
            throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
        }

        public bool AddDiscountPolicy(PolicyComponent policy, int discount, int productId)
        {
            if (!privileges[3])
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried adding discount policy to store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
            }
            if (productId == 0)
                MarketManagment.System.GetInstance().GetStore(store).AddDiscountPolicy(policy, discount);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        productAmount.Key.AddDiscountPolicy(policy, discount);
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public bool AddSellingPolicy(PolicyComponent policy, int productId)
        {
            if (!privileges[4])
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried adding selling policy to store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
            }
            if (productId == 0)
                MarketManagment.System.GetInstance().GetStore(store).AddSellingPolicy(policy);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        productAmount.Key.AddSellingPolicy(policy);
                        return true;
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public bool RemoveDiscountPolicy(int policyId, int productId)
        {
            if (!privileges[5])
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried removing discount policy of store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
            }
            if (productId == 0)
                return MarketManagment.System.GetInstance().GetStore(store).RemoveDiscountPolicy(policyId);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        return productAmount.Key.RemoveDiscountPolicy(policyId);
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public bool RemoveSellingPolicy(int policyId, int productId)
        {
            if (!privileges[6])
            {
                Logger.GetInstance().WriteToErrorLog(user.GetUserName() + " Tried removing selling policy of store [" + store + "] without privileges");
                throw new ErrorMessageException("This manager dosen't have the privilege to preform the given action");
            }
            if (productId == 0)
                return MarketManagment.System.GetInstance().GetStore(store).RemoveSellingPolicy(policyId);
            else
                foreach (KeyValuePair<Product, int> productAmount in MarketManagment.System.GetInstance().GetStore(store).GetInventory())
                    if (productAmount.Key.GetId().Equals(productId))
                    {
                        return productAmount.Key.RemoveSellingPolicy(policyId);
                    }
            throw new ErrorMessageException("Given product id doesn't exist in store");
        }

        public void RemoveSelf()
        {
            user.GetStoreManagers().Remove(this);
            owner.GetAppointedManagers().Remove(this);
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
            return privileges;
        }

        public StoreOwner GetOwner()
        {
            return owner;
        }
    }
}
