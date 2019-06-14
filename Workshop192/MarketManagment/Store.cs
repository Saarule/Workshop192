﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace Workshop192.MarketManagment
{
    public class Store
    {
        private string name;
        private Inventory inventory;
        private LinkedList<Tuple<PolicyComponent, int>> discountPolicies;
        private LinkedList<PolicyComponent> sellingPolicies;

        public Store(string name)
        {
            this.name = name;
            inventory = new Inventory();
            discountPolicies = new LinkedList<Tuple<PolicyComponent, int>>();
            sellingPolicies = new LinkedList<PolicyComponent>();
        }

        public bool AddProducts(Product product, int amount)
        {
            return inventory.AddProducts(product, amount);
        }

        public bool RemoveProducts(Product product, int amount)
        {
            return inventory.RemoveProducts(product, amount);
        }

        public bool RemoveProductFromInventory(int productId)
        {
            return inventory.RemoveProductFromInventory(productId);
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            return inventory.EditProduct(productId, name, category, price, amount);
        }

        public void AddDiscountPolicy(PolicyComponent policy, int discount)
        {
            discountPolicies.AddLast(new Tuple<PolicyComponent, int>(policy, discount));
        }

        public void AddSellingPolicy(PolicyComponent policy)
        {
            sellingPolicies.AddLast(policy);
        }

        public bool RemoveDiscountPolicy(int policyId)
        {
            if (discountPolicies.Count <= policyId)
                throw new ErrorMessageException("Discount Policy Id doesn't exists");
            return discountPolicies.Remove(discountPolicies.ElementAt(policyId));
        }

        public bool RemoveSellingPolicy(int policyId)
        {
            if (sellingPolicies.Count <= policyId)
                throw new ErrorMessageException("Selling Policy Id doesn't exists");
            return sellingPolicies.Remove(sellingPolicies.ElementAt(policyId));
        }

        public void SetDiscountMinimum(int userId, Cart cart)
        {
            foreach (Tuple<PolicyComponent, int> policy in discountPolicies)
                if (policy.Item1.Validate(userId, cart))
                {
                    int sum = 0;
                    foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                    {
                        sum += productAmount.Key.GetPrice() * productAmount.Value * (100 - policy.Item2) / 100;
                    }
                    if (sum < cart.GetCartSum())
                        cart.SetSum(sum);
                }
        }

        public bool CheckSellingPolicies(int userId, Cart cart)
        {
            foreach (PolicyComponent policy in sellingPolicies)
                if (!policy.Validate(userId, cart))
                    throw new ErrorMessageException("Selling Policy of store name [" + name + "] fails");
            return true;
        }

        public string GetName()
        {
            return name;
        }

        public Dictionary<Product, int> GetInventory()
        {
            return inventory.GetAllProduct();
        }

        public LinkedList<Tuple<PolicyComponent, int>> GetDiscountPolicies()
        {
            return discountPolicies;
        }

        public LinkedList<PolicyComponent> GetSellingPolicies()
        {
            return sellingPolicies;
        }
    }
}
