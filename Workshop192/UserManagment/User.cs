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
        private string userName;
        private bool loggedIn;
        private bool admin;
        private LinkedList<Cart> carts;
        private LinkedList<StoreOwner> stores;

        public User()
        {
            userName = "";
            loggedIn = false;
            admin = false;
            carts = new LinkedList<Cart>();
            stores = new LinkedList<StoreOwner>();
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

        public void AddStore(StoreOwner store)
        {
            stores.AddLast(store);
        }

        public bool RemoveStore(StoreOwner store)
        {
            return stores.Remove(store);
        }

        public void AddCart(Cart cart)
        {
            carts.AddLast(cart);
        }

        public bool RemoveCart(Cart cart)
        {
            return carts.Remove(cart);
        }

        public string GetName()
        {
            return userName;
        }
        
        public LinkedList<StoreOwner> GetStores()
        {
            return stores;
        }
    }
}
