using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    class MoneyCollectionSystemProxy : MoneyCollectionSystemInterface
    {
        private MoneyCollectionSystemReal real;

        public MoneyCollectionSystemProxy(MoneyCollectionSystemReal real)
        {
            this.real = real;
        }

        public bool CollectFromAccount(int accountId, int amount)
        {
            if (real == null)
                return false;
            return real.CollectFromAccount(accountId, amount);
        }
    }
}
