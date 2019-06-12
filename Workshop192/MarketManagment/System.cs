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

        public Product CreateProduct(string name, string category, int price)
        {
            productId++;
            return new Product(productId, name, category, price);
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

        private void ResetMultiCart(int multiCartId)
        {
            multiCarts[multiCartId] = new MultiCart();
        }

        public bool PurchaseProducts(int accountId, int userId, string name, string address)
        {
            if (!CheckSellingPolicies(userId))
                return false;
            int sum = SumOfCartPrice(userId);
            if (!moneyCollectionSystem.CollectFromAccount(accountId, sum))
                return false;
            if (!deliverySystem.Deliver(name, address, GetMultiCart(UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart())))
                return false;
            ResetMultiCart(UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart());
            return true;
        }

        public bool CheckProductsAvailability(MultiCart multiCart)
        {
            foreach (Cart cart in multiCart.GetCarts())
            {
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                {
                    if (!cart.GetStore().GetInventory().ContainsKey(productAmount.Key))
                        return false;
                    if (cart.GetStore().GetInventory()[productAmount.Key] < productAmount.Value)
                        return false;
                    if (GetStore(cart.GetStore().GetName()) == null)
                        return false;
                }
            }
            return true;
        }

        public void RemoveProductsFromStore(MultiCart multiCart)
        {
            foreach (Cart cart in multiCart.GetCarts())
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                    cart.GetStore().RemoveProducts(productAmount.Key, productAmount.Value);
        }

        public void ReturnProductsToStore(MultiCart multiCart)
        {
            foreach (Cart cart in multiCart.GetCarts())
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                    cart.GetStore().GetInventory()[productAmount.Key] += productAmount.Value;
        }

        public bool CheckSellingPolicies(int userId)
        {
            MultiCart multiCart = GetMultiCart(UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart());
            foreach (Cart cart in multiCart.GetCarts())
            {
                if (!cart.GetStore().CheckSellingPolicies(userId, cart))
                    return false;
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                    if (!productAmount.Key.CheckSellingPolicies(userId, cart))
                        return false;
            }
            return true;
        }

        public int SumOfCartPrice(int userId)
        {
            MultiCart multiCart = GetMultiCart(UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart());
            foreach (Cart cart in multiCart.GetCarts())
            {
                cart.SetSum();
                cart.GetStore().SetDiscountMinimum(userId, cart);
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                    productAmount.Key.SetDiscountMinimum(userId, cart);
            }
            int sum = 0;
            foreach (Cart cart in multiCart.GetCarts())
                sum += cart.GetCartSum();
            return sum;
        }

        public void OpenStore(string storeName)
        {
            stores.AddLast(new Store(storeName));
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
    }
}
