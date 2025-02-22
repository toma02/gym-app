using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class InputValidator_Tests
    {
        [Fact]
        public void ValidateName_GivenNameIsValid_ReturnsTrue()
        {
            var result = InputValidator.ValidateName("tim");

            Assert.True(result);
        }

        [Fact]
        public void ValidateName_GivenNameContainsSpecialChars_ReturnsFalse()
        {
            var result = InputValidator.ValidateName("t!m_//:");

            Assert.False(result);
        }

        [Fact]
        public void ValidateName_GivenNameIsTooShort_ReturnsFalse()
        {
            var result = InputValidator.ValidateName("t");

            Assert.False(result);
        }

        [Fact]
        public void ValidateName_GivenNoNameProvided_ReturnsFalse()
        {
            var result1 = InputValidator.ValidateName("");
            var result2 = InputValidator.ValidateName(null);

            Assert.False(result1 && result2);
        }

        [Fact]
        public void ValidateName_GivenNameIsTooLong_ReturnsFalse()
        {
            var tooLongName = "Apolloniosdionysiospericlesherakleidesalexandrossss";
            var result = InputValidator.ValidateName(tooLongName);

            Assert.False(result);
        }

        [Fact]
        public void ValidateUsername_GivenValidUsernameProvided_ReturnsTrue()
        {
            var result1 = InputValidator.ValidateUsername("tester123");
            var result2 = InputValidator.ValidateUsername("timjuic");

            Assert.True(result1 && result2);
        }

        [Fact]
        public void ValidateUsername_GivenUsernameTooLong_ReturnsFalse()
        {
            var result1 = InputValidator.ValidateUsername("testingtesting12345678");

            Assert.False(result1);
        }

        [Fact]
        public void ValidateUsername_GivenUsernameTooShort_ReturnsFalse()
        {
            var result1 = InputValidator.ValidateUsername("a");

            Assert.False(result1);
        }

        [Fact]
        public void ValidateUsername_GivenUsernameContainsSpecialChars_ReturnsFalse()
        {
            var result1 = InputValidator.ValidateUsername("wrongU$ername%");

            Assert.False(result1);
        }

        [Fact]
        public void ValidateEmail_GivenEmailIsValid_ReturnsTrue()
        {
            var result1 = InputValidator.ValidateEmail("tester@gmail.com");
            var result2 = InputValidator.ValidateEmail("nekiEmail123a@gmail.com");

            Assert.True(result1 && result2);
        }

        [Fact]
        public void ValidateEmail_GivenEmailDoesntIncludeMonkeySign_ReturnsFalse()
        {
            var result1 = InputValidator.ValidateEmail("testergmail.com");
            var result2 = InputValidator.ValidateEmail("nekiEmail123agmail.com");

            Assert.False(result1 && result2);
        }

        [Fact]
        public void ValidateEmail_GivenEmailDoesntIncludeDomainExtension_ReturnsFalse()
        {
            var result1 = InputValidator.ValidateEmail("testergmail@gmail");
            var result2 = InputValidator.ValidateEmail("nekiEmail123a@gmail");

            Assert.False(result1 && result2);
        }

        [Fact]
        public void ValidatePassword_GivenPasswordIsValid_ReturnsTrue()
        {
            var result1 = InputValidator.ValidatePassword("pas$w0rd123?_");
            var result2 = InputValidator.ValidatePassword("nekaLOzinka aaa");

            Assert.True(result1 && result2);
        }

        [Fact]
        public void ValidatePassword_GivenPasswordTooShort_ReturnsFalse()
        {
            var result1 = InputValidator.ValidatePassword("test");
            var result2 = InputValidator.ValidatePassword("123");

            Assert.False(result1 && result2);
        }

        [Fact]
        public void isValidAge_GivenRealAgeIsProvided_ReturnsTrue()
        {
            var result1 = InputValidator.isValidAge("21");
            var result2 = InputValidator.isValidAge("50");

            Assert.True(result1 && result2);
        }

        [Fact]
        public void isValidAge_GivenImpossiblyLargeValueGiven_ReturnsFalse()
        {
            var result1 = InputValidator.isValidAge("500");

            Assert.False(result1);
        }

        [Fact]
        public void isValidAge_GivenValueNotNumber_ReturnsFalse()
        {
            var result1 = InputValidator.isValidAge("asd1");
            var result2 = InputValidator.isValidAge("nijebroj");

            Assert.False(result1 && result2);
        }

        [Fact]
        public void isValidWeight_GivenRealWeightProvided_ReturnsTrue()
        {
            var result1 = InputValidator.isValidAge("100");

            Assert.True(result1);
        }

        [Fact]
        public void isValidWeight_GivenNotNumberProvided_ReturnsFalse()
        {
            var result1 = InputValidator.isValidAge("asd1");
            var result2 = InputValidator.isValidAge("nijebroj");

            Assert.False(result1 && result2);
        }


        [Fact]
        public void isValidHeight_GivenRealHeightProvided_ReturnsTrue()
        {
            var result1 = InputValidator.isValidAge("100");

            Assert.True(result1);
        }

        [Fact]
        public void isValidHeight_GivenNotNumberProvided_ReturnsFalse()
        {
            var result1 = InputValidator.isValidAge("asd1");
            var result2 = InputValidator.isValidAge("nijebroj");

            Assert.False(result1 && result2);
        }

        [Fact]
        public void HasNeededBMRData_GivenAllDataProvided_ReturnsTrue()
        {
            //Arrange
            var user = new User{ 
            weight=100,
            height=160,
            age=25,
            };
            //Act
            var result = InputValidator.HasNeededBMRData(user);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void HasNeededBMRData_GivenWeightDataNotProvided_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                height = 160,
                age = 25,
            };
            //Act
            var result = InputValidator.HasNeededBMRData(user);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void HasNeededBMRData_GivenHeightDataNotProvided_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                weight = 100,
                age = 25,
            };
            //Act
            var result = InputValidator.HasNeededBMRData(user);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void HasNeededBMRData_GivenAgeDataNotProvided_ReturnsFalse()
        {
            //Arrange
            var user = new User
            {
                weight = 100,
                height = 160,
            };
            //Act
            var result = InputValidator.HasNeededBMRData(user);
            //Assert
            Assert.False(result);
        }
    }
}
