using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.TestHelpers
{
    public class Days_GroceriesHelpers : Repository<Days_Groceries>
    {
        public Days_GroceriesHelpers() : base(new DatabaseModel())
        {
        }
        public void DeleteDays_Grocery(int id)
        {
            var dayGrocery = Entities.FirstOrDefault(p => p.grocery_id == id);
            if (dayGrocery != null)
            {
                Entities.Remove(dayGrocery);
                SaveChanges();
            }
        }

        public override int Update(Days_Groceries entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
