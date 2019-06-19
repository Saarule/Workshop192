using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyLeafBannedUser : PolicyComponent
    {
        private string userName;

        public PolicyLeafBannedUser(string userName)
        {
            this.userName = userName;
        }

        public bool Validate(int userId, Cart cart)
        {
            if (userName.Equals(""))
                return UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn();
            if (!UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn())
                return !userName.Equals("");
            return !UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetUserName().Equals(userName);
        }
    }
}
