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
    public class DayHelper : Repository<Day>
    {
        public DayHelper() : base(new DatabaseModel())
        {
        }

        public void DeleteDays(int id)
        {
            var day = Entities.FirstOrDefault(p => p.id == id);
            if (day != null)
            {
                Entities.Remove(day);
                SaveChanges();
            }
        }

        public static void UpdateCalories(string date, string calories)
        {
            var daysDAO = new DaysDAO();
            var day = DayRepository.GetDay(date);

            day[0].calories += int.Parse(calories);
            daysDAO.Update(day[0]);
        }

        public static void UpdateBMR(string date, double bmr)
        {
            var daysDAO = new DaysDAO();
            var day = DayRepository.GetDay(date);

            day[0].bmr_calories = (int)bmr;
            daysDAO.UpdateBMR(day[0]);
        }

        public override int Update(Day entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
