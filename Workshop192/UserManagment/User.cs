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
        private UserInfo state;
        private int multiCartId;

        public User()
        {
            state = null;
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
        }

        public bool LogIn(UserInfo state)
        {
            if (this.state != null || state == null)
                return false;
            this.state = state;
            multiCartId = state.GetMultiCart();
            return true;
        }

        public bool LogOut()
        {
            if (state == null)
                return false;
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
            state = null;
            return true;
        }

        public bool SetAdmin()
        {
            if (state == null)
                return false;
            return state.SetAdmin();
        }

        public bool AddStoreOwner(Store store, UserInfo user)
        {
            if (state == null || user == null)
                return false;
            return state.AddStoreOwner(store, user);
        }

        public bool AddStoreManager(Store store, UserInfo user, bool[] privileges)
        {
            if (state == null || user == null)
                return false;
            return state.AddStoreManager(store, user, privileges);
        }

        public bool RemoveStoreOwner(Store store, UserInfo user)
        {
            if (state == null || user == null)
                return false;
            return state.RemoveStoreOwner(store, user);
        }

        public bool AddProductsToMultiCart(Store store, Product product, int amount)
        {
            return MarketManagment.System.GetInstance().GetMultiCart(multiCartId).AddProductsToMultiCart(store, product, amount);
        }

        public bool RemoveProductFromCart(Product product)
        {
            return MarketManagment.System.GetInstance().GetMultiCart(multiCartId).RemoveProductFromMultiCart(product);
        }
        
        public string GetUserName()
        {
            if (state == null)
                return "";
            return state.GetUserName();
        }

        public int GetMultiCart()
        {
            return multiCartId;
        }

        public bool IsAdmin()
        {
            if (state == null)
                return false;
            return state.GetAdmin();
        }

        public UserInfo GetState()
        {
            return state;
        }
    }
}