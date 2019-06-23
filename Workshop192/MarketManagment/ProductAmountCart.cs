using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class ProductAmountCart
    {
        public int multiCartId { get; set; }
        public string storeName { get; set; }
        public virtual Cart cart { get; set; }
        public int productId { get; set; }
        public virtual Product product { get; set; }
        public int amount { get; set; }

        public ProductAmountCart(Cart cart, Product product, int amount)
        {
            multiCartId = cart.multiCartId;
            storeName = cart.storeName;
            this.cart = cart;
            productId = product.Id;
            this.product = product;
            this.amount = amount;
        }

        public ProductAmountCart() //Only for Entity Framework references should be 0
        { }
    }
}
