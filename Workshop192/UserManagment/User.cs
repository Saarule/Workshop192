using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class User
    {
        private UserInfo info;
        private int multiCartId;

        public User()
        {
            info = null;
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
        }
            
        public bool LogIn(UserInfo info)
        {
            if (IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog(this.info.GetUserName() + " Tried to Log In a second time");
                throw new ErrorMessageException("User is already logged in");
            }
            if (info == null)
                throw new ErrorMessageException("Invalid user info");
            Logger.GetInstance().WriteToEventLog(info.GetUserName() + " Logged In");
            this.info = info;
            MarketManagment.System.GetInstance().ResetMultiCart(multiCartId);
            multiCartId = info.GetMultiCart();
            return true;
        }

        public bool LogOut()
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Not logged in");
            multiCartId = MarketManagment.System.GetInstance().AddNewMultiCart();
            Logger.GetInstance().WriteToEventLog(info.GetUserName() + " Logged Out");
            info = null;
            return true;
        }

        public bool MakeAdmin(UserInfo user)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Cant make admin while not logged in");
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried Making a non existent user admin");
                throw new ErrorMessageException("Given user dosen't exist");
            }
            return user.MakeAdmin(user);
        }

        public bool OpenStore(string storeName,int userId)
        {
            if (IsLoggedIn())
                return info.OpenStore(storeName);
            Logger.GetInstance().WriteToErrorLog("A guest tried to open a store but failed");
            throw new ErrorMessageException("Cant open store while not logged in");
        }

        public bool AddProducts(string store, Product product, int amount)
        {
            if (IsLoggedIn())
                return info.AddProducts(store, product, amount);
            Logger.GetInstance().WriteToErrorLog("A guest tried to add a product but failed");
            throw new ErrorMessageException("Can't add products to store while not logged in");
        }

        public bool RemoveProductFromInventory(string store, int productId)
        {
            if (IsLoggedIn())
                return info.RemoveProductFromInventory(store, productId);
            Logger.GetInstance().WriteToErrorLog("A guest tried to remove a product from store but failed");
            throw new ErrorMessageException("Cant remove products from store while not logged in");
        }

        public bool EditProduct(string store, int productId, string name, string category, int price, int amount)
        {
            if (IsLoggedIn())
                return info.EditProduct(store, productId, name, category, price, amount);
            Logger.GetInstance().WriteToErrorLog("A guest tried to edit a product of store but failed");
            throw new ErrorMessageException("Cant edit products while not logged in");
        }

        public bool AddStoreOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog("A guest tried to add a store owner but failed");
                throw new ErrorMessageException("Cant add store owner while not logged in");
            }
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried Making a non existent user store owner");
                throw new ErrorMessageException("Given user dosent exist");
            }
            return info.AddStoreOwner(store, user);
        }

        public bool AcceptOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog("A guest tried to accept a store owner but failed");
                throw new ErrorMessageException("Cant accept store owner while not logged in");
            }
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried accepting a non existent user as a store owner");
                throw new ErrorMessageException("Given user dosent exist");
            }
            return info.AcceptOwner(store, user);
        }

        public bool DeclineOwner(string store, UserInfo user)
        {
            if (!IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog("A guest tried to decline a store owner but failed");
                throw new ErrorMessageException("Cant decline store owner while not logged in");
            }
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried declining a non existent user as a store owner");
                throw new ErrorMessageException("Given user dosent exist");
            }
            return info.DeclineOwner(store, user);
        }

        public bool AddDiscountPolicy(string store, LinkedList<string> policy, int discount)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Cant add discount policy while not logged in");
            return info.AddDiscountPolicy(store, policy, discount);
        }

        public bool AddSellingPolicy(string store, LinkedList<string> policy)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Cant add selling policy while not logged in");
            return info.AddSellingPolicy(store, policy);
        }

        public bool RemoveDiscountPolicy(string store, int productId)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Cant remove discount policy while not logged in");
            return info.RemoveDiscountPolicy(store, productId);
        }

        public bool RemoveSellingPolicy(string store, int productId)
        {
            if (!IsLoggedIn())
                throw new ErrorMessageException("Cant remove selling policy while not logged in");
            return info.RemoveSellingPolicy(store, productId);
        }

        public bool AddStoreManager(string store, UserInfo user, bool[] privileges)
        {
            if (!IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog("A guest tried to add a store manager but failed");
                throw new ErrorMessageException("Cant add store manager while not logged in");
            }
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried adding a non existent user as a store manager");
                throw new ErrorMessageException("Given user dosent exist");
            }
            return info.AddStoreManager(store, user, privileges);
        }

        public bool RemoveStoreManager(string store, UserInfo user)
        {
            if (!IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog("A guest tried to remove a store manager but failed");
                throw new ErrorMessageException("Cant remove store manager while not logged in");
            }
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried removing a non existent user as a store manager");
                throw new ErrorMessageException("Given user dosent exist");
            }
            return info.RemoveStoreManager(store, user);
        }

        public bool AddProductsToMultiCart(string store, int productId, int amount)
        {
            if (MarketManagment.System.GetInstance().GetMultiCart(multiCartId).AddProductsToMultiCart(MarketManagment.System.GetInstance().GetStore(store), productId, amount))
            {
                if (IsLoggedIn())
                    Logger.GetInstance().WriteToEventLog(info.GetUserName() + " added product [" + productId + "] [" + amount + "] of store [" + store + "] to their multi cart");
                else
                    Logger.GetInstance().WriteToEventLog("A guest added product [" + productId + "] [" + amount + "] of store [" + store + "] to their multi cart");
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            return false;
        }

        public bool RemoveProductFromCart(int productId)
        {
            if (MarketManagment.System.GetInstance().GetMultiCart(multiCartId).RemoveProductFromMultiCart(productId))
            {
                if (IsLoggedIn())
                    if (IsLoggedIn())
                        Logger.GetInstance().WriteToEventLog(info.GetUserName() + " removed product [" + productId + "] from their multi cart");
                    else
                        Logger.GetInstance().WriteToEventLog("A guest removed product [" + productId + "] from their multi cart");
                DbCommerce.GetInstance().SaveDb();
                return true;
            }
            return false;
        }

        public bool RemoveUser(UserInfo user)
        {
            if (!IsLoggedIn())
            {
                Logger.GetInstance().WriteToErrorLog("A guest tried to add a remove a user but failed");
                throw new ErrorMessageException("Cant remove registered user while not logged in");
            }
            if (user == null)
            {
                Logger.GetInstance().WriteToErrorLog(info.GetUserName() + " Tried removing a non existent user from the system");
                throw new ErrorMessageException("Given user dosent exist");
            }
            return info.RemoveUser(user);
        }
        
        public string GetUserName()
        {
            if (!IsLoggedIn())
                return "";
            return info.GetUserName();
        }

        public int GetMultiCart()
        {
            return multiCartId;
        }

        public bool IsAdmin()
        {
            if (!IsLoggedIn())
                return false;
            return info.IsAdmin();
        }

        public bool IsLoggedIn()
        {
            if (info == null)
                return false;
            return true;
        }

        public UserInfo GetInfo()
        {
            return info;
        }
    }
}