using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class DayRepository_Tests
    {
        [Fact]
        public void IsPositiveNumber_GivenPostiveNumberProvided_ReturnsTrue()
        {
            //Act
            var result = DayRepository.IsPositiveNumber("10");
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPositiveNumber_GivenNegativeNumberProvided_ReturnsFalse()
        {
            //Act
            var result = DayRepository.IsPositiveNumber("-10");
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPositiveNumber_GivenCharactersProvided_ReturnsFalse()
        {
            //Act
            var result = DayRepository.IsPositiveNumber("char");
            //Assert
            Assert.False(result);
        }
    }
}
