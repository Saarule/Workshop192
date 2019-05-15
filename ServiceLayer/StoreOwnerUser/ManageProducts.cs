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
        public ManageProducts()
        {

        }
        public static bool ManageProduct(Product pro, StoreOwner so, string option)
        {
            if (so.GetUser().GetLoggedIn() == false)
                return false;
            else
            {
                if (option.Equals("edit"))
                {
                    for (int j = 0; j < so.GetStore().GetProducts().Count; j++)
                    {
                        if (so.GetStore().GetProducts().ElementAt(j).GetProductID() == pro.GetProductID())
                        {
                            //so.GetStore().GetProducts().Find(so.GetStore().GetProducts().ElementAt(j)).Value = pro;
                            so.EditProduct(so.GetStore().GetProducts().ElementAt(j), pro);
                            return true;
                        }
                    }
                }
                else if (option.Equals("add"))
                {
                    so.AddProduct(pro);
                    return true;
                }
                else if (option.Equals("delete"))
                {
                    so.RemoveProduct(pro);
                    return true;
                }

                return false;
            }
        }
    }
}
