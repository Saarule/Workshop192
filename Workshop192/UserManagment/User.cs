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
        private UserState state;
        private LinkedList<Cart> carts;

        public User()
        {
            state = null;
            carts = new LinkedList<Cart>();
        }

        public bool LogIn(UserState state)
        {
            if (this.state != null || state == null)
                return false;
            this.state = state;
            carts = state.GetCarts();
            return true;
        }

        public bool LogOut()
        {
            if (state == null)
                return false;
            carts = new LinkedList<Cart>();
            state = null;
            return true;
        }

        public bool SetAdmin()
        {
            if (state == null)
                return false;
            return state.SetAdmin();
        }

        public bool AddStoreOwner(Store store, UserState user)
        {
            if (state == null || user == null)
                return false;
            return state.AddStoreOwner(store, user);
        }

        public bool AddStoreManager(Store store, UserState user, bool[] privileges)
        {
            if (state == null || user == null)
                return false;
            return state.AddStoreManager(store, user, privileges);
        }

        public bool RemoveStoreOwner(Store store, UserState user)
        {
            if (state == null || user == null)
                return false;
            return state.RemoveStoreOwner(store, user);
        }

        public bool AddProductToCart(Product product, Store store)
        {
            foreach (Cart cart in carts)
                if (cart.GetStore().Equals(store))
                {
                    return cart.AddProduct(product);
                }
            carts.AddLast(new Cart(store));
            return carts.Last.Value.AddProduct(product);
        }

        public bool RemoveProductFromCart(Product product)
        {
            foreach (Cart cart in carts)
                foreach (Product p in cart.GetProducts())
                    if (p.Equals(product))
                        return cart.RemoveProduct(product);
            return false;
        }
        
        public string GetUserName()
        {
            if (state == null)
                return "";
            return state.GetUserName();
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }

        public void ResetCarts()
        {
            carts = new LinkedList<Cart>();
        }

        public bool IsAdmin()
        {
            if (state == null)
                return false;
            return state.GetAdmin();
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            if (state == null)
                return null;
            return state.GetStoreOwners();
        }

        public UserState GetState()
        {
            return state;
        }
    }
}