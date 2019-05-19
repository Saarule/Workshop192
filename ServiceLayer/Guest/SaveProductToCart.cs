using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class SaveProductToCart
    {
        // use case 2.6 - Save products to cart
        public static bool SaveProduct(Product product, Store store, User user)
        {
            foreach (Product p in store.GetProducts()) {
                if (p.GetId() == product.GetId())
                {
                    Product tmp = product;
                    store.GetProducts().Remove(product);
                    if (!user.AddProductToCart(tmp, store)) {
                        store.GetProducts().AddLast(tmp);
                        return false;
                    }

                    return true;
                }
                    
            }
            return false;
            
        }
    }
}
