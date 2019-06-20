using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.SystemInitializtion;
using Workshop192;

namespace AccaptanceTests.SystemInitialization
{
    [TestFixture]
    public class SystemInitializtion
    {
        InitializationOfTheSystem System;
        [SetUp]
        public void SetUp()
        {
            DbCommerce.GetInstance().StartTests();
            System = new InitializationOfTheSystem();
        }
        [TearDown]
        public void TearDown()
        {
            DbCommerce.GetInstance().EndTests();
            SystemReset.Reset();
        }
        [TestCase]
        public void TestInitialaizationFile()
        {
            System.Initalize("C:\\initFile");
        }

    }
}
