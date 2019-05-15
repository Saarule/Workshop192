using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests
{
    [TestClass]
    class SystemInitialaization
    {
        [TestMethod]
        public void TestInitialaization()
        {
            ServiceLayer.InitializationOfTheSystem init = new ServiceLayer.InitializationOfTheSystem();
        }
    }
}
