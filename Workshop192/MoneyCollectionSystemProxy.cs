using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class MoneyCollectionSystemProxy : MoneyCollectionSystemInterface
    {
        private MoneyCollectionSystemReal real;

        public MoneyCollectionSystemProxy(MoneyCollectionSystemReal real)
        {
            this.real = real;
        }

        public int CollectFromAccount(string cardNumber, string month, string year, string holder, string ccv, string id)
        {
            if (real == null)
                return -1;
            return real.CollectFromAccount(cardNumber, month, year, holder, ccv, id);
        }

        public int CancelPay(string transactionPayId)
        {
            if (real == null)
                return -1;
            return real.CancelPay(transactionPayId);
        }
    }
}
