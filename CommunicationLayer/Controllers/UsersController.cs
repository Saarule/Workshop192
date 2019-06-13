using CommunicationLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceLayer;
using Workshop192.UserManagment;
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

        public static bool Register(string username, string password, int userID)
        {
            return ServiceLayer.Guest.Register.Registration(username, password, userID);
        }

        public static bool Login(string username, string password, int userID)
        {
            return ServiceLayer.Guest.LogIn.Login(username, password, userID);
        }

        public static bool Logout(int userID)
        {
            return ServiceLayer.RegisteredUser.LogOut.Logout(userID);
        }
        public static bool RemoveUserFromSystem(int userID, string usernameToDelete)
        {
            return ServiceLayer.Admin.RemoveUserFromSystem.RemoveUser(userID,usernameToDelete);
        }
        public static bool IsAdmin(int userID)
        {
            return ServiceLayer.Admin.IsAdmin.isAdmin(userID);
        }

        public static int CreateUserId()
        {
            return ServiceLayer.Guest.CreateAndGetUser.CreateUser();
        }


        
        public static bool AssignStoreManager(int userId,string store,string usernameToAppoint,bool [] privileges)
        {
            return ServiceLayer.Store_Owner_User.AssignStoreManager.AsssignManager(userId, store, usernameToAppoint, privileges);
        }

        public static bool AssignStoreOwner(int userId, string store, string usernameToAppoint)
        {
            return ServiceLayer.Store_Owner_User.AssignStoreOwner.assignStoreOwner(userId, store, usernameToAppoint);
        }

        public static bool RemoveStoreManger(int userId, string store, string usernameToDelete)
        {
            return ServiceLayer.Store_Owner_User.RemoveStoreManager.removeStoreManager(userId, store, usernameToDelete);
        }

        public static LinkedList<LinkedList<string>> GetRoles(int userID)
        {
            return ServiceLayer.RegisteredUser.GetRoles.getRoles(userID);
        }

    }
}