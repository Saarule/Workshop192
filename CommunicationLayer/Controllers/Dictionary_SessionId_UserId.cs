using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLayer.Guest;

namespace CommunicationLayer.Controllers
{
    public class Dictionary_SessionId_UserId
    {
        private Dictionary<string, int> SessionId_UserId_Dictionary;
        private static Dictionary_SessionId_UserId instance = null;

        private Dictionary_SessionId_UserId()
        {
            SessionId_UserId_Dictionary = new Dictionary<string, int>();
        }

        public static Dictionary_SessionId_UserId GetInstance()
        {
            if (instance == null)
            {
                instance = new Dictionary_SessionId_UserId();
            }
            return instance;
        }



        public int Get_UserId_From_Dictionary(string SessionId)
        {
            if (!SessionId_UserId_Dictionary.ContainsKey(SessionId))
                SessionId_UserId_Dictionary.Add(SessionId, CreateAndGetUser.CreateUser());
            return SessionId_UserId_Dictionary[SessionId];



        }
        
    }
}