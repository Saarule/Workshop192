using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.MarketManagment
{
    public class PolicyLeafUserName : PolicyComponent
    {
        private string userName;
        private string operation;

        public PolicyLeafUserName(string userName, string operation)
        {
            this.userName = userName;
            this.operation = operation;
        }

        public bool Validate(int userId, Cart cart)
        {
            switch (operation)
            {
                case "==":
                    if (userName == "" && !UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn())
                        return true;
                    else if (!UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn())
                        return false;
                    else
                        return UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetInfo().GetUserName() == userName;
                case "!=":
                    if (userName != "" && !UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn())
                        return true;
                    else if (!UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).IsLoggedIn())
                        return false;
                    else
                        return UserManagment.AllRegisteredUsers.GetInstance().GetUser(userId).GetInfo().GetUserName() != userName;
                default:
                    return false;
            }
        }
    }
}
