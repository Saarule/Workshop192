using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace ServiceLayer.Store_Owner_User
{
    public class GetPolicies
    {
        public static LinkedList<string> GetPoliciesOfStore(string storeName)
        {
            LinkedList<string> str = new LinkedList<string>();
            Store store = Workshop192.MarketManagment.System.GetInstance().GetStore(storeName);
            if (store.GetSellingPolicy() != null)
                str.AddLast("Store Name: "+ storeName+ " ; Selling Policy: " +store.GetSellingPolicy().ToString());
            if (store.GetDiscountPolicy() != null)
                str.AddLast("Store Name: " + storeName + " ; Discount Policy: " +store.GetDiscountPolicy().Item1.ToString() + ", " + store.GetDiscountPolicy().Item2);
            foreach (KeyValuePair<Product, int> productAmount in store.GetInventory())
            {
                if (productAmount.Key.GetSellingPolicy() != null)
                    str.AddLast("Product Id: " + productAmount.Key.GetId() + " ; Selling Policy: " + productAmount.Key.GetSellingPolicy().ToString());
                if (productAmount.Key.GetDiscountPolicy() != null)
                    str.AddLast("Product Id: " + productAmount.Key.GetId() + " ; Discount Policy: " + productAmount.Key.GetDiscountPolicy().Item1.ToString() + ", " + productAmount.Key.GetDiscountPolicy().Item2);
            }
            return str;
        }
    }
}
