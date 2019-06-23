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
        public static string getUserNameByUserId(int userId)
        {
            return ServiceLayer.Admin.GetAllUserName.getUserNameByUserId(userId);
        }
        
        public static bool Register(string username, string password, string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
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

            return ServiceLayer.Admin.RemoveUserFromSystem.RemoveUser(userID, usernameToDelete);
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

        public static bool AcceptOwner(string store, string SessionID, string usernameToAccept)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.HandlerRequestAppointment.AcceptAppointment(store, userID, usernameToAccept);
        }

        public static bool DeclineOwner(string store, string SessionID, string usernameToDecline)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);

            return ServiceLayer.Store_Owner_User.HandlerRequestAppointment.DeclineAppointment(store, userID, usernameToDecline);
        }

        public static bool AssignStoreManager(string SessionID, string store, string usernameToAppoint, bool[] privileges)
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

        public static bool IsOwnerOfStore(string SessionID, string storename)
        {
            try
            {
                int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
                return ServiceLayer.Store_Owner_User.IsOwnerOrManage.IsOwner(userID, storename);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsManagerOfStore(string SessionID, string storename)
        {
            try
            {
                int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
                return ServiceLayer.Store_Owner_User.IsOwnerOrManage.IsManager(userID, storename);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsOwner(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.IsOwnerOrManage.IsOwner2(userID);
        }
        public static bool IsManager(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.IsOwnerOrManage.IsManager2(userID);
        }
        public static bool IsLoggedIn(string SessionID)
        {
            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Guest.IsLoggedIn.IsLogged(userID);
        }
        public static LinkedList<string> GetAllUserName()
        {
            return ServiceLayer.Admin.GetAllUserName.GetAllUser();
        }

        public static LinkedList<LinkedList<string>> GetRolesOfStore(string storeName)
        {
            return ServiceLayer.RegisteredUser.GetRoles.GetRolesOfStore(storeName);
        }

        public static LinkedList<string> GetPendingList(string SessionID, string storename)
        {

            int userID = Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(SessionID);
            return ServiceLayer.Store_Owner_User.ShowWaitingList.ShowWaitingsList(userID, storename);
        }
    }
}