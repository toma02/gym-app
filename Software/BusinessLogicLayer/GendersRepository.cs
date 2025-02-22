using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class GendersRepository
    {
        public List<Gender> GetGenders()
        {
            using (var repo = new GendersDAO())
            {
                List<Gender> genders = repo.GetAll().ToList();
                return genders;
            }
        }
    }
}
