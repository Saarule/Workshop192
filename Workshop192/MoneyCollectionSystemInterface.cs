using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public interface MoneyCollectionSystemInterface
    {
        int CollectFromAccount(int cardNumber, int month, int year, string holder, int ccv, int id);
    }
}
