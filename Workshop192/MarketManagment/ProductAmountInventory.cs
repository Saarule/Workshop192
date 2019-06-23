using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class ProductAmountInventory
    {
        public string storeName { get; set; }
        public virtual Store store { get; set; }
        public int productId { get; set; }
        public virtual Product product { get; set; }
        public int amount { get; set; }

        public ProductAmountInventory(Store store, Product product, int amount)
        {
            storeName = store.GetName();
            this.store = store;
            productId = product.GetId();
            this.product = product;
            this.amount = amount;
        }
    }
}
