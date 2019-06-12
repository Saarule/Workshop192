using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace ServiceLayer.Guest
{
   public class FilterProducts
    {
        // use case 2.5(1) - Filter Products
        public static LinkedList<LinkedList<string>> Filter(string filter, LinkedList<LinkedList<string>> products)
        {
            LinkedList<LinkedList<string>> FoundProducts = new LinkedList<LinkedList<string>>();
            for (int j = 0; j < products.Count; j++)
            {
                if (products.ElementAt(j).ElementAt(1).Equals(filter))
                {
                    LinkedList<string> toAdd = new LinkedList<string>();
                    toAdd.AddLast(products.ElementAt(j).ElementAt(0));
                    toAdd.AddLast(products.ElementAt(j).ElementAt(1));
                    toAdd.AddLast(products.ElementAt(j).ElementAt(2));
                    toAdd.AddLast(products.ElementAt(j).ElementAt(3));
                    toAdd.AddLast(products.ElementAt(j).ElementAt(4));
                    toAdd.AddLast(products.ElementAt(j).ElementAt(5));
                    FoundProducts.AddLast(toAdd);
                }
            }
            return FoundProducts;
        }
    }
}
