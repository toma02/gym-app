using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Training_ExercisesDAO : Repository<Training_Exercises>
    {
        public Training_ExercisesDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<Training_Exercises> GetAll()
        {
            var query = from e in Entities
                        select e;
            return query;
        }

        public IQueryable<Exercis> GetExcersisesByDate(string username, string date)
        {
            var query = from e in Entities
                        where e.Training.Day.User.username == username && e.Training.Day.date == date
                        select e.Exercis;
            return query;
        }

        public int CreateTrainingExercise(Training_Exercises entity, bool saveChanges = true)
        {

            var training_Exercises = new Training_Exercises
            {
                duration = entity.duration,
                repetition = entity.repetition,
                sets = entity.sets,
                exercise_id = entity.exercise_id,
                training_id = entity.training_id
            };

            Entities.Add(training_Exercises);

            if (saveChanges)
            {
                return SaveChanges();
            }
            else return 0;
        }



        public List<Training_Exercises> BulkAddTrainingExercise(List<Training_Exercises> entities, bool saveChanges = true)
        {
            Entities.AddRange(entities);
            if (saveChanges)
            {
                SaveChanges();
            }

            return entities;
        }

        public override int Update(Training_Exercises entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

    }
}
