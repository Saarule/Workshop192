using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class StoreManager
    {
        private bool[] privileges;
        private UserInfo user;
        private string store;
        private StoreOwner owner;

        public StoreManager(UserInfo user, string store, bool[] privileges, StoreOwner owner)
        {
            this.privileges = privileges;
            this.user = user;
            this.store = store;
            this.owner = owner;
        }

        public bool AddProducts(Product product, int amount)
        {
            if (privileges[0])
            {
                MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount);
                return true;
            }
            return false;
        }

        public bool RemoveProductFromInventory(int productId)
        {
            if (privileges[1])
            {
                MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(productId);
                return true;
            }
            return false;
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            if (privileges[2])
            {
                return MarketManagment.System.GetInstance().GetStore(store).EditProduct(productId, name, category, price, amount);
            }
            return false;
        }

        public void RemoveSelf()
        {
            user.GetStoreManagers().Remove(this);
            owner.GetAppointedManagers().Remove(this);
        }

        public UserInfo GetUser()
        {
            return user;
        }

        public string GetStore()
        {
            return store;
        }

        public bool[] GetPrivileges()
        {
            return privileges;
        }

        public StoreOwner GetOwner()
        {
            return owner;
        }
    }
}
