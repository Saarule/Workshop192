﻿using System;
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
                str.AddLast("Store Name: " + storeName + " ; Discount Policy: " +store.GetDiscountPolicy().ToString() + ", " + store.discountAmount);
            foreach (ProductAmountInventory productAmount in store.GetInventory())
            {
                if (productAmount.product.GetSellingPolicy() != null)
                    str.AddLast("Product Id: " + productAmount.product.GetId() + " ; Selling Policy: " + productAmount.product.GetSellingPolicy().ToString());
                if (productAmount.product.GetDiscountPolicy() != null)
                    str.AddLast("Product Id: " + productAmount.product.GetId() + " ; Discount Policy: " + productAmount.product.GetDiscountPolicy().ToString() + ", " + productAmount.product.discountAmount);
            }
            return str;
        }
    }
}
