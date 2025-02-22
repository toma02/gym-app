using BusinessLogicLayer;
using BusinessLogicLayer.utils;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class UserRepository_Tests
    {
        [Fact]
        public void CheckIfUsernameTaken_GivenNotExistingUsernameProvided_ReturnsFalse()
        {
            // Arrange
            string username = "NoviUser123";

            // Act
            bool result = UserRepository.CheckIfUsernameTaken(username);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckIfUsernameTaken_GivenExistingUsernameProvided_ReturnsTrue()
        {
            // Arrange
            string existingUsername = "tester123";

            // Act
            bool result = UserRepository.CheckIfUsernameTaken(existingUsername);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckIfEmailTaken_GivenNewEmailProvided_ReturnsFalse()
        {
            // Arrange
            string email = "nekinoviEmail@gmail.com";

            // Act
            bool result = UserRepository.CheckIfEmailTaken(email);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckIfEmailTaken_GivenExistingEmailProvided_ReturnsTrue()
        {
            // Arrange
            string existingEmail = "tester@gmail.com";

            // Act
            bool result = UserRepository.CheckIfEmailTaken(existingEmail);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckCredentials_GivenValidCredentialsProvided_ReturnsTrue()
        {
            // Arrange
            string username = "tester123";
            string password = "tester123";
            string hashedPassword = Hash.HashPassword(password);

            // Act
            bool result = UserRepository.CheckCredentials(username, hashedPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckCredentials_GivenInvalidCredentialsProvided_ReturnsFalse()
        {
            // Arrange
            string username = "NekiUsername";
            string password = "KriviPassword";
            string hashedPassword = Hash.HashPassword(password);

            // Act
            bool result = UserRepository.CheckCredentials(username, hashedPassword);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CreateUser_CreatesANewUser()
        {
            // Arrange
            string firstname = "Pero";
            string lastname = "Peric";
            string username = "perislavperic321";
            string email = "pperic234@gmail.com";
            string password = "lozinka123";
            string hashedPassword = Hash.HashPassword(password);

            // Act
            int result = UserRepository.CreateUser(firstname, lastname, username, email, hashedPassword);

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void GetUser_GivenValidUsernameProvided_ReturnsAppropriateUserObject()
        {
            // Arrange
            string username = "tester123";

            // Act
            User result = UserRepository.GetUser(username);

            // Assert

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.Equal(username, result.username);
            });
        }

        [Fact]
        public void GetUser_GivenNotExistingUsernameProvided_ReturnsNull()
        {
            // Arrange
            string username = "nepostojeceKorime";

            // Act
            User result = UserRepository.GetUser(username);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void CurrentUserOperations()
        {
            // Arrange
            string testUsername = "testuser";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Username.txt");

            // Act
            UserRepository.SaveCurrentUser(testUsername);
            string currentUser = UserRepository.GetCurrentUser();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(currentUser);
                Assert.Equal(testUsername, currentUser);
            });

            File.Delete(filePath);
        }
    }
}
