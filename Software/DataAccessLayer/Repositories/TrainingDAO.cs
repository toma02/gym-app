using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Repositories
{
    public class TrainingDAO : Repository<Training>
    {
        public TrainingDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<Training> GetAll()
        {
            var query = from t in Entities
                        select t;
            return query;
        }

        public int CreateTraining(Training entity, bool saveChanges = true)
        {

            var training = new Training
            {
                training_plan_id = entity.training_plan_id,
                day_id = entity.day_id
            };

            Entities.Add(training);

            if (saveChanges)
            {
                return SaveChanges();
            }
            else return 0;
        }

        public override int Update(Training entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public List<Training> BulkAddTrainings(List<Training> listOfTranings, bool saveChanges = true)
        {
            Entities.AddRange(listOfTranings);
            if (saveChanges)
            {
                SaveChanges();
            }
            return listOfTranings;

        }
    }
}
