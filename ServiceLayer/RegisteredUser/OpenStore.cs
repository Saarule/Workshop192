using ServiceLayer.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace ServiceLayer.RegisteredUser
{
    public class OpenStore
    {
        // use case 3.1 - Open Store
        public static bool openStore(string storeName,int userNum)
        {
           return CreateAndGetUser.GetUser(userNum).OpenStore(storeName,userNum);
        }

    }
}
