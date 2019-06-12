using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
namespace Workshop192.UserManagment
{
    public class User
    {
        private UserInfo info;
        private int multiCartId;

        public User()
        {
            info = null;
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
        }
            
        public bool LogIn(UserInfo info)
        {
            if (IsLoggedIn() || info == null)
                return false;
            this.info = info;
            multiCartId = info.GetMultiCart();
            return true;
        }

        public bool LogOut()
        {
            if (!IsLoggedIn())
                return false;
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
            info = null;
            return true;
        }

        public bool SetAdmin()
        {
            if (!IsLoggedIn())
                return false;
            return info.SetAdmin();
        }

        public bool OpenStore(string storeName)
        {
            if (IsLoggedIn())
                return info.OpenStore(storeName);
            return false;
        }

        public bool AddProducts(string store, Product product, int amount)
        {
            if (IsLoggedIn())
                return info.AddProducts(store, product, amount);
            return false;
        }

        public bool RemoveProductFromInventory(string store, int productId)
        {
            if (IsLoggedIn())
                return info.RemoveProductFromInventory(store, productId);
            return false;
        }

        public bool EditProduct(string store, int productId, string name, string category, int price, int amount)
        {
            if (IsLoggedIn())
                return info.EditProduct(store, productId, name, category, price, amount);
            return false;
        }

        public bool AddStoreOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn() || user == null)
                return false;
            return info.AddStoreOwner(store, user);
        }

        public bool AcceptOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn() || user == null)
                return false;
            return info.AcceptOwner(store, user);
        }

        public bool DeclineOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn() || user == null)
                return false;
            return info.DeclineOwner(store, user);
        }

        public bool AddDiscountPolicy(string store, PolicyComponent policy, int discount, int productId)
        {
            if (!IsLoggedIn())
                return false;
            return info.AddDiscountPolicy(store, policy, discount, productId);
        }

        public bool AddSellingPolicy(string store, PolicyComponent policy, int productId)
        {
            if (!IsLoggedIn())
                return false;
            return info.AddSellingPolicy(store, policy, productId);
        }

        public bool RemoveDiscountPolicy(string store, int policyId, int productId)
        {
            if (!IsLoggedIn())
                return false;
            return info.RemoveDiscountPolicy(store, policyId, productId);
        }

        public bool RemoveSellingPolicy(string store, int policyId, int productId)
        {
            if (!IsLoggedIn())
                return false;
            return info.RemoveSellingPolicy(store, policyId, productId);
        }

        public bool AddStoreManager(string store, UserInfo user, bool[] privileges)
        {
            if (!IsLoggedIn() || user == null)
                return false;
            return info.AddStoreManager(store, user, privileges);
        }

        public bool RemoveStoreManager(string store, UserInfo user)
        {
            if (!IsLoggedIn() || user == null)
                return false;
            return info.RemoveStoreManager(store, user);
        }

        public bool AddProductsToMultiCart(string store, int productId, int amount)
        {
            return MarketManagment.System.GetInstance().GetMultiCart(multiCartId).AddProductsToMultiCart(MarketManagment.System.GetInstance().GetStore(store), productId, amount);
        }

        public bool RemoveProductFromCart(int productId)
        {
            return MarketManagment.System.GetInstance().GetMultiCart(multiCartId).RemoveProductFromMultiCart(productId);
        }

        public bool RemoveUser(string userName)
        {
            if (!IsLoggedIn())
                return false;
            return info.RemoveUser(userName);
        }
        
        public string GetUserName()
        {
            if (!IsLoggedIn())
                return "";
            return info.GetUserName();
        }

        public int GetMultiCart()
        {
            return multiCartId;
        }

        public bool IsAdmin()
        {
            if (!IsLoggedIn())
                return false;
            return info.IsAdmin();
        }

        public bool IsLoggedIn()
        {
            if (info == null)
                return false;
            return true;
        }

        public UserInfo GetInfo()
        {
            return info;
        }
    }
}