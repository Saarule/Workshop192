using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class Admin
    {
        private UserInfo user;

        public Admin (UserInfo user)
        {
            this.user = user;
        }

        public bool RemoveUser(UserInfo user)
        {
            if (AllRegisteredUsers.GetInstance().RemoveUser(user))
            {
                Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " removed user " + user.GetUserName() + " as an admin");
                return true;
            }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " was unable to remove user " + user.GetUserName() + " as an admin");
            return false;
        }

        public bool MakeAdmin(UserInfo user)
        {
            if (user.IsAdmin())
            {
                Logger.GetInstance().WriteToErrorLog(this.user.GetUserName() + " tried making " + user.GetUserName() + " an admin but the given user is already an admin");
                throw new ErrorMessageException("Given user is already admin");
            }
            Logger.GetInstance().WriteToEventLog(this.user.GetUserName() + " made user " + user.GetUserName() + " an admin");
            return user.SetAdmin();
        }
    }
}
