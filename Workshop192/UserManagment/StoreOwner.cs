using System;
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

        public virtual void AddProduct(Product product)
        {
            store.GetProducts().AddLast(product);
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
            user.AddStoreOwner(owner);
            children.AddLast(owner);
            return true;
        }

        public virtual bool AddManager(UserState user, bool[] privileges)
        {
            if (CheckUserExists(user))
                return false;
            StoreOwner owner = new StoreManager(user, store, this, privileges);
            user.AddStoreOwner(owner);
            children.AddLast(owner);
            return true;
        }

        public virtual bool RemoveChild(StoreOwner child)
        {
            return ForceRemoveChild(child);
        }

        public bool ForceRemoveChild(StoreOwner child)
        {
            foreach (StoreOwner tmp in child.children)
                ForceRemoveChild(tmp);
            return child.user.RemoveStoreOwner(child) && (father == null || father.children.Remove(child));
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
            bool exist = false;
            StoreOwner storeOwner = this;
            while (storeOwner.father != null)
                storeOwner = storeOwner.father;
            CheckUserExists2(storeOwner, user, exist);
            return exist;
        }

        public void CheckUserExists2(StoreOwner storeOwner, UserState user, bool exist)
        {
            if (exist || storeOwner.GetUser().Equals(user))
            {
                exist = true;
                return;
            }
            foreach (StoreOwner s in storeOwner.children)
                CheckUserExists2(s, user, exist);
        }
    }
}
