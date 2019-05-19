using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
    // use case 2.5 - Search Products
    public class SearchProducts
    {
        public static LinkedList<Workshop192.MarketManagment.Product> Search(string input)
        {
            LinkedList<Workshop192.MarketManagment.Product> FoundProducts = new LinkedList<Workshop192.MarketManagment.Product>();
            Workshop192.MarketManagment.Store CurrentStore;
            LinkedList<Workshop192.MarketManagment.Store> AllStores = Workshop192.System.GetInstance().GetAllStores();

            for (int i = 0; i < AllStores.Count; i++)
            {
                CurrentStore = AllStores.ElementAt(i);
                LinkedList<Workshop192.MarketManagment.Product> ProductsPerStore = CurrentStore.GetProducts();
                for (int j = 0; j < ProductsPerStore.Count; j++)
                {
                    if (ProductsPerStore.ElementAt(j).GetName().Contains(input))
                        FoundProducts.AddLast(ProductsPerStore.ElementAt(j));
                }
            }
            return FoundProducts;
        }
    }
}
