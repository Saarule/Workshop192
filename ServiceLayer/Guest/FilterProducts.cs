using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
   public class FilterProducts
    {
        // use case 2.5(1) - Filter Products
        public static LinkedList<Workshop192.MarketManagment.Product> Filter(LinkedList<Workshop192.MarketManagment.Product> Products,string filter)
        { 
            LinkedList<Workshop192.MarketManagment.Product> FilteredProducts = new LinkedList<Workshop192.MarketManagment.Product>();
            for (int j = 0; j < Products.Count; j++)
            {
                 if (Products.ElementAt(j).GetName().Contains(filter))
                 FilteredProducts.AddLast(FilteredProducts.ElementAt(j));
            }
            return FilteredProducts;
        }
            
    }
}
