﻿using CommunicationLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceLayer;

namespace CommunicationLayer.Controllers
{
    public class UsersController : ApiController
    {
        List<User> users = new List<User>
        {
            new User { Id = 1, UserName = "DanNicolas", Age = 23 , Address = "Tel Aviv" },
            new User { Id = 2, UserName = "AlmaBrown", Age =  45, Address = "Haifa" },
            new User { Id = 3, UserName = "NiceDogPerson", Age = 19, Address= "Eilat" },
        };

        //Get: api/users
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        //Get: api/users/5
        public IHttpActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault((u) => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public bool Register(String username, String password)
        {
            return ServiceLayer.Guest.Register.Registration(username, password, null); 
        }

        public bool SignIn(String username, String password)
        {
            return ServiceLayer.Guest.LogIn.Login(username,password, null);
        }

        //Get: api/users/5
        public void Post(User user)
        {
            users.Add(user);
        }
    }
}