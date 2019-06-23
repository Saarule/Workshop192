using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Cart
    {
        public int multiCartId { get; set; }
        public virtual MultiCart multiCart { get; set; }
        public string storeName { get; set; }
        //public virtual Store store { get; set; }
        public virtual LinkedList<ProductAmountCart> productAmount { get; set; }
        public int sum { get; set; }

        public Cart(Store store, MultiCart multiCart)
        {
            multiCartId = multiCart.multiCartId;
            this.multiCart = multiCart;
            storeName = store.name;
            //this.store = store;
            productAmount = new LinkedList<ProductAmountCart>();
            sum = 0;
        }

        public Cart() //Only for Entity Framework references should be 0
        { }

        public bool AddProductsToCart(int productId, int amount)
        {
            ProductAmountCart product = null;
            foreach (ProductAmountInventory productAmount in System.GetInstance().GetStore(storeName).GetInventory())
                if (productAmount.productId.Equals(productId))
                {
                    product = new ProductAmountCart(this, productAmount.product, amount);
                    break;
                }
            if (product == null)
                throw new ErrorMessageException("Product Id dosent exist in store");
            if ((System.GetInstance().GetStore(storeName).GetProductAmount(product.product).amount < amount) || (CheckExsit(productId) && (GetProducts()[product.product] + amount > System.GetInstance().GetStore(storeName).GetProductAmount(product.product).amount)))
                throw new ErrorMessageException("Product has less than the given amount");
            if (CheckExsit(productId))
            {
                foreach (ProductAmountCart p in productAmount)
                    if (p.product.Id.Equals(productId))
                        p.amount += amount;
            }
            else
                productAmount.AddLast(product);
            return true;
        }

        private bool CheckExsit(int productId)
        {
            foreach (ProductAmountCart products in productAmount)
                if (products.product.GetId().Equals(productId))
                    return true;
            return false;
        }

        public bool RemoveProduct(int productId)
        {
            foreach (ProductAmountCart products in productAmount)
                if (products.product.GetId().Equals(productId))
                    return productAmount.Remove(products);
            throw new ErrorMessageException("Product Doesnt exist in cart");
        }

        public void SetSum()
        {
            sum = 0;
            foreach (ProductAmountCart product in productAmount)
                sum += product.product.GetPrice() * product.amount;
        }

        public void SetSum(int sum)
        {
            this.sum = sum;
        }

        public Store GetStore()
        {
            return System.GetInstance().GetStore(storeName);
        }

        public Dictionary<Product, int> GetProducts()
        {
            Dictionary<Product, int> ret = new Dictionary<Product, int>();
            foreach (ProductAmountCart products in productAmount)
                ret[products.product] = products.amount;
            return ret;
        }

        public int GetCartSum()
        {
            return sum;
        }
    }
}