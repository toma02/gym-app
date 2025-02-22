using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class Days_GroceriesRepository
    {
        public static Days_Groceries AddGroceryToDate(string dateString, int grams, int groceryId)
        {
            var date = DayRepository.GetDay(dateString)[0];
            var dateGrocery = new Days_Groceries
            {
                day_id = date.id,
                gram_amount = grams,
                grocery_id = groceryId
            };

            var daysGroceriesDAO = new Days_GroceriesDAO();
            return daysGroceriesDAO.AddGroceryToDate(dateGrocery);
        }
        public static List<Days_Groceries> GetDayGroceries(string date)
        {
            var username = UserRepository.GetCurrentUser();
            var daysGroceriesDAO = new Days_GroceriesDAO();
            return daysGroceriesDAO.GetDayGroceries(username, date).ToList();
        }
    }
}
