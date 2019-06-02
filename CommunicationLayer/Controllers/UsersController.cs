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
        }

        public static bool Register(string username, string password,string userID)
        {
            return ServiceLayer.Guest.Register.Registration(username, password, userID);
        }

        public static bool Login(string username, string password, string userID)
        {
            return ServiceLayer.Guest.LogIn.Login(username, password, userID);
        }

        public static bool Logout(string userID)
        {
            return ServiceLayer.RegisteredUser.LogOut.Logout(userID);
        }
    }
}
