using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EquipmentDAO : Repository<Equipment>
    {
        public EquipmentDAO() : base(new DatabaseModel())
        {

        }
        public override int Update(Equipment entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Equipment> GetAll()
        {
            var query = from e in Entities
                        select e;
            return query;
        }

    }
}