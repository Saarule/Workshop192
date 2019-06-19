using CommunicationLayer.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Product = CommunicationLayer.Models.Product.Product;
using ServiceLayer.Store_Owner_User;

namespace CommunicationLayer.Controllers
{
    public class ProductsController : ApiController
    {
        public static bool OpenStore(string storename ,string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.RegisteredUser.OpenStore.openStore(storename, userID);
        }

        public static LinkedList<LinkedList<string>> DisplayCart(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Guest.WatchAndEdit.Watch(userID);
        }

        public static bool SaveToCart(string SessionID, int productID , int amount)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Guest.SaveProductToCart.SaveProduct(productID,userID,amount);
        }

        public static LinkedList<LinkedList<string>> SearchProducts(string input)
        {
            LinkedList<LinkedList<string>> result = ServiceLayer.Guest.SearchProducts.Search(input);
            return result;
        }

        public static LinkedList<string> SearchProductsByID(int productId)
        {
            LinkedList<string> result = ServiceLayer.Guest.SearchProducts.SearchById(productId);
            return result;
        }

        public static bool ManageProducts(string SessionID, int productID, string name, string category, int price, int amount, string store, string option)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.ManageProducts.ManageProduct(userID,productID,name,category,price,amount,store,option);
        }

        public static string[] ProcessOfBuying(string cardNumber, string month, string year, string holder, string ccv, string ID, string name, string address, string city, string country, string zip, string SessionID)
        {
            // THE function return number that represent transactionID !!
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Guest.ProcessOfBuyingProducts.ProcessBuyingProducts(cardNumber,month,year,holder,ccv,ID,name,address,city,country,zip,userID);
        }

        public static LinkedList<LinkedList<string>> FilterProducts(string input , LinkedList<LinkedList<string>> toFilter,string option)
        {
            // filter by category OR name (must be identical to  - הפילטר חייב להיות זהה)
            // option need to be :  byName OR byCategory
            return ServiceLayer.Guest.FilterProducts.Filter(input , toFilter, option);
        }

        public static LinkedList<LinkedList<string>> GetProductsOfStore(string storeName)
        {
            return ServiceLayer.Store_Owner_User.AllProductInStore.GetAllProducts(storeName);
        }
        public static LinkedList<LinkedList<string>> GetAllProducts()
        {
            return ServiceLayer.Store_Owner_User.AllProductInStore.GetAll();
        }

        public static bool EditCart(string option, int productID, string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            //EDIT SUPPORT: meantime just "delete" if want to edit num of units form products need to delete and add how many he wants again.  
            return ServiceLayer.Guest.WatchAndEdit.Edit(option, productID, userID);
        } 
        public static bool AddBuyingPolicy(LinkedList<string> param ,string store ,string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.ManagePolicies.AddBuyingPolicy(param,store, userID);
        }

        public static bool RemoveBuyingPolicy(string store,int productId, string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.ManagePolicies.RemoveBuyingPolicy(store, productId,userID);
        }

        public static bool AddDiscountPolicy(LinkedList<string> param,string store , int discount, string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.ManagePolicies.AddDiscountPolicy(param,store,discount, userID);
        }

        public static bool RemoveDiscountPolicy(string store,int productId,string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.ManagePolicies.RemoveDiscountPolicy(store, productId, userID);
        }
    }
}
