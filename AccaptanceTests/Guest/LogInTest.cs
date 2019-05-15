using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Guest;

namespace AccaptanceTests.Guest
{
    [TestClass]
    public class LogInTest
    {
        //use case 2.3:Log in 
        [TestMethod]
        public void Login()
        {
            Workshop192.System system = Workshop192.System.GetInstance();
            system.AddUser("user1", "12345");
            
            Assert.IsTrue(LogIn.Login("user1", "12345"));
            Assert.IsFalse(LogIn.Login("user1", "falsepassword"));
            Assert.IsFalse(LogIn.Login("wrongusername", "12345"));
        }
    }
}
