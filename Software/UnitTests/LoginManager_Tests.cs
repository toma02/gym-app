using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace UnitTests
{
    public class LoginManager_Tests
    {

        [Fact]
        public void MaxLoginAttemptsReached_GivenMaxAttemptsNotReachedYet_ReturnsFalse()
        {
            LoginManager.IncreaseLoginAttemptCounter();
            var result = LoginManager.MaxLoginAttemptsReached();

            Assert.False(result);
            LoginManager.ClearLoginAttempts();
        }

        [Fact]
        public void MaxLoginAttemptsReached_GivenMaxAttemptsAreReached_ReturnsTrue()
        {
            LoginManager.IncreaseLoginAttemptCounter();
            LoginManager.IncreaseLoginAttemptCounter();
            LoginManager.IncreaseLoginAttemptCounter();
            LoginManager.IncreaseLoginAttemptCounter();
            var result = LoginManager.MaxLoginAttemptsReached();

            Assert.True(result);
            LoginManager.ClearLoginAttempts();
        }
    }
}
