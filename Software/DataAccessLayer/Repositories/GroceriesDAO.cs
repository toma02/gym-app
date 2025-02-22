using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GroceriesDAO : Repository<Grocery>
    {
        public GroceriesDAO() : base(new DatabaseModel())
        {
        }

        public override IQueryable<Grocery> GetAll()
        {
            var query = from g in Entities
                        select g;
            return query;
        }

        public IQueryable<Grocery> GetGrocery(int id)
        {
            var query = from g in Entities
                        where g.id == id 
                        select g;
            return query;
        }

        public Grocery AddGrocery(Grocery entity, bool saveChanges = true)
        {

            var grocery = new Grocery
            {
                name = entity.name,
                calories = entity.calories
            };

            Entities.Add(grocery);

            if (saveChanges)
            {
                SaveChanges();
                return grocery;
            }
            else return null;
        }

        public override int Update(Grocery entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
