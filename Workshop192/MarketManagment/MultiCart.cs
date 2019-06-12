﻿using System;
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

        public bool AddProductsToMultiCart(Store store, int productId, int amount)
        {
            if (amount < 0)
                return false;
            foreach (Cart cart in carts)
                if (cart.GetStore().Equals(store))
                    return cart.AddProductsToCart(productId, amount);
            carts.AddLast(new Cart(store));
            if (carts.Last.Value.AddProductsToCart(productId, amount))
                return true;
            else
            {
                carts.RemoveLast();
                return false;
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
            return false;
        }

        public LinkedList<Cart> GetCarts()
        {
            return carts;
        }
    }
}
