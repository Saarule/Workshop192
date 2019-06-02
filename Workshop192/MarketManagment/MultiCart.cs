using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class MultiCart
    {
        private LinkedList<Cart> carts;

        public MultiCart()
        {
            carts = new LinkedList<Cart>();
        }

        public bool AddProductsToMultiCart(Store store, Product product, int amount)
        {
            foreach (Cart cart in carts)
                if (cart.GetStore().Equals(store))
                    return cart.AddProductsToCart(product, amount);
            carts.AddLast(new Cart(store));
            return carts.Last.Value.AddProductsToCart(product, amount);
        }

        public bool RemoveProductFromMultiCart(Product product)
        {
            foreach (Cart cart in carts)
                foreach (Product p in cart.GetProducts().Keys)
                    if (p.Equals(product))
                    {
                        if (!cart.RemoveProduct(product))
                            return false;
                        if (cart.GetProducts().Count == 0)
                            carts.Remove(cart);
                        return true;
                    }
            return false;
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }
    }
}
