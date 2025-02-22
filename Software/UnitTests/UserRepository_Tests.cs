using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using DataAccessLayer.Repositories;
using DataAccessLayer;

namespace UnitTests
{
    public class UserRepository_Tests
    {
        [Fact]
        public void CheckIfUsernameTaken_GivenUsernameTaken_ReturnsTrue()
        {
            string username = "testtest";
            var usersDAO = A.Fake<UsersDAO>();
            var userInstance = new User
            {
                username = "testtest",
                email = "nekiemail",
                password = "password",
            };
            var userQuery = usersDAO.GetUser(username);
            A.CallTo(() => userQuery.SingleOrDefault()).Returns(userInstance);


        }


    }
}
