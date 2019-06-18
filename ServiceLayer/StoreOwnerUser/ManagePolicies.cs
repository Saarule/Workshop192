using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Store_Owner_User
{
    public class ManagePolicies
    {
        public static bool AddBuyingPolicy(LinkedList<string> param, int userId)
        {
            return true;
        }
        public static bool RemoveBuyingPolicy(LinkedList<string> param , int userId)
        {
            return true;
        }
        public static bool AddDiscountPolicy(LinkedList<string> param, int userId)
        {
            return true;
        }
        public static bool RemoveDiscountPolicy(LinkedList<string> param, int userId)
        {
            return true;
        }
    }
}
