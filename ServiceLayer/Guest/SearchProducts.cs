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
                LinkedList<ProductAmountInventory> ProductsPerStore = CurrentStore.GetInventory();
                for (int j = 0; j < ProductsPerStore.Count; j++)
                {
                    if (ProductsPerStore.ElementAt(j).product.GetName().Contains(input))
                    {
                        LinkedList<string> toAdd = new LinkedList<string>();
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).product.GetId() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).product.GetName() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).product.GetCategory() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).product.GetPrice() + "");
                        toAdd.AddLast(ProductsPerStore.ElementAt(j).amount + "");
                        toAdd.AddLast(CurrentStore.GetName());
                        FoundProducts.AddLast(toAdd);
                    }
                }
            }
            return FoundProducts;
        }


        public static LinkedList<string> SearchById(int productId)
        {
            Store CurrentStore;
            LinkedList<Store> AllStores = Workshop192.MarketManagment.System.GetInstance().GetAllStores();
            LinkedList<string> toRet = new LinkedList<string>();
            bool toKeep = true;
            for (int i = 0; i < AllStores.Count && toKeep; i++)
            {
                CurrentStore = AllStores.ElementAt(i);
                LinkedList<ProductAmountInventory> ProductsPerStore = CurrentStore.GetInventory();
                for (int j = 0; j < ProductsPerStore.Count && toKeep; j++)
                {
                    if (ProductsPerStore.ElementAt(j).product.GetId().Equals(productId))
                    {
                        toRet.AddLast(ProductsPerStore.ElementAt(j).product.GetId() + "");
                        toRet.AddLast(ProductsPerStore.ElementAt(j).product.GetName() + "");
                        toRet.AddLast(ProductsPerStore.ElementAt(j).product.GetCategory() + "");
                        toRet.AddLast(ProductsPerStore.ElementAt(j).product.GetPrice() + "");
                        toRet.AddLast(ProductsPerStore.ElementAt(j).amount + "");
                        toRet.AddLast(CurrentStore.GetName());
                        toKeep = false;
                    }
                }
            }
            return toRet; ;
        }

    }
}
