﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class StoreOwner
    {
        protected UserState user;
        protected Store store;
        protected LinkedList<StoreOwner> children;
        protected StoreOwner father;

        public StoreOwner(UserState user, Store store, StoreOwner father)
        {
            this.user = user;
            this.store = store;
            this.father = father;
            children = new LinkedList<StoreOwner>();
        }

        public virtual bool AddProduct(Product product)
        {
            foreach (Product p in store.GetProducts())
                if (p.Equals(product))
                    return false;
            store.GetProducts().AddLast(product);
            return true;
        }

        public virtual bool RemoveProduct(Product product)
        {
            return store.GetProducts().Remove(product);
        }

        public virtual bool EditProduct(Product oldProduct, Product newProduct)
        {
            if (!store.GetProducts().Remove(oldProduct))
                return false;
            store.GetProducts().AddLast(newProduct);
            return true;
        }

        public virtual bool AddOwner(UserState user)
        {
            if (CheckUserExists(user))
                return false;
            StoreOwner owner = new StoreOwner(user, store, this);
            user.GetStoreOwners().AddLast(owner);
            children.AddLast(owner);
            return true;
        }

        public virtual bool AddManager(UserState user, bool[] privileges)
        {
            if (CheckUserExists(user))
                return false;
            StoreOwner owner = new StoreManager(user, store, this, privileges);
            user.GetStoreOwners().AddLast(owner);
            children.AddLast(owner);
            return true;
        }

        public virtual bool RemoveChild(StoreOwner child)
        {
            return ForceRemoveChild(child);
        }

        public bool ForceRemoveChild(StoreOwner child)
        {
            while (child.children.Count > 0)
                ForceRemoveChild(child.children.First.Value);
            return child.user.GetStoreOwners().Remove(child) && (child.father == null || child.father.children.Remove(child));
        }

        public UserState GetUser()
        {
            return user;
        }

        public Store GetStore()
        {
            return store;
        }

        public LinkedList<StoreOwner> GetChildren()
        {
            return children;
        }

        public StoreOwner GetFather()
        {
            return father;
        }

        public bool CheckUserExists(UserState user)
        {
            StoreOwner storeOwner = this;
            while (storeOwner.father != null)
                storeOwner = storeOwner.father;
            return CheckUserExists2(storeOwner, user);
        }

        public bool CheckUserExists2(StoreOwner storeOwner, UserState user)
        {
            bool ret = false;
            if (storeOwner.GetUser().Equals(user))
                return true; ;
            foreach (StoreOwner s in storeOwner.children)
                ret = ret || CheckUserExists2(s, user);
            return ret;
        }
    }
}
