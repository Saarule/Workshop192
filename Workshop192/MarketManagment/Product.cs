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
        public string discountPolicy { get; set; }
        public string sellingPolicy { get; set; }

        public Product(int Id, string name, string category, int price)
        {
            this.Id = Id;
            this.name = name;
            this.category = category;
            this.price = price;
            discountPolicy = "";
            sellingPolicy = "";
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
            if (discountPolicy.Equals(""))
                discountPolicy = PolicyToString(policy);
            else
                discountPolicy += "$" + PolicyToString(policy);
        }

        public void AddSellingPolicy(LinkedList<string> policy)
        {
            if (sellingPolicy.Equals(""))
                sellingPolicy = PolicyToString(policy);
            else
                sellingPolicy += "$" + PolicyToString(policy);
        }

        public bool RemoveDiscountPolicy()
        {
            if (discountPolicy.Equals(""))
                throw new ErrorMessageException("Cant Remove non existing discount policy");
            discountPolicy = "";
            return true;
        }

        public bool RemoveSellingPolicy()
        {
            if (sellingPolicy.Equals(""))
                throw new ErrorMessageException("Cant Remove non existing selling policy");
            sellingPolicy = "";
            return true;
        }

        public void SetDiscountMinimum(int userId, Cart cart)
        {
            if (discountPolicy.Equals(""))
                return;
            if (GetDiscountPolicy().Validate(userId, cart))
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
            if (sellingPolicy.Equals(""))
                return true;
            if (!GetSellingPolicy().Validate(userId, cart))
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
            if (this.discountPolicy.Equals(""))
                return null;
            PolicyComponent discountPolicy = null;
            string[] str = this.discountPolicy.Split('$');
            foreach (string s in str)
                discountPolicy = CreatePolicy(s, discountPolicy);
            return discountPolicy;
        }

        public PolicyComponent GetSellingPolicy()
        {
            if (this.sellingPolicy.Equals(""))
                return null;
            PolicyComponent sellingPolicy = null;
            string[] str = this.sellingPolicy.Split('$');
            foreach (string s in str)
                sellingPolicy = CreatePolicy(s, sellingPolicy);
            return sellingPolicy;
        }

        private PolicyComponent CreatePolicy(string policy, PolicyComponent prePolicy)
        {
            PolicyComponent createdPolicy = null;
            string[] str = policy.Split('#');
            switch (str[0])
            {
                case "Ban":
                    createdPolicy = new PolicyLeafBannedUser(str[3]);
                    break;
                case "Max":
                    createdPolicy = new PolicyLeafMaximumAmount(Int32.Parse(str[3]), Int32.Parse(str[4]));
                    break;
                case "Min":
                    createdPolicy = new PolicyLeafMinimumAmount(Int32.Parse(str[3]), Int32.Parse(str[4]));
                    break;
                default:
                    throw new ErrorMessageException("Syntax Error in given policy");
            }
            if (prePolicy != null)
            {
                switch (str[1])
                {
                    case "AND":
                        createdPolicy = new PolicyCompositeAnd(createdPolicy, prePolicy);
                        break;
                    case "OR":
                        createdPolicy = new PolicyCompositeOr(createdPolicy, prePolicy);
                        break;
                    case "XOR":
                        createdPolicy = new PolicyCompositeXor(createdPolicy, prePolicy);
                        break;
                    default:
                        throw new ErrorMessageException("policy composite [" + str[1] + "] isnt supported");
                }
            }
            return createdPolicy;
        }

        private string PolicyToString(LinkedList<string> policy)
        {
            string ret = "";
            foreach (string str in policy)
                ret += str + "#";
            ret = ret.Substring(0, ret.Length - 1);
            return ret;
        }
    }
}
