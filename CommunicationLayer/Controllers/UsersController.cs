
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