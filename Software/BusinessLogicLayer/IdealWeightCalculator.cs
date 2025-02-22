using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class IdealWeightCalculator
    {
        public double CalculateIdealWieght(string gender, int height)
        {
            if (gender == "male")
            {
                var idealWeight = 56.2 + (1.41/152.4)*height;
                return Math.Round(idealWeight,2);
            }
            else
            {
                var idealWeight = 53.1 + (1.36 / 152.4) * height;
                return Math.Round(idealWeight, 2);
            }
        }

        public bool HeightIsNumber(string height)
        {
            if (int.TryParse(height, out int number))
            {
                return number > 0;
            }
            return false;
        }
    }
}
