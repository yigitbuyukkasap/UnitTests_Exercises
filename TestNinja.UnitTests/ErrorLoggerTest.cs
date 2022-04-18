﻿

using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    //private ErrorLogger _logger;

    //[SetUp]
    //public void SetUp()
    //{
    //    _logger = new ErrorLogger();
    //}
    [TestFixture]
    public class ErrorLoggerTest
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent() {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
