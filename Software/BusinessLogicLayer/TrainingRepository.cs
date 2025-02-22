using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TrainingRepository
    {
        public static IEnumerable<Training> GetAllTrainings()
        {
            var trainingDAO = new TrainingDAO();
            return trainingDAO.GetAll();
        }

        public static int CreateTraining(TrainingPlan trainingPlan, Day day)
        {
            var training = new Training
            {
                training_plan_id = trainingPlan.id,
                day_id = day.id
            };

            var trainingDAO = new TrainingDAO();
            return trainingDAO.CreateTraining(training);
        }

        public static List<Training> BulkAddTrainingsForPlan(int planId, List<Day> listOfDays)
        {
            List<Training> listOfTranings = new List<Training>();
            listOfDays.ForEach(day =>
            {
                listOfTranings.Add(new Training
                {
                    training_plan_id = planId,
                    day_id = day.id
                });
            });

            var trainingDAO = new TrainingDAO();
            return trainingDAO.BulkAddTrainings(listOfTranings);
        }
    }
}
