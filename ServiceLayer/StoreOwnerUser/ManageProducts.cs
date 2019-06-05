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
        public static bool ManageProduct(int userID , int productID,string name,string category,int price,int amount, string store ,string option)
        {
            if (AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo()  == null) 
                return false;
            else
            {
                if (option.Equals("edit"))
                {
                    AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetOwner(store).EditProduct(productID,name,category,price,amount);
                    return true;
                }
                else if (option.Equals("add"))
                {
                    Product product = Workshop192.MarketManagment.System.GetInstance().CreateProduct(name, category, price);
                    AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetOwner(store).AddProducts(product,amount);
                    return true;
                }
                else if (option.Equals("delete"))
                {
                    return AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetOwner(store).RemoveProductFromInventory(productID);
                }
                return false;
            }
        }
    }
}
