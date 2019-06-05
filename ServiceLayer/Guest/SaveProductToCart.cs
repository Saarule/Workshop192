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
        public static bool SaveProduct(int productId,int userID,int amount)
        {
            for(int i = 0; i < Workshop192.MarketManagment.System.GetInstance().GetAllStores().Count; i++)
            {
                for(int j = 0; j < Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(i).GetInventory().Count; j++)
                {
                    if (Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(i).GetInventory().ElementAt(j).Key.GetId() == productId)
                    {
                        string storeName = Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(i).GetName();
                        Product product = Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(i).GetInventory().ElementAt(j).Key;
                        return AllRegisteredUsers.GetInstance().GetUser(userID).AddProductsToMultiCart(storeName, product, amount);
                    }
                }
            }
            return false;
        }
    }
}
