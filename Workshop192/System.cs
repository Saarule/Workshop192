using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace Workshop192
{
    public class System
    {
        private LinkedList<UserState> users;
        private LinkedList<Store> stores;
        private Security security;
        private MoneyCollectionSystemInterface moneyCollectionSystem;
        private DeliverySystemInterface deliverySystem;

        private static System instance = null;

        private System()
        {
            users = new LinkedList<UserState>();
            stores = new LinkedList<Store>();
            security = new Security();
        }

        public static System GetInstance() {
            if (instance == null) {
                instance = new System();
            }
            return instance;
        }

        public static System Reset()
        {
            instance = new System();
            return instance;
        }

        public void ConnectMoneyCollectionSystem(MoneyCollectionSystemReal real)
        {
            moneyCollectionSystem = new MoneyCollectionSystemProxy(real);
        }

        public void ConnectDeliverySystem(DeliverySystemReal real)
        {
            deliverySystem = new DeliverySystemProxy(real);
        }

        public bool PurchaseProducts(int accountId, User user, string name, string address)
        {
            int sum = SumOfCartPrice(user.GetCarts());
            if (!moneyCollectionSystem.CollectFromAccount(accountId, sum))
                return false;
            if (!deliverySystem.Deliver(name, address, user.GetCarts()))
                return false;
            user.ResetCarts();
            return true;
        }

        public bool CheckProductsavailability(LinkedList<Cart> carts)
        {
            LinkedList<Cart> tmp = new LinkedList<Cart>();
            foreach (Cart cart in carts)
            {
                tmp.AddLast(new Cart(cart.GetStore()));
                foreach (Product product in cart.GetProducts())
                {
                    if (cart.GetStore().GetProducts().Contains(product))
                    {
                        tmp.Last.Value.AddProduct(product);
                        cart.GetStore().GetProducts().Remove(product);
                    }
                    else
                    {
                        ReturnProductsToStore(tmp);
                        return false;
                    }
                }
            }
            return true;
        }

        private void ReturnProductsToStore(LinkedList<Cart> carts)
        {
            foreach (Cart cart in carts)
                foreach (Product product in cart.GetProducts())
                    cart.GetStore().GetProducts().AddLast(product);
        }

        public int SumOfCartPrice(LinkedList<Cart> carts)
        {
            int sum = 0;
            foreach (Cart cart in carts)
                foreach (Product product in cart.GetProducts())
                    sum += product.GetPrice();
            return sum;
        }

        public bool Register(string userName, string password)
        {
            if (!security.AddUser(userName, password))
                return false;
            UserState user = new UserState(userName);
            users.AddLast(user);
            return true;
        }

        public UserState GetUser(string userName, string password)
        {
            if (!security.ValidatePassword(userName, password))
                return null;
            foreach (UserState user in users)
                if (user.GetUserName() == userName)
                {
                    return user;
                }
            return null;
        }

        public bool AddStoreOwner(User user, Store store, string userName)
        {
            return user.AddStoreOwner(store, GetUser(userName));
        }

        public bool AddStoreManager(User user, Store store, string userName, bool[] privileges)
        {
            if (privileges.Length != 6)
                return false;
            return user.AddStoreManager(store, GetUser(userName), privileges);
        }

        private UserState GetUser(string userName)
        {
            foreach (UserState user in users)
                if (user.GetUserName() == userName)
                    return user;
            return null;
        }

        public bool OpenStore(string storeName, UserState user)
        {
            if (user == null)
                return false;
            foreach (Store s in stores)
                if (s.GetName().Equals(storeName))
                    return false;
            Store store = new Store(storeName);
            user.GetStoreOwners().AddLast(new StoreOwner(user, store, null));
            stores.AddLast(store);
            return true;
        }

        public Store GetStore(string storeName)
        {
            foreach (Store store in stores)
                if (store.GetName() == storeName)
                    return store;
            return null;
        }

        public LinkedList<Store> GetAllStores()
        {
            return stores;
        }

        public bool RemoveUser(UserState user)
        {
            if (user == null)
                return false;
            if (!security.RemoveUser(user.GetUserName()))
                return false;
            while (user.GetStoreOwners().Count > 0)
            {
                StoreOwner tmp = user.GetStoreOwners().First.Value;
                if (!tmp.ForceRemoveChild(tmp))
                    return false;
                if (tmp.GetFather() == null && !RemoveStore(tmp.GetStore()))
                    return false;
            }
            return true;
        }

        public bool CloseStore(Store store, UserState user)
        {
            StoreOwner owner = user.GetOwner(store);
            if (owner == null || owner.GetFather() != null)
                return false;
            return owner.ForceRemoveChild(owner) && RemoveStore(store);
        }

        private bool RemoveStore(Store store)
        {
            foreach (UserState user in users)
                foreach (Cart cart in user.GetCarts())
                    if (cart.GetStore() == store)
                    {
                        user.GetCarts().Remove(cart);
                        break;
                    }
            return stores.Remove(store);
        }
    }
}
