using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataAccessLayer;
using EntityLayer;
using System.Transactions;
using System.Data;
using DataAccessLayer.Repositories;
using IntegrationTests.TestHelpers;

namespace IntegrationTests
{
    public class TrainingPlanRepository_Tests : DataAccessLayer.Repositories.Repository<TrainingPlan>
    {
        public TrainingPlanRepository_Tests() : base(new DatabaseModel())
        {

        }

        [Fact]
        public void GetPlanById_ReturnsMatchingTrainingPlan()
        {
            // Arrange
            var planId = 31;

            // Act
            var result = TrainingPlanRepository.GetPlanById(planId).First();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(planId, result.id);
                Assert.Equal("TEST PLAN", result.name);
            });
        }


        [Fact]
        public void CreatePlan_ReturnsNewTrainingPlan()
        {
            var planName = "Integracijski Test Plan";
            var planDescription = "Neki opis";
            var planDuration = 10;
            var planType = new PlanType { id = 1, name = "Gain Muscle" };
            var planVolume = new PlanVolume { id = 1, amplifier = 1 };

            // Act
            var trainingPlan = TrainingPlanRepository.CreatePlan(planName, planDescription, planDuration, planType, planVolume);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(planName, trainingPlan.name);
                Assert.Equal(planDescription, trainingPlan.description);
                Assert.Equal(planDuration, trainingPlan.duration);
                Assert.Equal(planType.id, trainingPlan.plan_type_id);
                Assert.Equal(planVolume.id, trainingPlan.plan_volume_id);
            });
            var trainingPlanHelper = new TrainingPlanHelper();
            trainingPlanHelper.DeleteTrainingPlan(trainingPlan.id);
        }


        public override int Update(TrainingPlan entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }

        
}
