using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ExercisesDAO : Repository<Exercis>
    {
        public ExercisesDAO() : base(new DatabaseModel())
        {

        }
        public override int Update(Exercis entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Exercis> GetAll()
        {
            var query = from b in Entities
                        select b;
            return query;
        }

        public IQueryable<Exercis> GetExercise(string name)
        {
            var query = from e in Entities
                        where e.name == name
                        select e;
            return query;
        }

        public IQueryable<Exercis> GetExcerciseByID(int excerciseID)
        {
            var query = from b in Entities
                        where b.id == excerciseID
                        select b;
            return query;
        }

        public IQueryable<Exercis> GetAllFiltered(BodyPart bodyPart, Equipment equipment)
        {
            var query = from b in Entities
                        where b.equipment_id == equipment.id && b.bodypart_id == bodyPart.id
                        select b;
            return query;
        }

        public IQueryable<Exercis> GetAllByBodyPart(string bodyPart)
        {
            var bodypartQuery = from b in Context.BodyParts
                             where b.name == bodyPart
                             select b;
            var bodyPartId = bodypartQuery.First().id;

            var query = from b in Context.Exercises
                        where b.bodypart_id == bodyPartId
                        select b;
            return query;
        }

        public int AddExercise(Exercis entity, bool saveChanges = true)
        {
            var exercise = new Exercis
            {
                name = entity.name,
                description = entity.description,
                video_link = entity.video_link,
                difficulty = entity.difficulty,
                bodypart_id = entity.bodypart_id,
                equipment_id = entity.equipment_id,
            };

            Entities.Add(exercise);

            if (saveChanges)
            {
                return SaveChanges();
            }
            else return 0;
        }

    }
}
