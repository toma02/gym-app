using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class TrainingRepository_Tests
    {


        [Fact]
        public void CreateTraining_ReturnsNewTrainingId()
        {
            // Arrange
            var planName = "Integracijski Test Plan";
            var planDescription = "Neki opis";
            var planDuration = 10;
            var planType = new PlanType { id = 1, name = "Gain Muscle" };
            var planVolume = new PlanVolume { id = 1, amplifier = 1 };
            var trainingPlan = TrainingPlanRepository.CreatePlan(planName, planDescription, planDuration, planType, planVolume);
            var day = DayRepository.GetDay("03/03/2023").FirstOrDefault();

            // Act
            var result = TrainingRepository.CreateTraining(trainingPlan, day);

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void BulkAddTrainingsForPlan_ReturnsListOfTrainings()
        {
            // Arrange
            int planId = 100;
            int userId = 89;
            var trainingDates = GenerateRandomDates();
            var listOfDays = DayRepository.BulkAddDaysForUser(userId, trainingDates);

            // Act
            var result = TrainingRepository.BulkAddTrainingsForPlan(planId, listOfDays);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(listOfDays.Count, result.Count);
        }

        public static List<DateTime> GenerateRandomDates()
        {
            List<DateTime> dates = new List<DateTime>();

            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                // Generate a random DateTime between January 1, 2000, and December 31, 2022
                DateTime randomDate = new DateTime(random.Next(2000, 2023), random.Next(1, 13), random.Next(1, 29));
                dates.Add(randomDate);
            }

            return dates;
        }
    }
}
