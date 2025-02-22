using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowProject.Support;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class AutoTrainingPlanGenerationStepDefinitions
    {
        [Given(@"I am on the AutoPlanGenerationForm")]
        public void GivenIAmOnTheAutoPlanGenerationForm()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var loginSteps = new LoginStepDefinitions();
            loginSteps.GivenIAmOnTheLoginForm();
            loginSteps.WhenIEnterAUsername("testerr");
            loginSteps.WhenIEnterAPassword("testtest");
            loginSteps.WhenIClickTheLoginButton();
            FocusFrontWindow();

            var btnGoToAutoGeneration = driver.FindElementByAccessibilityId("btnAutoGeneratePlan");
            btnGoToAutoGeneration.Click();
            FocusFrontWindow();
        }

        [When(@"I enter a ""([^""]*)"" plan name")]
        public void WhenIEnterAPlanName(string myGeneratedPlan)
        {
            var driver = GuiDriver.GetDriver();
            var txtPlanName = driver.FindElementByAccessibilityId("txtPlanName");
            txtPlanName.SendKeys(myGeneratedPlan);
        }


        [When(@"I select my goal")]
        public void WhenISelectMyGoal()
        {
            var driver = GuiDriver.GetDriver();
            var cboPlanType = driver.FindElementByAccessibilityId("cboPlanType");
            cboPlanType.Click();
            cboPlanType.SendKeys(Keys.Down);
            cboPlanType.SendKeys(Keys.Enter);
        }

        [When(@"I select plan length")]
        public void WhenISelectPlanLength()
        {
            var driver = GuiDriver.GetDriver();
            var cboPlanLength = driver.FindElementByAccessibilityId("cboPlanLength");
            cboPlanLength.Click();
            cboPlanLength.SendKeys(Keys.Down);
            cboPlanLength.SendKeys(Keys.Enter);
        }

        [When(@"I select training frequency")]
        public void WhenISelectTrainingFrequency()
        {
            var driver = GuiDriver.GetDriver();
            var cboTrainingsPerWeek = driver.FindElementByAccessibilityId("cboTrainingsPerWeek");
            cboTrainingsPerWeek.Click();
            cboTrainingsPerWeek.SendKeys(Keys.Down);
            cboTrainingsPerWeek.SendKeys(Keys.Enter);
        }

        [When(@"I select training volume")]
        public void WhenISelectTrainingVolume()
        {
            var driver = GuiDriver.GetDriver();
            var cboPlanVolume = driver.FindElementByAccessibilityId("cboPlanVolume");
            cboPlanVolume.Click();
            cboPlanVolume.SendKeys(Keys.Down);
            cboPlanVolume.SendKeys(Keys.Enter);
        }

        [When(@"I select wanted training days")]
        public void WhenISelectWantedTrainingDays()
        {
            var driver = GuiDriver.GetDriver();
            var listTrainingDays = driver.FindElementByAccessibilityId("listTrainingDays");
            listTrainingDays.Click();
            listTrainingDays.SendKeys(Keys.Down);
            listTrainingDays.SendKeys(Keys.Space);
        }

        [When(@"I click generate button")]
        public void WhenIClickGenerateButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnGenerate = driver.FindElementByAccessibilityId("btnGenerate");
            btnGenerate.Click();
        }

        [Then(@"A training plan should appear in my downloads folder")]
        public void ThenATrainingPlanShouldAppearInMyDownloadsFolder()
        {
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string filePath = downloadsFolder + "\\MyGeneratedPlan.docx";
            Thread.Sleep(6000);
            bool fileExists = File.Exists(filePath);
            Assert.IsTrue(fileExists, "MyGeneratedPlan.docx was not found in the downloads folder");
        }

        [Then(@"error ""([^""]*)"" will be under plan input field")]
        public void ThenErrorWillBeUnderPlanInputField(string p0)
        {
            var driver = GuiDriver.GetDriver();
            var errorPlanName = driver.FindElementByAccessibilityId("errorName");
            Assert.IsTrue(errorPlanName.Text == p0);
        }
        
        public void FocusFrontWindow()
        {
            var driver = GuiDriver.GetDriver();
            var handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[0]);
        }
    }
}
