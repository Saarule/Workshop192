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

        public bool OpenStore(string storeName)
        {
            if (state != null)
                return state.OpenStore(storeName);
            return false;
        }

        public bool AddProducts(string store, Product product, int amount)
        {
            if (state != null)
                return state.AddProducts(store, product, amount);
            return false;
        }

        public bool RemoveProductFromInventory(string store, int productId)
        {
            if (state != null)
                return state.RemoveProductFromInventory(store, productId);
            return false;
        }

        public bool EditProduct(string store, int productId, string name, string category, int price, int amount)
        {
            if (state != null)
                return state.EditProduct(store, productId, name, category, price, amount);
            return false;
        }

        public bool AddStoreOwner(string store, UserInfo user)
        {
            if (state == null || user == null)
                return false;
            return state.AddStoreOwner(store, user);
        }

        public bool AddStoreManager(string store, UserInfo user, bool[] privileges)
        {
            if (state == null || user == null)
                return false;
            return state.AddStoreManager(store, user, privileges);
        }

        public bool RemoveStoreOwner(string store, UserInfo user)
        {
            if (state == null || user == null)
                return false;
            return state.RemoveStoreOwner(store, user);
        }

        public bool RemoveStoreManager(string store, UserInfo user)
        {
            if (state == null || user == null)
                return false;
            return state.RemoveStoreManager(store, user);
        }

        public bool AddProductsToMultiCart(string store, Product product, int amount)
        {
            return MarketManagment.System.GetInstance().GetMultiCart(multiCartId).AddProductsToMultiCart(MarketManagment.System.GetInstance().GetStore(store), product, amount);
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