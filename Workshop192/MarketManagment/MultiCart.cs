using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class MultiCart
    {
        public int multiCartId { get; set; }
        public virtual LinkedList<Cart> carts { get; set; }

        public MultiCart(int multiCartId)
        {
            this.multiCartId = multiCartId;
            carts = new LinkedList<Cart>();
        }

        public MultiCart() //Only for Entity Framework references should be 0
        { }

        public bool AddProductsToMultiCart(Store store, int productId, int amount)
        {
            if (amount < 0)
                return false;
            foreach (Cart cart in carts)
                if (cart.GetStore().Equals(store))
                    return cart.AddProductsToCart(productId, amount);
            carts.AddLast(new Cart(store, this));
            try
            {
                carts.Last.Value.AddProductsToCart(productId, amount);
                return true;
            }
            catch (ErrorMessageException e)
            {
                carts.RemoveLast();
                throw e;
            }
        }

        public bool RemoveProductFromMultiCart(int productId)
        {
            foreach (Cart cart in carts)
                foreach (Product p in cart.GetProducts().Keys)
                    if (p.GetId().Equals(productId))
                    {
                        if (!cart.RemoveProduct(productId))
                            return false;
                        if (cart.GetProducts().Count == 0)
                            carts.Remove(cart);
                        return true;
                    }
            throw new ErrorMessageException("Product Doesnt exist in multi cart");
        }

        public void ResetMultiCart()
        {
            while (carts.Count > 0 && !DbCommerce.GetInstance().forTests)
                DbCommerce.GetInstance().RemoveCart(carts.First.Value);
            //foreach (Cart cart in carts)
            //    DbCommerce.GetInstance().RemoveCart(cart);
            carts = new LinkedList<Cart>();
            DbCommerce.GetInstance().SaveDb();
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }
    }
}
