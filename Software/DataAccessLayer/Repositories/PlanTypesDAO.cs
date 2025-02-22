using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PlanTypesDAO : Repository<PlanType>
    {
        public PlanTypesDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<PlanType> GetAll()
        {
            var query = from u in Entities
                        select u;
            return query;
        }

        public override int Update(PlanType entity, bool saveChanges = true)
        {
            return 0;
        }
    }
}
