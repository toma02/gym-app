using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowProject.Support;
using System;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class DisplayingProgressGraphicallyStepDefinitions
    {
        [Given(@"I go to the chart generator page")]
        public void GivenIGoToTheChartGeneratorPage()
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var btnShowProgress = driver.FindElementByAccessibilityId("btnShowProgress");
            btnShowProgress.Click();

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [Given(@"I choosed start and end date for the weight progress chart")]
        public void GivenIChoosedStartAndEndDateForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var dpStartDateWeight = driver.FindElementByAccessibilityId("dpStartDateWeight");
            var dpEndDateWeight = driver.FindElementByAccessibilityId("dpEndDateWeight");

            dpStartDateWeight.Clear();
            dpEndDateWeight.Clear();

            dpStartDateWeight.SendKeys("1.3.2023.");
            dpEndDateWeight.SendKeys("30.3.2023.");
        }

        [Then(@"I should see generated weight progress chart")]
        public void ThenIShouldSeeGeneratedWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var weightChartExists = driver.FindElementByClassName("CartesianChart") != null;

            Assert.IsTrue(weightChartExists);
        }

        [Given(@"I choosed end date for the weight progress chart")]
        public void GivenIChoosedEndDateForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var dpEndDateWeight = driver.FindElementByAccessibilityId("dpEndDateWeight");
            dpEndDateWeight.Clear();
            dpEndDateWeight.SendKeys("30.3.2023.");
        }

        [Given(@"I choosed start date for the weight progress chart")]
        public void GivenIChoosedStartDateForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var dpStartDateWeight = driver.FindElementByAccessibilityId("dpStartDateWeight");
            dpStartDateWeight.Clear();
            dpStartDateWeight.SendKeys("1.3.2023.");
        }

        [When(@"I click on the Display Chart button for the weight progress chart")]
        public void WhenIClickOnTheDisplayChartButtonForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var btnShowUserWeight = driver.FindElementByAccessibilityId("btnShowUserWeight");
            btnShowUserWeight.Click();
        }

        [Then(@"I should see message that prompts me to select a start date for the weight progress chart")]
        public void ThenIShouldSeeMessageThatPromptsMeToSelectAStartDateForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to enter Start date!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationMessageUserWeight").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Then(@"I should see message that prompts me to select a end date for the weight progress chart")]
        public void ThenIShouldSeeMessageThatPromptsMeToSelectAEndDateForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to enter End date!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationMessageUserWeight").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Then(@"I should see message that prompts me to select whole time range for the weight progress chart")]
        public void ThenIShouldSeeMessageThatPromptsMeToSelectWholeTimeRangeForTheWeightProgressChart()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to enter Start and End date!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationMessageUserWeight").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Given(@"I choosed start and end date for the calories intake chart")]
        public void GivenIChoosedStartAndEndDateForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var dpStartDateCalories = driver.FindElementByAccessibilityId("dpStartDateCalories");
            var dpEndDateCalories = driver.FindElementByAccessibilityId("dpEndDateCalories");

            dpStartDateCalories.Clear();
            dpEndDateCalories.Clear();

            dpStartDateCalories.SendKeys("1.3.2023.");
            dpEndDateCalories.SendKeys("30.3.2023.");
        }

        [When(@"I click on the Display Chart button for the calories intake chart")]
        public void WhenIClickOnTheDisplayChartButtonForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var btnShowCaloricIntake = driver.FindElementByAccessibilityId("btnShowCaloricIntake");
            btnShowCaloricIntake.Click();

        }

        [Then(@"I should see generated calories intake chart")]
        public void ThenIShouldSeeGeneratedCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var caloricIntakeChartExists = driver.FindElementByClassName("CartesianChart") != null;

            Assert.IsTrue(caloricIntakeChartExists);
        }

        [Given(@"I choosed end date for the calories intake chart")]
        public void GivenIChoosedEndDateForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var dpEndDateCalories = driver.FindElementByAccessibilityId("dpEndDateCalories");
            dpEndDateCalories.Clear();
            dpEndDateCalories.SendKeys("30.3.2023.");
        }

        [Then(@"I should see message that prompts me to select a start date for the calories intake chart")]
        public void ThenIShouldSeeMessageThatPromptsMeToSelectAStartDateForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to enter Start date!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationMessageCaloricIntake").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);

        }

        [Given(@"I choosed start date for the calories intake chart")]
        public void GivenIChoosedStartDateForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var dpStartDateCalories = driver.FindElementByAccessibilityId("dpStartDateCalories");
            dpStartDateCalories.Clear();
            dpStartDateCalories.SendKeys("1.3.2023.");
        }

        [Then(@"I should see message that prompts me to select a end date for the calories intake chart")]
        public void ThenIShouldSeeMessageThatPromptsMeToSelectAEndDateForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to enter End date!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationMessageCaloricIntake").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Then(@"I should see message that prompts me to select whole time range for the calories intake chart")]
        public void ThenIShouldSeeMessageThatPromptsMeToSelectWholeTimeRangeForTheCaloriesIntakeChart()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to enter Start and End date!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationMessageCaloricIntake").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

    }
}
