using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BMRCalculator
    {
        public double CalculateBMR()
        {
            double BMR;
            var userDao = new UsersDAO();
            var username = UserRepository.GetCurrentUser();
            List<User> user = userDao.GetUser(username).ToList();
            foreach (var userItem in user)
            {
                if (!InputValidator.HasNeededBMRData(userItem))
                    return 0;
                if (userItem.gender_id == 1)
                {
                    BMR = (double)(5 + (10 * userItem.weight) +(6.25 * userItem.height) - (5 * userItem.age));
                }
                else
                {
                    BMR = (double)(161 - (10 * userItem.weight) +(6.25 * userItem.height) - (5 * userItem.age));
                }
                return BMR;
            }
            return 0;
        }

        public void AddCaloriesToDate(string dateString, int groceryId, int grams)
        {
            var grocery = GroceryRepository.GetGrocery(groceryId)[0];
            int groceryCalories = (grocery.calories * grams) / 100;
            DayRepository.UpdateCalories(dateString, groceryCalories.ToString());
        }
    }
}
