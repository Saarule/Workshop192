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
        private Tuple<PolicyComponent, int> discountPolicy;
        private PolicyComponent sellingPolicy;

        public Product(int Id, string name, string category, int price)
        {
            this.Id = Id;
            this.name = name;
            this.category = category;
            this.price = price;
            discountPolicy = null;
            sellingPolicy = null;
        }

        public void EditProduct(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public void AddDiscountPolicy(LinkedList<string> policy, int discount)
        {
            PolicyComponent tmp1 = CreatePolicy(policy);
            if (discountPolicy == null)
            {
                discountPolicy = new Tuple<PolicyComponent, int>(tmp1, discount);
                return;
            }
            PolicyComponent tmp2 = discountPolicy.Item1;
            switch (policy.ElementAt(1))
            {
                case "AND":
                    discountPolicy = new Tuple<PolicyComponent, int>(new PolicyCompositeAnd(tmp1, tmp2), discount);
                    break;
                case "OR":
                    discountPolicy = new Tuple<PolicyComponent, int>(new PolicyCompositeOr(tmp1, tmp2), discount);
                    break;
                case "XOR":
                    discountPolicy = new Tuple<PolicyComponent, int>(new PolicyCompositeXor(tmp1, tmp2), discount);
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
                return;
            }
            PolicyComponent tmp2 = sellingPolicy;
            switch (policy.ElementAt(1))
            {
                case "AND":
                    sellingPolicy = new PolicyCompositeAnd(tmp1, tmp2);
                    break;
                case "OR":
                    sellingPolicy = new PolicyCompositeOr(tmp1, tmp2);
                    break;
                case "XOR":
                    sellingPolicy = new PolicyCompositeXor(tmp1, tmp2);
                    break;
                default:
                    throw new ErrorMessageException("Syntax Error in given selling policy");
            }
        }

        public bool RemoveDiscountPolicy()
        {
            if (discountPolicy == null)
                throw new ErrorMessageException("Can't Remove non existing discount policy");
            discountPolicy = null;
            return true;
        }

        public bool RemoveSellingPolicy()
        {
            if (sellingPolicy == null)
                throw new ErrorMessageException("Can't Remove non existing selling policy");
            sellingPolicy = null;
            return true;
        }

        public void SetDiscountMinimum(int userId, Cart cart)
        {
            if (discountPolicy == null)
                return;
            if (discountPolicy.Item1.Validate(userId, cart))
            {
                int sum = 0;
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                {
                    if (productAmount.Key.Equals(this))
                        sum += productAmount.Key.price * productAmount.Value * (100 - discountPolicy.Item2) / 100;
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

        public Tuple<PolicyComponent, int> GetDiscountPolicy()
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
                    createdPolicy = new PolicyLeafBannedUser(policy.ElementAt(3));
                    break;
                case "Max":
                    createdPolicy = new PolicyLeafMaximumAmount(Int32.Parse(policy.ElementAt(3)), Int32.Parse(policy.ElementAt(4)));
                    break;
                case "Min":
                    createdPolicy = new PolicyLeafMinimumAmount(Int32.Parse(policy.ElementAt(3)), Int32.Parse(policy.ElementAt(4)));
                    break;
                default:
                    throw new ErrorMessageException("Syntax Error in given policy");
            }
            return createdPolicy;
        }
    }
}
