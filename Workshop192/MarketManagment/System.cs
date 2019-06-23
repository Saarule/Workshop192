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
        private LinkedList<MultiCart> multiCarts;
        private LinkedList<Store> stores;
        private MoneyCollectionSystemInterface moneyCollectionSystem;
        private DeliverySystemInterface deliverySystem;

        private static System instance = null;

        private System()
        {
            productId = DbCommerce.GetInstance().GetProductId();
            multiCartId = DbCommerce.GetInstance().GetMultiCartId();
            multiCarts = DbCommerce.GetInstance().GetMultiCarts();
            stores = DbCommerce.GetInstance().GetStores();
            moneyCollectionSystem = new MoneyCollectionSystemProxy(null);
            deliverySystem = new DeliverySystemProxy(null);
            //foreach (UserManagment.UserInfo info in DbCommerce.GetInstance().GetUserInfos())
            //    if (info.GetMultiCart() > multiCartId)
            //        multiCartId = info.GetMultiCart();
            //foreach (Store store in DbCommerce.GetInstance().GetStores())
            //    foreach (ProductAmountInventory productAmount in store.GetInventory())
            //        if (productAmount.productId > productId)
            //            productId = productAmount.productId;
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
            multiCarts.AddLast(new MultiCart(multiCartId));
            return multiCartId;
        }

        public void AddNewMultiCartToDb(int multiCartId)
        {
            foreach (MultiCart multiCart in multiCarts)
                if (multiCart.multiCartId == multiCartId)
                {
                    DbCommerce.GetInstance().AddMultiCart(multiCart);
                    return;
                }
        }

        public MultiCart GetMultiCart(int multiCartId)
        {
            foreach (MultiCart multiCart in multiCarts)
                if (multiCart.multiCartId == multiCartId)
                    return multiCart;
            return null;
        }

        public void ResetMultiCart(int multiCartId)
        {
            foreach (MultiCart multiCart in multiCarts)
                if (multiCart.multiCartId == multiCartId)
                {
                    multiCart.ResetMultiCart();
                    return;
                }
        }

        public Tuple<int, int> PurchaseProducts(int userId, string cardNumber, string month, string year, string holder, string ccv, string id, string name, string address, string city, string country, string zip)
        {
            int collection, delivery;
            int multiCartId = UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart();
            RemoveProductsFromStore(GetMultiCart(multiCartId));
            try
            {
                if (!CheckSellingPolicies(userId))
                    throw new ErrorMessageException("Not All selling policies pass");
            }
            catch (ErrorMessageException e)
            {
                ReturnProductsToStore(GetMultiCart(multiCartId));
                throw e;
            }
            int sum = SumOfCartPrice(userId);
            collection = moneyCollectionSystem.CollectFromAccount(cardNumber, month, year, holder, ccv, id);
            delivery = deliverySystem.Deliver(name, address, city, country, zip);
            if (collection == -1 || delivery==-1)
            {
                ReturnProductsToStore(GetMultiCart(multiCartId));
                return new Tuple<int, int>(-1, -1);
            }
            try
            {
                MultiCart multicart = System.GetInstance().GetMultiCart(multiCartId);
                for (int i = 0; i < multicart.GetCarts().Count; i++)
                {
                    string message = "the products in store" + multicart.GetCarts().ElementAt(i).GetStore().GetName() + ":\n";
                    for (int j = 0; j < multicart.GetCarts().ElementAt(i).GetProducts().Count; j++)
                    {
                        message = message + " id:" + multicart.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetId() + ",name:" + multicart.GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetName() + "\n";
                    }
                    message += "were sold\n";
                    for (int k = 0; k < UserManagment.AllRegisteredUsers.GetInstance().GetAllUserNames().Count; k++)
                    {
                        if (UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(UserManagment.AllRegisteredUsers.GetInstance().GetAllUserNames().ElementAt(k)).GetOwner(multicart.GetCarts().ElementAt(i).GetStore().GetName()) != null)
                            Notifications.Notification.GetInstance().SendMessageToUser(UserManagment.AllRegisteredUsers.GetInstance().GetAllUserNames().ElementAt(k), message);
                        if (UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(UserManagment.AllRegisteredUsers.GetInstance().GetAllUserNames().ElementAt(k)).GetManager(multicart.GetCarts().ElementAt(i).GetStore().GetName()) != null)
                            Notifications.Notification.GetInstance().SendMessageToUser(UserManagment.AllRegisteredUsers.GetInstance().GetAllUserNames().ElementAt(k), message);

                    }
                }
            }
            catch (Exception) { }

            ResetMultiCart(UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart());

            return new Tuple<int, int>(collection, delivery);
        }
        
        public bool CheckProductsAvailability(MultiCart multiCart)
        {
            foreach (Cart cart in multiCart.GetCarts())
            {
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                {
                    if (cart.GetStore().GetProductAmount(productAmount.Key) == null)
                        throw new ErrorMessageException("Product Id [" + productAmount.Key.GetId() + "] doesnt exist anymore");
                    if (cart.GetStore().GetProductAmount(productAmount.Key).amount < productAmount.Value)
                        throw new ErrorMessageException("Product Id [" + productAmount.Key.GetId() + "] doesnt have the given amount in store");
                    if (GetStore(cart.GetStore().GetName()) == null)
                        throw new ErrorMessageException("Store [" + cart.GetStore().GetName() + "] no longer exists");
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
                    cart.GetStore().GetProductAmount(productAmount.Key).amount += productAmount.Value;
        }

        public bool CheckSellingPolicies(int userId)
        {
            MultiCart multiCart = GetMultiCart(UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetMultiCart());
            foreach (Cart cart in multiCart.GetCarts())
            {
                if (!cart.GetStore().CheckSellingPolicy(userId, cart))
                    return false;
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                    if (!productAmount.Key.CheckSellingPolicy(userId, cart))
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
            Store store = new Store(storeName);
            stores.AddLast(store);
            DbCommerce.GetInstance().AddStore(store);
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

        public int CancelPay(string transactionID)
        {
            return moneyCollectionSystem.CancelPay(transactionID);
        }
        public int CancelDelivery(string transactionID)
        {
            return deliverySystem.CancelDelivery(transactionID);
        }
    }
}
