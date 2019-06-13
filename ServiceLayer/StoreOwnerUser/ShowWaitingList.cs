using ServiceLayer.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.StoreOwnerUser
{
    class ShowWaitingList
    {
        public static LinkedList<string> ShowWaitingsList(int userId,string Store)
        {
            return CreateAndGetUser.GetUser(userId).GetInfo().GetOwner(Store).GetPendingUsers();
        }
    }
}
