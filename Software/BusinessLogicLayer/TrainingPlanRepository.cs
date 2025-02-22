using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer
{
    public class TrainingPlanRepository
    {

        public static IEnumerable<TrainingPlan> GetAllPlans()
        {
            var trainingPlansDAO = new TrainingPlansDAO();
            return trainingPlansDAO.GetAll();
        }
        
        public static IEnumerable<TrainingPlan> GetPlanById(int id)
        {
            var trainingPlansDAO = new TrainingPlansDAO();
            return trainingPlansDAO.GetPlan(id);
        }

        public static TrainingPlan CreatePlan(string name, string description, int duration, PlanType planType, PlanVolume planVolume)
        {
            var plan = new TrainingPlan
            {
                name = name,
                description = description,
                duration = duration,
                plan_type_id = planType.id,
                plan_volume_id = planVolume.id
            };

            var trainingPlansDAO = new TrainingPlansDAO();
            return trainingPlansDAO.CreateTrainingPlan(plan);
        }
    }
}
