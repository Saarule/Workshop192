using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class Cart
    {
        private Store store;
        private Dictionary<Product, int> products;
        int sum;

        public Cart(Store store)
        {
            this.store = store;
            products = new Dictionary<Product, int>();
            sum = 0;
        }

        public bool AddProductsToCart(int productId, int amount)
        {
            Product product = null;
            foreach (ProductAmountInventory productAmount in store.GetInventory())
                if (productAmount.productId.Equals(productId))
                {
                    product = productAmount.product;
                    break;
                }
            if (product == null)
                throw new ErrorMessageException("Product Id dosen't exist in store");
            if ((store.GetProductAmount(product).amount < amount) || ( CheckExsit(productId) && (products[product] + amount > store.GetProductAmount(product).amount)))
                throw new ErrorMessageException("Product has less than the given amount");
            if (CheckExsit(productId))
                products[product] += amount;
            else
            {
                products.Add(product, amount);
            }
            return true;
        }

        private bool CheckExsit(int productId)
        {
            foreach (KeyValuePair<Product, int> productAmount in products)
                if (productAmount.Key.GetId().Equals(productId))
                    return true;
            return false;
        }

        public bool RemoveProduct(int productId)
        {
            foreach (KeyValuePair<Product, int> productAmount in products)
                if (productAmount.Key.GetId().Equals(productId))
                    return products.Remove(productAmount.Key);
            throw new ErrorMessageException("Product Doesn't exist in cart");
        }

        public void SetSum()
        {
            sum = 0;
            foreach (KeyValuePair<Product, int> product in products)
                sum += product.Key.GetPrice() * product.Value;
        }

        public void SetSum(int sum)
        {
            this.sum = sum;
        }

        public Store GetStore()
        {
            return store;
        }

        public Dictionary<Product, int> GetProducts()
        {
            return products;
        }

        public int GetCartSum()
        {
            return sum;
        }
    }
}