using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class GroceryRepository
    {
        public static Grocery AddGrocery(string name, int calories)
        {
            var grocery = new Grocery
            {
                name = name,
                calories = calories
            };

            var groceryDAO = new GroceriesDAO();
            return groceryDAO.AddGrocery(grocery);

        }
        public static IEnumerable<Grocery> GetAll()
        {
            var groceryDAO = new GroceriesDAO();
            return groceryDAO.GetAll();
        }

        public static List<Grocery> GetGrocery(int id)
        {
            var groceryDAO = new GroceriesDAO();
            return groceryDAO.GetGrocery(id).ToList();
        }

        public static bool CheckGroceryDuplicates(string name)
        {
            var groceries = GroceryRepository.GetAll();

            foreach (var grocery in groceries)
            {
                if(string.Equals(grocery.name, name, StringComparison.OrdinalIgnoreCase)) return false;
            }

            return true;
        }
    }
}
