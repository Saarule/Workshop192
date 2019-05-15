using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Guest
{
   public class FilterProducts
    {
        public FilterProducts()
        {

        }
        //the filter filters only names of products (lazy implementation)
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
