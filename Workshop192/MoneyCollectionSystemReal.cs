using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class MoneyCollectionSystemReal : MoneyCollectionSystemInterface
    {
        public MoneyCollectionSystemReal() { }

        public int CollectFromAccount(string cardNumber, string month, string year, string holder, string ccv, string id)
        {
            try
            {
                string URL = "https://cs-bgu-wsep.herokuapp.com";
                string responseInString;
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["action_type"] = "pay";
                    data["card_number"] = cardNumber;
                    data["month"] = month;
                    data["year"] = year;
                    data["holder"] = holder;
                    data["ccv"] = ccv;
                    data["id"] = id;
                    var response = wb.UploadValues(URL, "POST", data);
                    responseInString = Encoding.UTF8.GetString(response);
                }
                return int.Parse(responseInString);
            }
            catch (Exception e)
            {
                throw new ErrorMessageException(e.Message);
            }
        }

        public int CancelPay(string transactionPayID)
        {
            try {
                string URL = "https://cs-bgu-wsep.herokuapp.com";
                string responseInString;
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["action_type"] = "cancel_pay";
                    data["transaction_id"] = transactionPayID;

                    var response = wb.UploadValues(URL, "POST", data);
                    responseInString = Encoding.UTF8.GetString(response);
                }
                return int.Parse(responseInString);
            }
            catch (Exception e)
            {
                throw new ErrorMessageException(e.Message);
            }
        }
    }
}
