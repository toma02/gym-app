using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.TestHelpers
{
    public class TrainingPlanHelper : Repository<TrainingPlan>
    {
        public TrainingPlanHelper() : base(new DatabaseModel())
        {

        }

        public TrainingPlan CreateTrainingPlan()
        {
            var planName = "Integracijski Test Plan";
            var planDescription = "Neki opis";
            var planDuration = 10;
            var planType = new PlanType { id = 1, name = "Gain Muscle" };
            var planVolume = new PlanVolume { id = 1, amplifier = 1 };

            // Act
            var trainingPlan = TrainingPlanRepository.CreatePlan(planName, planDescription, planDuration, planType, planVolume);
            return trainingPlan;
        }

        public void DeleteTrainingPlan(int id)
        {
            var trainingPlan = Entities.FirstOrDefault(p => p.id == id);
            if (trainingPlan != null)
            {
                Entities.Remove(trainingPlan);
                SaveChanges();
            }
        }

        public override int Update(TrainingPlan entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
