using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace AcceptanceTests
{
    [TestClass]
    class SystemInitialaization
    {
        // use case 1.1 : initialization of the system
        [TestMethod]
        public void TestInitialaization()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            Assert.IsTrue(init.IsInitialized());
            Assert.IsFalse(init.Initalize()); // seconed time
            
        }
    }
}
