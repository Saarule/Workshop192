using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyLeafBannedUser : PolicyComponent
    {
        public string userName { get; set; }
        public int policyId { get; set; }
        public string policyProductId { get; set; }

        public PolicyLeafBannedUser(string userName, int policyId, string policyProductId)
        {
            this.userName = userName;
            this.policyId = policyId;
            this.policyProductId = policyProductId;
        }

        public PolicyLeafBannedUser() //Only for Entity Framework references should be 0
        { }

        public bool Validate(int userId, Cart cart)
        {
            if (userName.Equals(""))
                return UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn();
            if (!UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn())
                return !userName.Equals("");
            return !UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetUserName().Equals(userName);
        }

        public override string ToString()
        {
            return "(Banned User = " + userName + ")";
        }
    }
}
