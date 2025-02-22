using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GendersDAO : Repository<Gender>
    {
        public GendersDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<Gender> GetAll()
        {
            var query = from u in Entities
                        select u;
            return query;
        }

        public override int Update(Gender entity, bool saveChanges = true)
        {
            return 0;
        }
    }
}
