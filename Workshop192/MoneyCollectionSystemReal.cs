using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class MoneyCollectionSystemReal : MoneyCollectionSystemInterface
    {
        public MoneyCollectionSystemReal() { }

        public bool CollectFromAccount(int accountId, int amount)
        {
            return true;
        }
    }
}
