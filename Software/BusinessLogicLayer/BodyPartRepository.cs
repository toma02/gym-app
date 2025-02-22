using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BodyPartRepository
    {
        public List<BodyPart> GetBodyParts()
        {
            BodyPartDAO bodyPartDAO = new BodyPartDAO();
            return bodyPartDAO.GetAll().ToList();
        }
        public static IEnumerable<BodyPart> GetBodyPart()
        {
            var bodyPartDAO = new BodyPartDAO();
            return bodyPartDAO.GetAll();
        }
    }
}
