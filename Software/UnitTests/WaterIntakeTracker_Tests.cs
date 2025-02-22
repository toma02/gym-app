using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class WaterIntakeTracker_Tests
    {
        [Fact]
        public void AddIntake_GivenNull_CurrentIntakeUnchanged()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int currentIntake = tracker.GetCurrentIntake();
            tracker.AddIntake(0);

            // Assert
            Assert.Equal(currentIntake, tracker.GetCurrentIntake());
        }

        [Fact]
        public void AddIntake_GivenNegativeValue_CurrentIntakeUnchanged()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int currentIntake = tracker.GetCurrentIntake();
            tracker.AddIntake(-200);

            // Assert
            Assert.Equal(currentIntake, tracker.GetCurrentIntake());
        }

        [Fact]
        public void AddIntake_GivenPositiveValue_CurrentIntakeChanged()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int currentIntake = tracker.GetCurrentIntake();
            int intake = 250;
            tracker.AddIntake(intake);

            // Assert
            Assert.Equal(currentIntake + intake, tracker.GetCurrentIntake());
        }

        [Fact]
        public void AddIntake_GivenBelowMinValue_CurrentIntakeUnchanged()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int currentIntake = tracker.GetCurrentIntake();
            int intake = 240;
            tracker.AddIntake(intake);

            // Assert
            Assert.Equal(currentIntake, tracker.GetCurrentIntake());
        }

        [Fact]
        public void AddIntake_GivenUnderMaxValue_CurrentIntakeUnchanged()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int currentIntake = tracker.GetCurrentIntake();
            int intake = 1100;
            tracker.AddIntake(intake);

            // Assert
            Assert.Equal(currentIntake, tracker.GetCurrentIntake());
        }

        [Fact]
        public void GetRemainingWaterIntake_WhenGoalIsReached_ReturnsNull()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int intake = 250;
            for (int i = 0; i < 8; i++)
            {
                tracker.AddIntake(intake);
            }
            int remainingIntake = tracker.GetRemainingWaterIntake();

            // Assert
            Assert.Equal(0, remainingIntake);
        }

        [Fact]
        public void GetRemainingWaterIntake_ExceedingGoal_ReturnsNull()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int intake = 250;
            for (int i = 0; i < 10; i++)
            {
                tracker.AddIntake(intake);
            }
            
            int remainingIntake = tracker.GetRemainingWaterIntake();

            // Assert
            Assert.Equal(0, remainingIntake);
        }

        [Fact]
        public void ResetTracker_CurrentIntakeIsNull()
        {
            // Arrange
            int dailyGoal = 2000;
            WaterIntakeTracker tracker = new WaterIntakeTracker(dailyGoal);

            // Act
            int intake = 250;
            for (int i = 0; i < 10; i++)
            {
                tracker.AddIntake(intake);
            }

            tracker.ResetTracker();

            // Assert
            Assert.Equal(0, tracker.GetCurrentIntake());
        }
    }
}
