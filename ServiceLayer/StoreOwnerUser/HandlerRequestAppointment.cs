using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Store_Owner_User
{
    public class HandlerRequestAppointment
    {
        public static bool AcceptAppointment(string store , int userID, string usernameToAccept)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).AcceptOwner(store, Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(usernameToAccept));
        }

        public static bool DeclineAppointment(string store , int userID , string usernameToDecline)
        {
            return Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).DeclineOwner(store, Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUserInfo(usernameToDecline));
        }
    }
}
