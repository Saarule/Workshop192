using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Workshop192.UserManagment;

namespace GUI
{
    public class GlobalSpecificUser
    {
        public static int userNum = CommunicationLayer.Controllers.UsersController.CreateUserId();
        public static void Start()
        {
           //Process.Start(@"http://http://localhost:63798/HomePage"); 
        }
    }
}