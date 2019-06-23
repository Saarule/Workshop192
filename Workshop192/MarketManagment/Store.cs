using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace Workshop192.MarketManagment
{
    public class Store
    {
        public string name { get; set; }
        public virtual LinkedList<ProductAmountInventory> inventory { get; set; }
        public int discountAmount { get; set; }
        public string discountPolicy { get; set; }
        public string sellingPolicy { get; set; }

        public Store(string name)
        {
            this.name = name;
            inventory = new LinkedList<ProductAmountInventory>();
            discountAmount = 0;
            discountPolicy = "";
            sellingPolicy = "";
        }

        public Store() //Only for Entity Framework references should be 0
        { }

        public bool AddProducts(Product product, int amount)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(product.GetId()))
                    throw new ErrorMessageException("Cant Add new existing product");
            inventory.AddLast(new ProductAmountInventory(this, product, amount));
            return true;
        }

        public ProductAmountInventory GetProductAmount(Product product)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(product.GetId()))
                    return productAmount;
            return null;
        }

        public bool RemoveProducts(Product product, int amount)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(product.GetId()))
                {
                    if (productAmount.amount < amount)
                        throw new ErrorMessageException("Amount Error");
                    productAmount.amount -= amount;
                    return true;
                }
            throw new ErrorMessageException("Cant remove non existing product");
        }

        public bool RemoveProductFromInventory(int productId)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(productId))
                    return inventory.Remove(productAmount);
            throw new ErrorMessageException("Cant Remove non existing product from inventory");
        }

        public bool EditProduct(int productId, string name, string category, int price, int amount)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(productId))
                {
                    productAmount.product.EditProduct(name, category, price);
                    productAmount.amount = amount;
                    return true;
                }
            throw new ErrorMessageException("Cant edit non existing product");
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
            if (discountPolicy != null && GetDiscountPolicy().Validate(userId, cart))
            {
                int sum = 0;
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                {
                    sum += productAmount.Key.GetPrice() * productAmount.Value * (100 - discountAmount) / 100;
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
                throw new ErrorMessageException("Selling Policy of store name [" + name + "] fails");
            return true;
        }

        public string GetName()
        {
            return name;
        }

        public LinkedList<ProductAmountInventory> GetInventory()
        {
            return inventory;
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
