using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.TestHelpers
{
    public class GroceryHelper : Repository<Grocery>
    {
        public GroceryHelper() : base(new DatabaseModel())
        {
        }

        public void DeleteGrocery(int id)
        {
            var grocery = Entities.FirstOrDefault(p => p.id == id);
            if (grocery != null)
            {
                Entities.Remove(grocery);
                SaveChanges();
            }
        }

        public override int Update(Grocery entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
