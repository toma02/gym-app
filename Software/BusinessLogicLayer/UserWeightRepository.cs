using DataAccessLayer.Repositories;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserWeightRepository
    {
        public List<UserWeight> GetWeightDataByUserId(int UserId)
        {
            var userWeightRepository = new UserWeightDAO();
            return userWeightRepository.GetDataByUserId(UserId).ToList();
        }

        public double WeightProgress(int UserId)
        {
            var weights = GetWeightDataByUserId(UserId);
            if(weights.Count > 1)
            {
                return weights[weights.Count - 1].weight - weights[0].weight; 
            }
            return 0.00;
        }
    }
}
