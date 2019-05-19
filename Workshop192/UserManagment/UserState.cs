﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class UserState
    {
        private string userName;
        private bool admin;
        private LinkedList<StoreOwner> storeOwners;
        private LinkedList<Cart> carts;

        public UserState(string userName)
        {
            this.userName = userName;
            admin = false;
            storeOwners = new LinkedList<StoreOwner>();
            carts = new LinkedList<Cart>();
        }

        public bool SetAdmin()
        {
            if (admin)
                return false;
            admin = true;
            return true;
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            return storeOwners;
        }

        public bool AddStoreOwner(StoreOwner store)
        {
            if (storeOwners.Contains(store))
                return false;
            storeOwners.AddLast(store);
            return true;
        }

        public bool RemoveStoreOwner(StoreOwner store)
        {
            return storeOwners.Remove(store);
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }

        public string GetUserName()
        {
            return userName;
        }

        public bool GetAdmin()
        {
            return admin;
        }
    }
}
