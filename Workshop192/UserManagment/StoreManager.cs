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
                return MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount);
            }
            return false;
        }

        public bool RemoveProductFromInventory(int productId)
        {
            if (privileges[1])
            {
                return MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId);
            }
            return false;
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            if (privileges[2])
            {
                return MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount);
            }
            return false;
        }

        public bool AddDiscountPolicy(PolicyComponent policy, int discount, int productId)
        {
            if (!privileges[3])
                return false;
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
            if (!privileges[4])
                return false;
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
            if (!privileges[5])
                return false;
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
            if (!privileges[6])
                return false;
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
