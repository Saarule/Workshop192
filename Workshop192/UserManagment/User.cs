﻿using System;
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

        public void LogIn() { }

        public void LogOut() { }

        public bool AddStore() { }

        public bool RemoveStore() { }

        public bool AddCart() { }

        public bool RemoveCart() { }

        public string GetName() { }
    }
}
