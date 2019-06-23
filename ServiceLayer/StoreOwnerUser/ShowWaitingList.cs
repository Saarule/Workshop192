using ServiceLayer.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    public class ShowWaitingList
    {
        public static LinkedList<string> ShowWaitingsList(int userId,string Store)
        {
            LinkedList<string> ret = new LinkedList<string>();
            foreach (UserInfo info in CreateAndGetUser.GetUser(userId).GetInfo().GetOwner(Store).GetPendingUsers())
                ret.AddLast(info.GetUserName());
            return ret;
        }
    }
}
