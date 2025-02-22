using DataAccessLayer.Repositories;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PlanVolumesRepository
    {
        public List<PlanVolume> GetAll()
        {
            using (var repo = new PlanVolumesDAO())
            {
                List<PlanVolume> planVolumes = repo.GetAll().ToList();
                return planVolumes;
            }
        }
    }
}
