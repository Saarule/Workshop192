using CommunicationLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceLayer;
using User = CommunicationLayer.Models.User.User;

namespace CommunicationLayer.Controllers
{
    public class UsersController : ApiController
    {
        /*
        User[] users = new User[]
        {
            new User { Id = 1, UserName = "Tomato", Age = 23 , Address = "Tel Aviv" },
            new User { Id = 2, UserName = "Apple", Age =  45, Address = "Haifa" },
            new User { Id = 3, UserName = "Orange", Age = 19, Address= "Eilat" },
        };



        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public IHttpActionResult GetUser(int id)
        {
            var product = users.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }*/

        public static bool Register(string username, string password, string SessionID)
        {
            int userID=Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Guest.Register.Registration(username, password, userID);
        }

        public static bool Login(string username, string password, string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Guest.LogIn.Login(username, password, userID);
        }

        public static bool Logout(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.RegisteredUser.LogOut.Logout(userID);
        }
        public static bool RemoveUserFromSystem(string SessionID, string usernameToDelete)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Admin.RemoveUserFromSystem.RemoveUser(userID,usernameToDelete);
        }
        public static bool IsAdmin(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Admin.IsAdmin.isAdmin(userID);
        }

        public static int CreateUserId()
        {
            return ServiceLayer.Guest.CreateAndGetUser.CreateUser();
        }

        public static bool AcceptOwner(string store , string SessionID , string usernameToAccept)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.HandlerRequestAppointment.AcceptAppointment(store, userID, usernameToAccept);
        }

        public static bool DeclineOwner(string store, string SessionID, string usernameToDecline)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.HandlerRequestAppointment.DeclineAppointment(store, userID, usernameToDecline);
        }

        public static bool AssignStoreManager(string SessionID,string store,string usernameToAppoint,bool [] privileges)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.AssignStoreManager.AsssignManager(userID, store, usernameToAppoint, privileges);
        }

        public static bool AssignStoreOwner(string SessionID, string store, string usernameToAppoint)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.AssignStoreOwner.assignStoreOwner(userID, store, usernameToAppoint);
        }

        public static bool RemoveStoreManger(string SessionID, string store, string usernameToDelete)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.RemoveStoreManager.removeStoreManager(userID, store, usernameToDelete);
        }

        public static LinkedList<LinkedList<string>> GetRoles(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.RegisteredUser.GetRoles.getRoles(userID);
        }
    }
}