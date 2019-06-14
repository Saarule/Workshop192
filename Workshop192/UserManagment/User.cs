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
            if (IsLoggedIn())
                throw new ErrorMessageException("User is already logged in");
            if (info == null)
                throw new ErrorMessageException("Invalid user info");
            this.info = info;
            MarketManagment.System.GetInstance().ResetMultiCart(multiCartId);
            multiCartId = info.GetMultiCart();
            return true;
        }

        public bool LogOut()
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Not logged in");
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
            info = null;
            return true;
        }

        public bool MakeAdmin(UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't make admin while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
            return user.MakeAdmin(user);
        }

        public bool OpenStore(string storeName)
        {
            if (IsLoggedIn())
                return info.OpenStore(storeName);
            throw new ErrorMessageException("Can't open store while not logged in");
        }

        public bool AddProducts(string store, Product product, int amount)
        {
            if (IsLoggedIn())
                return info.AddProducts(store, product, amount);
            throw new ErrorMessageException("Can't add products to store while not logged in");
        }

        public bool RemoveProductFromInventory(string store, int productId)
        {
            if (IsLoggedIn())
                return info.RemoveProductFromInventory(store, productId);
            throw new ErrorMessageException("Can't remove products from store while not logged in");
        }

        public bool EditProduct(string store, int productId, string name, string category, int price, int amount)
        {
            if (IsLoggedIn())
                return info.EditProduct(store, productId, name, category, price, amount);
            throw new ErrorMessageException("Can't edit products while not logged in");
        }

        public bool AddStoreOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't add store owner while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
            return info.AddStoreOwner(store, user);
        }

        public bool AcceptOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't accept store owner while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
            return info.AcceptOwner(store, user);
        }

        public bool DeclineOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't decline store owner while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
            return info.DeclineOwner(store, user);
        }

        public bool AddDiscountPolicy(string store, PolicyComponent policy, int discount, int productId)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't add discount policy while not logged in");
            return info.AddDiscountPolicy(store, policy, discount, productId);
        }

        public bool AddSellingPolicy(string store, PolicyComponent policy, int productId)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't add selling policy while not logged in");
            return info.AddSellingPolicy(store, policy, productId);
        }

        public bool RemoveDiscountPolicy(string store, int policyId, int productId)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't remove discount policy while not logged in");
            return info.RemoveDiscountPolicy(store, policyId, productId);
        }

        public bool RemoveSellingPolicy(string store, int policyId, int productId)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't remove selling policy while not logged in");
            return info.RemoveSellingPolicy(store, policyId, productId);
        }

        public bool AddStoreManager(string store, UserInfo user, bool[] privileges)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't add store manager while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
            return info.AddStoreManager(store, user, privileges);
        }

        public bool RemoveStoreManager(string store, UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't remove store manager while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
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

        public bool RemoveUser(UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Can't remove registered user while not logged in");
            if (user == null)
                throw new ErrorMessageException("Given user dosen't exist");
            return info.RemoveUser(user);
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