using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PlanVolumesDAO : Repository<PlanVolume>
    {
        public PlanVolumesDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<PlanVolume> GetAll()
        {
            var query = from u in Entities
                        select u;
            return query;
        }

        public override int Update(PlanVolume entity, bool saveChanges = true)
        {
            return 0;
        }
    }
}

