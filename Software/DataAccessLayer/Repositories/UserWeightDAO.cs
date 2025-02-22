using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserWeightDAO : Repository<UserWeight>
    {
        public UserWeightDAO() : base(new DatabaseModel())
        {

        }

        public IQueryable<UserWeight> GetDataByUserId(int UserId)
        {
            var query = from t in Entities
                        where t.user_id == UserId
                        orderby t.date ascending
                        select t;
            return query;
        }

        public override IQueryable<UserWeight> GetAll()
        {
            var query = from t in Entities
                        select t;
            return query;
        }

        public override int Update(UserWeight entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
