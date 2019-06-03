using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace ServiceLayer.Guest
{
    // use case 2.5 - Search Products
    public class SearchProducts
    {
        public static LinkedList<LinkedList<string>> Search(string input)
        {
            LinkedList<LinkedList<string>> FoundProducts = new LinkedList<LinkedList<string>>();
            Store CurrentStore;
            LinkedList<Store> AllStores = Workshop192.MarketManagment.System.GetInstance().GetAllStores();

            for (int i = 0; i < AllStores.Count; i++)
            {
                CurrentStore = AllStores.ElementAt(i);
                Dictionary< Product , int > ProductsPerStore = CurrentStore.GetInventory();
                for (int j = 0; j < ProductsPerStore.Count; j++)
                {
                    if (ProductsPerStore.ElementAt(j).Key.GetName().Contains(input))
                    {
                        LinkedList<string> toAdd = new LinkedList<string>();
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).Key.GetId() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).Key.GetName() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).Key.GetCategory() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).Key.GetPrice() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).Value + "");
                        toAdd.AddLast(CurrentStore.GetName());
                        FoundProducts.AddLast(toAdd);
                    }
                }
            }
            return FoundProducts;
        }
    }
}
