using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class Timer_Tests
    {
        [Fact]
        public void Start_TimerNotActive_ActivatesTimer()
        {
            // Arrange
            var timer = new Timerr();

            // Act
            timer.Start();

            // Assert
            Assert.True(timer.IsActive);
        }

        [Fact]
        public void Start_GivenTimerActive_ReturnsFalse()
        {
            // Arrange
            var timer = new Timerr();

            // Act
            timer.Start();
            var result = timer.Start();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Stop_GivenTimerActive_DeactivatesTimer()
        {
            // Arrange
            var timer = new Timerr();
            timer.Start(); // Start the timer to make it active

            // Act
            timer.Stop();

            // Assert
            Assert.False(timer.IsActive);
        }

        [Fact]
        public void Stop_GivenTimerNotActive_TimerRemainsDeactivated()
        {
            // Arrange
            var timer = new Timerr();
            timer.Stop(); // Start the timer to make it active

            // Act
            timer.Stop();

            // Assert
            Assert.False(timer.IsActive);
        }


        [Fact]
        public void Reset_ResetsCounterValuesToZero()
        {
            // Arrange
            var timer = new Timerr();
            timer.Start(); // Start the timer to make it active
            timer.Stop();  // Stop the timer before resetting

            // Act
            timer.Reset();

            // Assert
            Assert.Equal("00:00:00", timer.CounterValue);
        }
    }
}
