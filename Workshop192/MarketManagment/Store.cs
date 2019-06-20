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
        public virtual Tuple<PolicyComponent, int> discountPolicy { get; set; }
        public virtual PolicyComponent sellingPolicy { get; set; }

        public Store(string name)
        {
            this.name = name;
            inventory = new LinkedList<ProductAmountInventory>();
            discountPolicy = null;
            sellingPolicy = null;
        }

        public bool AddProducts(Product product, int amount)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(product.GetId()))
                    throw new ErrorMessageException("Can't Add new existing product");
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
            throw new ErrorMessageException("Can't remove non existing product");
        }

        public bool RemoveProductFromInventory(int productId)
        {
            foreach (ProductAmountInventory productAmount in inventory)
                if (productAmount.productId.Equals(productId))
                    return inventory.Remove(productAmount);
            throw new ErrorMessageException("Can't Remove non existing product from inventory");
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
            throw new ErrorMessageException("Can't edit non existing product");
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
                case "And":
                    discountPolicy = new Tuple<PolicyComponent, int>(new PolicyCompositeAnd(tmp1, tmp2), discount);
                    break;
                case "Or":
                    discountPolicy = new Tuple<PolicyComponent, int>(new PolicyCompositeOr(tmp1, tmp2), discount);
                    break;
                case "Xor":
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
                case "And":
                    sellingPolicy = new PolicyCompositeAnd(tmp1, tmp2);
                    break;
                case "Or":
                    sellingPolicy = new PolicyCompositeOr(tmp1, tmp2);
                    break;
                case "Xor":
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
            if (discountPolicy != null && discountPolicy.Item1.Validate(userId, cart))
            {
                int sum = 0;
                foreach (KeyValuePair<Product, int> productAmount in cart.GetProducts())
                {
                    sum += productAmount.Key.GetPrice() * productAmount.Value * (100 - discountPolicy.Item2) / 100;
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
