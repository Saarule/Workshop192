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

        public StoreManager(UserState user, Store store, StoreOwner father, bool[] privileges) : base(user, store, father)
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

        public override bool AddOwner(UserState user)
        {
            if (privileges[3])
                return base.AddOwner(user);
            return false;
        }

        public override bool AddManager(UserState user, bool[] privileges)
        {
            if (privileges[4])
                return base.AddManager(user, privileges);
            return false;
        }

        public override bool RemoveChild(StoreOwner child)
        {
            if (privileges[5])
                return base.RemoveChild(child);
            return false;
        }
    }
}
