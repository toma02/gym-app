using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EquipmentRepository
    {
        public static IEnumerable<Equipment> GetEquipment()
        {
            var equipmentDAO = new EquipmentDAO();
            return equipmentDAO.GetAll();
        }

        public List<Equipment> GetEquipment2()
        {
            var equipmentDAO = new EquipmentDAO();
            var getAll = equipmentDAO.GetAll();
            var equipment = getAll.ToList();
            return equipment;
        }
    }
}