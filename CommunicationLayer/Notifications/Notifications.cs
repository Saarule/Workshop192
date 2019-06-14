using CommunicationLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunicationLayer.Notifications
{
    public class Notifications
    {
        private Dictionary<string, LinkedList<string>> Message_To_Users_List;
        private static Notifications instance = null;

        private Notifications()
        {
            Message_To_Users_List = new Dictionary<string, LinkedList<string>>();
        }

        public static Notifications GetInstance()
        {
            if (instance == null)
            {
                instance = new Notifications();
            }
            return instance;
        }

        public void SendMessageToUser (string username, string message)
        {
            if (!Message_To_Users_List.ContainsKey(username))

                Message_To_Users_List.Add(username, new LinkedList<string>());
            Message_To_Users_List[username].AddLast(message);
            
        }
        public LinkedList<string> Send_Notifications_To_Me(string SessionID)
        {
            int UserId = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            string username = ServiceLayer.Guest.CreateAndGetUser.GetUserName(UserId);
            LinkedList<string> messages = new LinkedList<string>();
            //create copy of list of messages
            for(int i=0;i< Message_To_Users_List[username].Count; i++)
            {
                messages.AddLast(Message_To_Users_List[username].ElementAt(i));
            }

            //empty the list in dictionary
            Message_To_Users_List[username] = new LinkedList<string>();

            return messages;
        }
    }
}