using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{

    public partial class PlanVolume
    {
        public override string ToString()
        {
            string volumeName = "";
            switch (amplifier)
            {
                case 1:
                    volumeName = "1 - Light Volume";
                    break;
                case 2:
                    volumeName = "2 - Moderate Volume";
                    break;
                case 3:
                    volumeName = "3 - High Volume";
                    break;
                default:
                    volumeName = "Select the Plan Volume...";
                    break;
            }
            return volumeName;
        }
    }
}
