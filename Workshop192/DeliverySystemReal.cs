using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192
{
    public class DeliverySystemReal : DeliverySystemInterface
    {
        public int Deliver(string name, string address, string city, string country, string zip)
        {
            string URL = "https://cs-bgu-wsep.herokuapp.com";
            string responseInString;
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["action_type"] = "supply";
                data["name"] = name;
                data["address"] = address;
                data["city"] = city;
                data["country"] = country;
                data["zip"] = zip;
                var response = wb.UploadValues(URL, "POST", data);
                responseInString = Encoding.UTF8.GetString(response);
            }
            return int.Parse(responseInString);
        }
        public int CancelDelivery(string transactionSupplyID)
        {
            string URL = "https://cs-bgu-wsep.herokuapp.com";
            string responseInString;
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["action_type"] = "cancel_supply";
                data["transaction_id"] = transactionSupplyID;

                var response = wb.UploadValues(URL, "POST", data);
                responseInString = Encoding.UTF8.GetString(response);
            }
            return int.Parse(responseInString);
        }
    }
}
