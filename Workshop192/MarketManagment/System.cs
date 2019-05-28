using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class System
    {
        private int productId;
        private int multiCartId;
        private Dictionary<int, MultiCart> multiCarts;
        private LinkedList<Store> stores;
        private MoneyCollectionSystemInterface moneyCollectionSystem;
        private DeliverySystemInterface deliverySystem;

        private static System instance = null;

        private System()
        {
            productId = 0;
            multiCartId = 0;
            multiCarts = new Dictionary<int, MultiCart>();
            stores = new LinkedList<Store>();
            moneyCollectionSystem = null;
            deliverySystem = null;
        }

        public static System GetInstance()
        {
            if (instance == null)
            {
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

        public int AddNewMultiCart()
        {
            multiCartId++;
            multiCarts.Add(multiCartId, new MultiCart());
            return multiCartId;
        }

        public MultiCart GetMultiCart(int multiCartId)
        {
            return multiCarts[multiCartId];
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

        public bool CheckProductsAvailability(LinkedList<Cart> carts)
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
