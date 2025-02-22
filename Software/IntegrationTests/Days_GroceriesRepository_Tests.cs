using BusinessLogicLayer;
using DataAccessLayer;
using IntegrationTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class Days_GroceriesRepository_Tests
    {
        [Fact]
        public void GetDayGroceries_ReturnsGroceriesInDay()
        {
            //Arrange
            var date = "10/06/2023";
            UserRepository.SaveCurrentUser("ivor");
            // Act
            var grocery = Days_GroceriesRepository.GetDayGroceries(date);

            // Assert
            Assert.IsType<List<Days_Groceries>>(grocery.ToList());
        }
    }
}
