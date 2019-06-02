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

        public StoreManager(UserInfo user, string store, bool[] privileges)
        {
            this.privileges = privileges;
            this.user = user;
            this.store = store;
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

        public bool RemoveProductFromInventory(Product product)
        {
            if (privileges[1])
            {
                MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(product);
                return true;
            }
            return false;
        }

        public bool EditProduct(Product product, string name, string category, int price)
        {
            if (privileges[2])
            {
                return MarketManagment.System.GetInstance().GetStore(store).EditProduct(product, name, category, price);
            }
            return false;
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
    }
}
