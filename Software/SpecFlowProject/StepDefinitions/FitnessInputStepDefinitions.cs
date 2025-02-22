using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Support;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class FitnessInputStepDefinitions
    {
        [Given(@"I am on the fitness input form")]
        public void GivenIAmOnTheFitnessInputForm()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var registerSteps = new RegisterStepDefinitions();
            registerSteps.GivenIAmOnTheRegistrationForm();
            registerSteps.WhenIEnterARandomFirstname();
            registerSteps.WhenIEnterARandomSecondName();
            registerSteps.WhenIEnterARandomUsername();
            registerSteps.WhenIEnterARandomEmail();
            registerSteps.WhenIEnterARandomPassword();
            registerSteps.WhenIClickTheRegisterButton();
        }


        [When(@"I enter my gender")]
        public void WhenIEnterMyGender()
        {
            var driver = GuiDriver.GetDriver();
            var cboGender = driver.FindElementByAccessibilityId("cboGender");
            cboGender.Click();
            cboGender.SendKeys(Keys.Down);
            cboGender.SendKeys(Keys.Enter);
        }

        [When(@"I enter my age")]
        public void WhenIEnterMyAge()
        {
            var driver = GuiDriver.GetDriver();
            var txtAge = driver.FindElementByAccessibilityId("txtAge");
            txtAge.SendKeys("21");
        }


        [When(@"I enter my weight")]
        public void WhenIEnterMyWeight()
        {
            var driver = GuiDriver.GetDriver();
            var txtWeight = driver.FindElementByAccessibilityId("txtWeight");
            txtWeight.SendKeys("80");
        }

        [When(@"I enter my height")]
        public void WhenIEnterMyHeight()
        {
            var driver = GuiDriver.GetDriver();
            var txtHeight = driver.FindElementByAccessibilityId("txtHeight");
            txtHeight.SendKeys("180");
        }

        [When(@"I select my daily activity rate")]
        public void WhenISelectMyDailyActivityRate()
        {
            var driver = GuiDriver.GetDriver();
            var cboActivity = driver.FindElementByAccessibilityId("cboActivity");
            cboActivity.Click();
            cboActivity.SendKeys(Keys.Down);
            cboActivity.SendKeys(Keys.Enter);
        }

        [When(@"I click save button")]
        public void WhenIClickSaveButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var saveBtn = driver.FindElementByAccessibilityId("saveButton");
            saveBtn.Click();
        }


        [Then(@"An error message should appear under the gender combobox")]
        public void ThenAnErrorMessageShouldAppearUnderTheGenderCombobox()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var genderError = driver.FindElementByAccessibilityId("errorGender");
            Assert.IsTrue(genderError.Text == "Potrebno je odabrati spol!");
        }

        [Then(@"an error message should appear under the age input field")]
        public void ThenAnErrorMessageShouldAppearUnderTheAgeInputField()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var ageError = driver.FindElementByAccessibilityId("errorAge");
            Assert.IsTrue(ageError.Text.ToString() == "Dob mora biti broj");
        }

        [AfterScenario]
        public void CloseApplication()
        {
            GuiDriver.Dispose();
        }
    }
}
