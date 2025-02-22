using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ActivityLevelsDAO : Repository<ActivityLevel>
    {
        public ActivityLevelsDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<ActivityLevel> GetAll()
        {
            var query = from u in Entities
                        select u;
            return query;
        }

        public override int Update(ActivityLevel entity, bool saveChanges = true)
        {
            return 0;
        }
    }
}
