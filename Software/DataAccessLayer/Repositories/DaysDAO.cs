using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DaysDAO: Repository<Day>
    {
        public DaysDAO() : base(new DatabaseModel())
        {

        }

        public IQueryable<Day> GetAllByUserId(int userId)
        {
            var query = from d in Entities
                        where d.user_id == userId
                        select d;
            return query;
        }

        public override IQueryable<Day> GetAll()
        {
            var query = from d in Entities
                        select d;
            return query;
        }

        public IQueryable<Day> GetAllUserDates(string username)
        {
            var query = from d in Entities
                        where d.User.username == username
                        select d;
            return query;
        }
        public IQueryable<Day> GetDay(string username, string date)
        {
            var query = from d in Entities
                        where d.User.username == username && d.date == date
                        select d;
            return query;
        }

        public Day AddDay(Day entity, bool saveChanges = true)
        {
            var day = new Day
            {
                date = entity.date,
                bmr_calories = entity.bmr_calories,
                user_id = entity.user_id,
                calories = 0
            };

            Entities.Add(day);

            if (saveChanges)
            {
                SaveChanges();
                return day;
            }
            else return null;
        }

        public List<Day> BulkAddDays(List<Day> listOfDays, bool saveChanges = true)
        {
            Entities.AddRange(listOfDays);

            if (saveChanges)
            {
                Context.SaveChanges();
            }
            return listOfDays;
            
            
        }

        public override int Update(Day entity, bool saveChanges = true)
        {
            var day = Entities.SingleOrDefault(d => d.id == entity.id);

            day.calories = entity.calories;

            if (saveChanges)
                return SaveChanges();
            else
                return 0;
        }

        public int UpdateBMR(Day entity, bool saveChanges = true)
        {
            var day = Entities.SingleOrDefault(d => d.id == entity.id);

            day.bmr_calories = entity.bmr_calories;

            if (saveChanges)
                return SaveChanges();
            else
                return 0;
        }
    }
}
