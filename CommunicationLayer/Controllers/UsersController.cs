using CommunicationLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    }
}
