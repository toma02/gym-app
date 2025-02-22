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
    public class DayRepository_Tests
    {
        [Fact]
        public void GetAllByUserId_ReturnsAllUserDays()
        {
            //Arrange
            // Act
            var days = DayRepository.GetAllByUserId(1067);

            // Assert
            Assert.IsType<List<Day>>(days.ToList());
        }

        [Fact]
        public void GetAllUserDates_ReturnsAllUserDays()
        {
            //Arrange
            UserRepository.SaveCurrentUser("ivor");
            // Act
            var days = DayRepository.GetAllUserDates();

            // Assert
            Assert.IsType<List<Day>>(days.ToList());
        }

        [Fact]
        public void GetDay_ReturnsSpecificUserDays()
        {
            //Arrange
            UserRepository.SaveCurrentUser("ivor");
            var date = "11/04/2023";
            // Act
            var days = DayRepository.GetDay(date);

            // Assert
            Assert.Equal("11/04/2023", days[0].date);
        }

        [Fact]
        public void UpdateCalories_ReturnsUpdatedCalories()
        {
            //Arrange
            UserRepository.SaveCurrentUser("ivor");
            var date = "11/04/2023";
            var days = DayRepository.GetDay(date);

            // Act
            DayRepository.UpdateCalories(date,"100");

            // Assert
            Assert.Equal(4928, days[0].calories);
            DayHelper.UpdateCalories(date, "-100");
        }

        [Fact]
        public void UpdateBMR_ReturnsUpdatedBMR()
        {
            //Arrange
            UserRepository.SaveCurrentUser("ivor");
            var date = "11/04/2023";
            var days = DayRepository.GetDay(date);

            // Act
            DayRepository.UpdateBMR(date, 1000);

            // Assert
            Assert.Equal(1000, days[0].bmr_calories);
            DayRepository.UpdateBMR(date, 2236);
        }

        [Fact]
        public void AddDay_ReturnsInsertedDay()
        {
            //Arrange
            UserRepository.SaveCurrentUser("ivor");
            var date = "11/06/2023";

            // Act
            var days = DayRepository.AddDay(date,1200);
            
            // Assert
            Assert.Equal("11/06/2023", days.date);
            var dayHelper = new DayHelper();
            dayHelper.DeleteDays(days.id);
        }
    }
}
