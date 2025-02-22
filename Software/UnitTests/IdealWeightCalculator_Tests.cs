using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class IdealWeightCalculator_Tests
    {
        [Fact]
        public void CalculateIdealWieght_GivenAMaleWithHeightOf170_ReturnsIdealWeight()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var idealWeight = weightCalculator.CalculateIdealWieght("male", 170);
            //Assert
            Assert.Equal(57.77, idealWeight);
        }

        [Fact]
        public void CalculateIdealWieght_GivenAFemaleWithHeightOf160_ReturnsIdealWeight()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var idealWeight = weightCalculator.CalculateIdealWieght("female", 160);
            //Assert
            Assert.Equal(54.53, idealWeight);
        }

        [Fact]
        public void CalculateIdealWieght_GivenAMaleWithHeightOf160_ReturnsIdealWeight()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var idealWeight = weightCalculator.CalculateIdealWieght("male", 160);
            //Assert
            Assert.Equal(57.68, idealWeight);
        }

        [Fact]
        public void CalculateIdealWieght_GivenAFemaleWithHeightOf165_ReturnsIdealWeight()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var idealWeight = weightCalculator.CalculateIdealWieght("female", 165);
            //Assert
            Assert.Equal(54.57, idealWeight);
        }

        [Fact]
        public void HeightIsNumber_GivenANegativeNumberIsEntered_ReturnsFalse()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var isNumber = weightCalculator.HeightIsNumber("-10");
            //Assert
            Assert.False(isNumber);
        }

        [Fact]
        public void HeightIsNumber_GivenAPositiveNumberIsEntered_ReturnsTrue()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var isNumber = weightCalculator.HeightIsNumber("10");
            //Assert
            Assert.True(isNumber);
        }

        [Fact]
        public void HeightIsNumber_GivenACharacterIsEntered_ReturnsFalse()
        {
            //Arrange
            var weightCalculator = new IdealWeightCalculator();
            //Act
            var isNumber = weightCalculator.HeightIsNumber("char");
            //Assert
            Assert.False(isNumber);
        }
    }
}
