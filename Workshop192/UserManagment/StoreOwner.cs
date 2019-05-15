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
        protected User user;
        protected Store store;
        protected LinkedList<StoreOwner> children;
        protected StoreOwner father;

        public StoreOwner(User user, Store store, StoreOwner father)
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

        public virtual void AddOwner(User user)
        {
            children.AddLast(new StoreOwner(user, store, this));
        }

        public virtual void AddManager(User user, bool[] privileges)
        {
            children.AddLast(new StoreManager(user, store, this, privileges));
        }

        public virtual bool RemoveChild(StoreOwner child)
        {
            return ForceRemoveChild(child);
        }

        public bool ForceRemoveChild(StoreOwner child)
        {
            foreach (StoreOwner tmp in child.children)
                ForceRemoveChild(tmp);
            return child.user.RemoveStoreOwner(child) && father.children.Remove(child);
        }

        public User GetUser()
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

        public Store GetStore()
        {
            return store;
        }
    }
}
