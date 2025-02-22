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

namespace IntegrationTests
{
    public class TrainingExerciseRepository_Tests : Repository<Training_Exercises>
    {
        public TrainingExerciseRepository_Tests() : base(new DatabaseModel())
        {

        }

        [Fact]
        public void CreateTrainingExercise_CreatesTrainingExerciseAndStoresInDataBase_ReturnsTrue()
        {
            var duration = 12345;
            var sets = 1;
            var reps = 1;
            var exercise = new Exercis { name = "test", 
                description = "",
                difficulty = 1,
                video_link = "",
                BodyPart = new BodyPart { id = 1, name = "Chest" },
                Equipment = new Equipment { id = 1, name = "Machine" }
            };
            var training = new Training {  
                TrainingPlan = new TrainingPlan {
                    name = "test",
                    description = "test",
                    PlanType = new PlanType { id = 1, name = "test" },
                    PlanVolume = new PlanVolume { id = 1}
                }
            };

            var result = Training_ExercisesRepository.CreateTrainingExercise(duration, sets, reps, exercise, training);
            Assert.Equal(1, result);

            DeleteTrainingExercise(duration);
        }

        public override int Update(Training_Exercises entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        private void DeleteTrainingExercise(int dur)
        {
            var exercise = Entities.FirstOrDefault(p => p.duration == dur);
            if (exercise != null)
            {
                Entities.Remove(exercise);
                SaveChanges();
            }
        }
    }
}
