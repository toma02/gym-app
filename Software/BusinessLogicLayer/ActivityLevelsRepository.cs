using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ActivityLevelsRepository
    {
        public List<ActivityLevel> GetActivityLevels()
        {
            using (var repo = new ActivityLevelsDAO())
            {
                List<ActivityLevel> activityLevels = repo.GetAll().ToList();
                return activityLevels;
            }
        }
    }
}
