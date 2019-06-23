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
            string AllNames = AllRegisteredUsers.GetInstance().GetUser(userId).GetInfo().GetOwner(Store).pendingUsers;
            if (AllNames == null)
                AllNames = "";
            string[] names = AllNames.Split('$');
            for (int i = 0; i < names.Length; i++)
            {
                ret.AddLast(names[i]);
            }
            return ret;
        }
    }
}
