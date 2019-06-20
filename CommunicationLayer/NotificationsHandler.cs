using CommunicationLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunicationLayer
{
    public class NotificationsHandler
    {

        public static LinkedList<string> Send_Notifications_To_Me(string SessionID)
        {
            int UserId = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            string username = Dictionary_SessionId_UserId.GetUserName(UserId);
            return Notifications.Notification.GetInstance().Send_Notifications_To_Me(username);
        }
    }
}