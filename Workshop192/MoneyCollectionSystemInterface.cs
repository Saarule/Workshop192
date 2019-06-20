using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public interface MoneyCollectionSystemInterface
    {
        int CollectFromAccount(string cardNumber, string month, string year, string holder, string ccv, string id);
        int CancelPay(string transactionPayId);
    }
}
