using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    class StoreManager : StoreOwner
    {
        private bool[] privileges;

        public StoreManager(User user, Store store, StoreOwner father, bool[] privileges) : base(user, store, father) { }

        public override bool AddProduct(Product product) { }

        public override bool RemoveProduct(Product product) { }

        public override bool EditProduct(Product oldProduct, Product newProduct) { }

        public override bool AddOwner(User user) { }

        public override bool AddManager(User user) { }

        public override bool RemoveChild(StoreOwner child) { }
    }
}
