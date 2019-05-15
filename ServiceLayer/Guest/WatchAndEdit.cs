using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    public class WatchAndEdit
    {
        public WatchAndEdit()
        {

        }
        public static LinkedList<Cart> Watch(User user)
        {
            return user.GetCarts();
        }
        public static bool Edit(LinkedList<Cart> carts , string option , Product p)
        {
            if (option.Equals("delete"))
            {
                for(int i = 0; i < carts.Count; i++)
                {
                    for(int j = 0; j < carts.ElementAt(i).GetProducts().Count; j++)
                    {
                        if (carts.ElementAt(i).GetProducts().ElementAt(j).GetId() == p.GetId())
                        {
                            carts.ElementAt(i).GetProducts().Remove(carts.ElementAt(i).GetProducts().ElementAt(j));
                            return true;
                        }
                    }
                }
            }
            else if (option.Equals("edit"))
            {
                for (int i = 0; i < carts.Count; i++)
                {
                    for (int j = 0; j < carts.ElementAt(i).GetProducts().Count; j++)
                    {
                        if (carts.ElementAt(i).GetProducts().ElementAt(j).GetId() == p.GetId())
                        {
                            carts.ElementAt(i).GetProducts().Find(carts.ElementAt(i).GetProducts().ElementAt(j)).Value = p;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
