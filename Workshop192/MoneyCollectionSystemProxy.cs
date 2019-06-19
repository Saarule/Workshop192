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

        public int CollectFromAccount(int cardNumber, int month, int year, string holder, int ccv, int id)
        {
            if (real == null)
                return -1;
            return real.CollectFromAccount(cardNumber, month, year, holder, ccv, id);
        }
    }
}
