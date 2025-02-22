using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BMICalculator
    {
        public float CalculateBMI(float height, float weight)
        {
            float heightM = height / 100;
            float bmi = weight / (heightM * heightM);
            return (float)Math.Round(bmi, 1);
        }

        public string GetInfo(float bmi)
        {
            if (bmi < 18.5)
                return "You are underweight!";
            else if (bmi >= 18.5 && bmi < 24.9)
                return "You are healthy weight!";
            else if (bmi >= 25 && bmi < 29.9)
                return "You are overweight!";
            else
                return "You are obese!";
        }
    }
}
