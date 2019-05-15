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

        public StoreOwner(User user, Store store, StoreOwner father) { }

        public virtual void AddProduct(Product product) { }

        public virtual bool RemoveProduct(Product product) { }

        public virtual bool EditProduct(Product oldProduct, Product newProduct) { }

        public virtual bool AddOwner(User user) { }

        public virtual bool AddManager(User user) { }

        public virtual bool RemoveChild(StoreOwner child) { }

        public Store GetStore() {
            return store;
        }
        public User GetUser()
        {
            return user;
        }
        public LinkedList<StoreOwner> GetChildren()
        {
            return children;
        }
        public bool ForceRemoveChild(StoreOwner child) { }
    }
}
