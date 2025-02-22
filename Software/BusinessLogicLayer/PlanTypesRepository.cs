using DataAccessLayer.Repositories;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PlanTypesRepository
    {
        public List<PlanType> GetAll()
        {
            using (var repo = new PlanTypesDAO())
            {
                List<PlanType> planTypesList = repo.GetAll().ToList();
                return planTypesList;
            }
        }
    }
}
