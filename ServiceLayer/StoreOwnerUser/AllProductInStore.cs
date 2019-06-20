using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer.Store_Owner_User
{
    public class AllProductInStore
    {
        public static LinkedList<LinkedList<string>> GetAllProducts(string storeName)
        {
            LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
            for (int i = 0; i < Workshop192.MarketManagment.System.GetInstance().GetStore(storeName).GetInventory().Count; i++)
            {
                LinkedList<string> product = new LinkedList<string>();
                product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetStore(storeName).GetInventory().ElementAt(i).Key.GetId() + "");
                product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetStore(storeName).GetInventory().ElementAt(i).Key.GetName() + "");
                product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetStore(storeName).GetInventory().ElementAt(i).Key.GetCategory() + "");
                product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetStore(storeName).GetInventory().ElementAt(i).Key.GetPrice() + "");
                product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetStore(storeName).GetInventory().ElementAt(i).Value + "");
                product.AddLast(storeName);
                products.AddLast(product);
            }
            return products;
        }

        public static LinkedList<LinkedList<string>> GetAll()
        {
            LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
            for (int j = 0; j < Workshop192.MarketManagment.System.GetInstance().GetAllStores().Count; j++) {
                for (int i = 0; i < Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetInventory().Count; i++)
                {
                    LinkedList<string> product = new LinkedList<string>();
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetInventory().ElementAt(i).Key.GetId() + "");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetInventory().ElementAt(i).Key.GetName() + "");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetInventory().ElementAt(i).Key.GetCategory() + "");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetInventory().ElementAt(i).Key.GetPrice() + "");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetInventory().ElementAt(i).Value + "");
                    product.AddLast(Workshop192.MarketManagment.System.GetInstance().GetAllStores().ElementAt(j).GetName());
                    products.AddLast(product);
                }
            }
            return products;
        }
    }
}

