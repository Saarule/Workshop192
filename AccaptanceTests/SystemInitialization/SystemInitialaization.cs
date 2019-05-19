using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ServiceLayer;

namespace AccaptanceTests.SystemInitialization
{
    [TestClass]
    public class SystemInitializtion
    {
        [SetUp]

        [TestCase]
        public void TestInitialaization()
        {
            InitializationOfTheSystem init = new InitializationOfTheSystem();
            NUnit.Framework.Assert.IsTrue(true);
            NUnit.Framework.Assert.IsFalse(false);
            NUnit.Framework.Assert.IsTrue(!!true);
            // Assert.IsFalse(); // seconed time
        }
        //[TearDown]
        
    }
}
