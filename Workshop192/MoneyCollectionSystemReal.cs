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

        public int CollectFromAccount(string cardNumber, string month, string year, string holder, string ccv, string id)
        {
            return new Random().Next(10000, 100000);
        }
    }
}
