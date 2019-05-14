using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class StoreManager : StoreOwner
    {
        private bool[] privileges;

        public StoreManager(User user, Store store, StoreOwner father, bool[] privileges) : base(user, store, father)
        {
            this.privileges = privileges;
        }

        public override void AddProduct(Product product)
        {
            if (privileges[0])
                base.AddProduct(product);
        }

        public override bool RemoveProduct(Product product)
        {
            if (privileges[1])
                return base.RemoveProduct(product);
            return false;
        }

        public override bool EditProduct(Product oldProduct, Product newProduct)
        {
            if (privileges[2])
                return base.EditProduct(oldProduct, newProduct);
            return false;
        }

        public override void AddOwner(User user)
        {
            if (privileges[3])
                base.AddOwner(user);
        }

        public override void AddManager(User user, bool[] privileges)
        {
            if (privileges[4])
                base.AddManager(user, privileges);
        }

        public override bool RemoveChild(StoreOwner child)
        {
            if (privileges[5])
                return base.RemoveChild(child);
            return false;
        }
    }
}
