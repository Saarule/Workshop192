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
    {   /*
        // use case 4.1 - Manage Products 
        public static bool ManageProduct(User user , Product product, Store store ,string option)
        {
            if (user.GetInfo()  == null) 
                return false;
            else
            {
                if (option.Equals("edit"))
                {
                    for (int j = 0; j < user.GetInfo().GetOwner(store).GetStore().GetProducts().Count; j++)
                    {
                        if (user.GetInfo().GetOwner(store).GetStore().GetProducts().ElementAt(j).GetId() == product.GetId())
                        {
                            return user.GetInfo().GetOwner(store).EditProduct(user.GetInfo().GetOwner(store).GetStore().GetProducts().ElementAt(j), product);
                        }
                    }
                }
                else if (option.Equals("add"))
                {
                    return user.GetInfo().GetOwner(store).AddProduct(product);
                }
                else if (option.Equals("delete"))
                {
                    return user.GetInfo().GetOwner(store).RemoveProductFromInventory(product);
                }
                return false;
            }
        }
        */
    }
}
