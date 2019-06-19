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

        public int CollectFromAccount(int cardNumber, int month, int year, string holder, int ccv, int id)
        {
            return new Random().Next(10000, 100000);
        }
    }
}
