using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public int discountAmount { get; set; }
        public virtual PolicyComponent discountPolicy { get; set; }
        public virtual PolicyComponent sellingPolicy { get; set; }

        public Product(int Id, string name, string category, int price)
        {
            this.Id = Id;
            this.name = name;
            this.category = category;
            this.price = price;
            discountPolicy = null;
            sellingPolicy = null;
        }

        public Product() //Only for Entity Framework references should be 0
        { }

        public void EditProduct(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public void AddDiscountPolicy(LinkedList<string> policy, int discount)
        {
            discountAmount = discount;
            PolicyComponent tmp1 = CreatePolicy(policy);
            if (discountPolicy == null)
            {
                discountPolicy = tmp1;
                discountPolicy.policyId = -1;
                return;
            }
            PolicyComponent tmp2 = discountPolicy;
            switch (policy.ElementAt(1))
            {
                case "AND":
                    discountPolicy = new PolicyCompositeAnd(tmp1, tmp2, 0, Id + "");
                    tmp1.policyId = tmp2.policyId - 1;
                    discountPolicy.policyId = tmp1.policyId - 1;
                    break;
                case "OR":
                    discountPolicy = new PolicyCompositeOr(tmp1, tmp2, 0, Id + "");
                    tmp1.policyId = tmp2.policyId - 1;
                    discountPolicy.policyId = tmp1.policyId - 1;
                    break;
                case "XOR":
                    discountPolicy = new PolicyCompositeXor(tmp1, tmp2, 0, Id + "");
                    tmp1.policyId = tmp2.policyId - 1;
                    discountPolicy.policyId = tmp1.policyId - 1;
                    break;
                default:
                    throw new ErrorMessageException("Syntax Error in given discount policy");
            }
        }

        public void AddSellingPolicy(LinkedList<string> policy)
        {
            PolicyComponent tmp1 = CreatePolicy(policy);
            if (sellingPolicy == null)
            {
                sellingPolicy = tmp1;
                sellingPolicy.policyId = 1;
                return;
            }
            PolicyComponent tmp2 = sellingPolicy;
            switch (policy.ElementAt(1))
            {
                case "AND":
                    sellingPolicy = new PolicyCompositeAnd(tmp1, tmp2, 0, Id + "");
                    tmp1.policyId = tmp2.policyId + 1;
                    sellingPolicy.policyId = tmp1.policyId + 1;
                    break;
                case "OR":
                    sellingPolicy = new PolicyCompositeOr(tmp1, tmp2, 0, Id + "");
                    tmp1.policyId = tmp2.policyId + 1;
                    sellingPolicy.policyId = tmp1.policyId + 1;
                    break;
                case "XOR":
                    sellingPolicy = new PolicyCompositeXor(tmp1, tmp2, 0, Id + "");
                    tmp1.policyId = tmp2.policyId + 1;
                    sellingPolicy.policyId = tmp1.policyId + 1;
                    break;
                default:
                    throw new ErrorMessageException("Syntax Error in given selling policy");
            }
        }

        public bool RemoveDiscountPolicy()
        {
            if (discountPolicy == null)
                throw new ErrorMessageException("Cant Remove non existing discount policy");
            discountPolicy = null;
            return true;
        }

        public bool RemoveSellingPolicy()
        {
            if (sellingPolicy == null)
                throw new ErrorMessageException("Cant Remove non existing selling policy");
            sellingPolicy = null;
            return true;
        }

        public void SetDiscountMinimum(int userId, Cart cart)
        {
            if (discountPolicy == null)
                return;
            if (discountPolicy.Validate(userId, cart))
            {
                int sum = 0;
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                {
                    if (productAmount.Key.Equals(this))
                        sum += productAmount.Key.price * productAmount.Value * (100 - discountAmount) / 100;
                    else
                        sum += productAmount.Key.price * productAmount.Value;
                }
                if (sum < cart.GetCartSum())
                    cart.SetSum(sum);
            }
        }

        public bool CheckSellingPolicy(int userId, Cart cart)
        {
            if (sellingPolicy == null)
                return true;
            if (!sellingPolicy.Validate(userId, cart))
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

        public PolicyComponent GetDiscountPolicy()
        {
            return discountPolicy;
        }

        public PolicyComponent GetSellingPolicy()
        {
            return sellingPolicy;
        }

        private PolicyComponent CreatePolicy(LinkedList<string> policy)
        {
            PolicyComponent createdPolicy = null;
            switch (policy.ElementAt(0))
            {
                case "Ban":
                    createdPolicy = new PolicyLeafBannedUser(policy.ElementAt(3), 0, Id + "");
                    break;
                case "Max":
                    createdPolicy = new PolicyLeafMaximumAmount(Int32.Parse(policy.ElementAt(3)), Int32.Parse(policy.ElementAt(4)), 0, Id + "");
                    break;
                case "Min":
                    createdPolicy = new PolicyLeafMinimumAmount(Int32.Parse(policy.ElementAt(3)), Int32.Parse(policy.ElementAt(4)), 0, Id + "");
                    break;
                default:
                    throw new ErrorMessageException("Syntax Error in given policy");
            }
            return createdPolicy;
        }
    }
}
