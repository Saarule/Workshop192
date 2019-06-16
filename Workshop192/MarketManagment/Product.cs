using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Product
    {
        private int Id;
        private string name;
        private string category;
        private int price;
        private LinkedList<Tuple<PolicyComponent, int>> discountPolicies;
        private LinkedList<PolicyComponent> sellingPolicies;

        public Product(int Id, string name, string category, int price)
        {
            this.Id = Id;
            this.name = name;
            this.category = category;
            this.price = price;
            discountPolicies = new LinkedList<Tuple<PolicyComponent, int>>();
            sellingPolicies = new LinkedList<PolicyComponent>();
        }

        public void EditProduct(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
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
                        if (productAmount.Key.Equals(this))
                            sum += productAmount.Key.price * productAmount.Value * (100 - policy.Item2) / 100;
                        else
                            sum += productAmount.Key.price * productAmount.Value;
                    }
                    if (sum < cart.GetCartSum())
                        cart.SetSum(sum);
                }
        }

        public bool CheckSellingPolicies(int userId, Cart cart)
        {
            foreach (PolicyComponent policy in sellingPolicies)
                if (!policy.Validate(userId, cart))
                    throw new ErrorMessageException("Selling Policy of product Id [" + Id + "] fails");
            return true;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetCategory()
        {
            return category;
        }

        public string GetName()
        {
            return name;
        }

        public int GetPrice()
        {
            return price;
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
