using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class WatchAndEdit
    {
        // use case 2.7 - watch and edit to cart
        public static LinkedList<LinkedList<string>> Watch(int userNum)
        {
            LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
            for (int i = 0; i < Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().Count; i++)
            {
                for(int j = 0; j < Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().Count; j++)
                {
                    LinkedList<string> product = new LinkedList<string>();
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetId()+"");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetName()+"");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetCategory()+"");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetPrice()+"");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().ElementAt(j).Key.GetId()+"");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetProducts().ElementAt(j).Value+"");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetMultiCart(CreateAndGetUser.GetUser(userNum).GetMultiCart()).GetCarts().ElementAt(i).GetStore().GetName());
                    products.AddLast(product);
                }
            }
            return products;
        }

        public static bool Edit(string option, string productID, int userID)
        {
            if (option.Equals("delete"))
            {
                ///return AllRegisteredUsers.GetInstance().GetUser(userID).RemoveProductFromCart();

            }
            else if (option.Equals("edit"))
            {
                ///return AllRegisteredUsers.GetInstance().GetUser(userID).();
                ///has no support to edit from domain
            }

            return false;
        }
    }
}
