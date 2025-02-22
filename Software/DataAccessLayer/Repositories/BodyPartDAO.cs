using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BodyPartDAO : Repository<BodyPart>
    {
        public BodyPartDAO() : base(new DatabaseModel())
        {

        }
        public override int Update(BodyPart entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<BodyPart> GetAll()
        {
            var query = from b in Entities
                        select b;
            return query;
        }

    }
}