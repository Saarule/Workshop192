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
        public SaveProductToCart() { }


        public static bool SaveProduct(Product p, User user)
        {
            LinkedList<Cart> carts = user.GetCarts();
            Store StorePerCart;
            for (int i = 0; i < carts.Count; i++)
            {
                StorePerCart = carts.ElementAt(i).GetStoreOfCart();
                for (int j = 0; j < StorePerCart.GetProducts().Count; j++)
                {
                    if (StorePerCart.GetProducts().ElementAt(j).GetProductID() == p.GetProductID())
                    {
                        user.GetCarts().ElementAt(i).AddProduct(p);
                        return true;
                    }

                }
            }
            Store s = findStore(p);
            if (s != null)
            {
                carts.AddLast(new Cart(s));
                return true;
            }
            return false;
        }

        private static Store findStore(Product p)
        {
            for (int i = 0; i < Workshop192.System.GetInstance().GetAllStores().Count; i++) {
                for(int j = 0; j < Workshop192.System.GetInstance().GetAllStores().ElementAt(i).GetProducts().Count; j++)
                {
                    if (Workshop192.System.GetInstance().GetAllStores().ElementAt(i).GetProducts().ElementAt(j).GetProductID() == p.GetProductID()) {
                        return Workshop192.System.GetInstance().GetAllStores().ElementAt(i);
                    }
                }
            }
            return null;
        }
    }
}
