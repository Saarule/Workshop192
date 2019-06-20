using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Store_Owner_User
{
    public class ManagePolicies
    {
        public static bool AddBuyingPolicy(LinkedList<string> param, string store, int userId)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).AddSellingPolicy(store, param);
        }
        public static bool RemoveBuyingPolicy(string store, int productId, int userId)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).RemoveSellingPolicy(store, productId);
        }
        public static bool AddDiscountPolicy(LinkedList<string> param, string store, int discount, int userId)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).AddDiscountPolicy(store, param, discount);
        }
        public static bool RemoveDiscountPolicy(string store, int productID, int userId)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).RemoveDiscountPolicy(store, productID);
        }
    }
}
