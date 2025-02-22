using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class BMICalculator_Tests
    {
        [Fact]
        public void GetInfo_CalculateUnderweight_ReturnsUnderweight()
        {
            var bmiCalc = new BMICalculator();
            var bmi = bmiCalc.CalculateBMI(190, 60);
            var info = bmiCalc.GetInfo(bmi);

            Assert.Equal("You are underweight!", info);
        }

        [Fact]
        public void GetInfo_CalculateHealthyWeight_ReturnsHealthyWeight()
        {
            var bmiCalc = new BMICalculator();
            var bmi = bmiCalc.CalculateBMI(190, 80);
            var info = bmiCalc.GetInfo(bmi);

            Assert.Equal("You are healthy weight!", info);
        }

        [Fact]
        public void GetInfo_CalculateOverweight_ReturnsOverweight()
        {
            var bmiCalc = new BMICalculator();
            var bmi = bmiCalc.CalculateBMI(190, 100);
            var info = bmiCalc.GetInfo(bmi);

            Assert.Equal("You are overweight!", info);
        }

        [Fact]
        public void GetInfo_CalculateObese_ReturnsObese()
        {
            var bmiCalc = new BMICalculator();
            var bmi = bmiCalc.CalculateBMI(190, 120);
            var info = bmiCalc.GetInfo(bmi);

            Assert.Equal("You are obese!", info);
        }
    }
}
