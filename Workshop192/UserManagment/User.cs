using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    class User
    {
        private string userName;
        private bool loggedIn;
        private bool admin;
        private LinkedList<Cart> carts;
        private LinkedList<StoreOwner> storesOwned;

        public User()
        {
            userName = "";
            loggedIn = false;
            admin = false;
            carts = new LinkedList<Cart>();
            storesOwned = new LinkedList<StoreOwner>();
        }

        public void SetAdmin()
        {
            admin = true;
        }

        public void Register(string userName)
        {
            this.userName = userName;
        }

        public void LogIn()
        {
            loggedIn = true;
        }

        public void LogOut()
        {
            loggedIn = false;
        }

        public void AddStoreOwner(StoreOwner store)
        {
            storesOwned.AddLast(store);
        }

        public bool RemoveStoreOwner(StoreOwner store)
        {
            return storesOwned.Remove(store);
        }

        public void AddProductToCart(Product product, Store store)
        {
            foreach (Cart cart in carts)
                if (cart.GetStore().Equals(store))
                {
                    cart.AddProduct(product);
                    return;
                }
        }

        public bool RemoveProductFromCart(Product product)
        {
            foreach (Cart cart in carts)
                foreach (Product pro in cart.GetProducts())
                    if (pro.Equals(product))
                        return cart.GetProducts().Remove(product);
            return false;
        }

        public string GetName()
        {
            return userName;
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }

        public bool IsLoggedIn()
        {
            return loggedIn;
        }

        public bool IsAdmin()
        {
            return admin;
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            return storesOwned;
        }
    }
}
