using System;
using NUnit.Framework;
using ServiceLayer;
using ServiceLayer.SystemInitializtion;

namespace AccaptanceTests.SystemInitialization
{
    [TestFixture]
    public class SystemInitializtion
    {
        InitializationOfTheSystem System;
        [SetUp]
        public void SetUp()
        {
            System = new InitializationOfTheSystem();
        }
        [TearDown]
        public void TearDown()
        {
            SystemReset.Reset();
        }
        [TestCase]
        public void TestInitialaizationFile()
        {
            System.Initalize("C:\\initFile");
        }

    }
}
