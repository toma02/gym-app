using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class WaterIntakeTracker
    {
        private int dailyGoal;
        private int currentIntake;

        public WaterIntakeTracker(int goal)
        {
            dailyGoal = goal;
            currentIntake = 0;
        }

        public void AddIntake(int amount)
        {
            if(IsValidIntake(amount))
                currentIntake += amount;
        }

        public Boolean IsValidIntake(int amount)
        {
            return amount >= 250 && amount <= 1000;
        }

        public int GetCurrentIntake()
        {
            return currentIntake;
        }

        public int GetRemainingWaterIntake()
        {
            return (currentIntake<=dailyGoal) ? dailyGoal - currentIntake : 0;
        }

        public void ResetTracker()
        {
            currentIntake = 0;
        }
    }
}
