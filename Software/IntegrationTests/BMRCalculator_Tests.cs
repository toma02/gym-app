using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class BMRCalculator_Tests
    {
        [Fact]
        public void CalculateBMR_GivenTheUserExistWithValidData_ReturnsBMR()
        {
            // Arrange
            UserRepository.SaveCurrentUser("ivor");
            var user = UserRepository.GetUser("ivor");
            var bmrCalculator = new BMRCalculator();

            // Act
            var userBMR = (int)bmrCalculator.CalculateBMR();

            // Assert
            Assert.Equal(2236, userBMR);
        }

        [Fact]
        public void CalculateBMR_GivenTheUserDoesntExist_Returns0()
        {
            // Arrange
            UserRepository.SaveCurrentUser("tralala");
            var user = UserRepository.GetUser("tralala");
            var bmrCalculator = new BMRCalculator();

            // Act
            var userBMR = (int)bmrCalculator.CalculateBMR();

            // Assert
            Assert.Equal(0, userBMR);
        }
    }
}
