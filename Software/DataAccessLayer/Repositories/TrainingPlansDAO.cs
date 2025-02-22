using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class TrainingPlansDAO : Repository<TrainingPlan>
    {
        public TrainingPlansDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<TrainingPlan> GetAll()
        {
            var query = from t in Entities
                        select t;
            return query;
        }

        public IQueryable<TrainingPlan> GetPlan(int id)
        {
            var query = from p in Entities
                        where p.id == id
                        select p;
            return query;
        }

        public override int Update(TrainingPlan entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public TrainingPlan CreateTrainingPlan(TrainingPlan entity, bool saveChanges = true)
        {
            
            var plan = new TrainingPlan
            {
                name = entity.name,
                description = entity.description,
                duration = entity.duration,
                plan_volume_id = entity.plan_volume_id,
                plan_type_id = entity.plan_type_id
            };

            Entities.Add(plan);

            if (saveChanges)
            {
                SaveChanges();
                
            }
            return plan;
        }
    }
}
