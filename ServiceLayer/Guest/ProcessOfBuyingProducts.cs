using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace ServiceLayer.Guest
{
    // use case 2.8 - Process of buying policy
    public class ProcessOfBuyingProducts
    {
        public static string[] ProcessBuyingProducts(string cardNumber, string month, string year, string holder,
            string ccv, string ID, string name, string address, string city, string country, string zip, int userId)
        {
            if (!CheckAvailability.CheckAvailable(userId)) {
                throw new Exception("The amount greater than Inventory amount");
            }

            Tuple<int , int> ret = Workshop192.MarketManagment.System.GetInstance().PurchaseProducts(userId,cardNumber, month, year, holder, ccv, ID, name, address, city, country,zip);
            string[] Ret = new string[2];
            Ret[0] = ret.Item1 + "";
            Ret[1] = ret.Item2 + "";
            return Ret;
        }
    }
}
