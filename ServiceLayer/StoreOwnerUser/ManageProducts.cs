using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    public class ManageProducts
    {
        // use case 4.1 - Manage Products 
        public static bool ManageProduct(Product product, StoreOwner userOwner,string option)
        {
            if (userOwner == null) 
                return false;
            else
            {
                if (option.Equals("edit"))
                {
                    for (int j = 0; j < userOwner.GetStore().GetProducts().Count; j++)
                    {
                        if (userOwner.GetStore().GetProducts().ElementAt(j).GetId() == product.GetId())
                        {
                            return userOwner.EditProduct(userOwner.GetStore().GetProducts().ElementAt(j), product);
                        }
                    }
                }
                else if (option.Equals("add"))
                {
                    return userOwner.AddProduct(product);
                }
                else if (option.Equals("delete"))
                {
                    return userOwner.RemoveProduct(product);
                }
                return false;
            }
        }
    }
}
