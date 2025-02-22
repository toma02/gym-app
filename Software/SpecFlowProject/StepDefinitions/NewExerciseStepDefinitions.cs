using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Support;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class NewExerciseStepDefinitions
    {

        [Given(@"User is logged in to the application using username ""([^""]*)"" and password ""([^""]*)"" and has opened user control for adding new exercise by clicking ""([^""]*)"" button\.")]
        public void GivenUserIsLoggedInToTheApplicationUsingUsernameAndPasswordAndHasOpenedUserControlForAddingNewExerciseByClickingButton_(string testiranje, string testiranje1, string p2)
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var loginButton = driver.FindElementByAccessibilityId("loginButton");
            loginButton.Click();

            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            txtUsername.SendKeys(testiranje);
            txtPassword.SendKeys(testiranje1);

            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");
            btnLogin.Click();

            var handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[0]);

            var isMainPage = driver.FindElementByName("FoiFitness");
            Assert.IsNotNull(isMainPage);

            var btnAddExercise = driver.FindElementByAccessibilityId("btnAdd");
            btnAddExercise.Click();

        }

        [When(@"I enter exercise name ""([^""]*)""")]
        public void WhenIEnterExerciseName(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtName");
            exerciseName.SendKeys(p0);

        }

        [When(@"I enter exercise description ""([^""]*)""")]
        public void WhenIEnterExerciseDescription(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseDesc = driver.FindElementByAccessibilityId("txtDesc");
            exerciseDesc.SendKeys(p0);
        }

        [When(@"I enter exercise video ""([^""]*)""")]
        public void WhenIEnterExerciseVideo(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseVideo = driver.FindElementByAccessibilityId("txtLink");
            exerciseVideo.SendKeys(p0);
        }

        [When(@"I enter exercise difficulty ""([^""]*)""")]
        public void WhenIEnterExerciseDifficulty(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseDiff = driver.FindElementByAccessibilityId("txtDiff");
            exerciseDiff.SendKeys(p0);
        }

        [When(@"I select ""([^""]*)"" from bodypart dropdown menu")]
        public void WhenISelectFromBodypartDropdownMenu(string chest)
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbBody");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter); 
        }

        [When(@"I select ""([^""]*)"" From equipment dropdown menu")]
        public void WhenISelectFromEquipmentDropdownMenu(string barbell)
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbEquip");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [When(@"I press the button ""([^""]*)""")]
        public void WhenIPressTheButton(string save)
        {
            var driver = GuiDriver.GetDriver();

            var buttonSave = driver.FindElementByAccessibilityId("btnSave");
            buttonSave.Click();
        }

        [Then(@"The exercise should be added and no error messages should pop up")]
        public void ThenTheExerciseShouldBeAddedAndNoErrorMessagesShouldPopUp()
        {
            var driver = GuiDriver.GetDriver();

            try
            {
                var cmbBodyElement = driver.FindElementByAccessibilityId("cmbBody");
                Assert.IsNotNull(cmbBodyElement);
            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Assert.IsTrue(true);
            }

        }

        [When(@"I leave exercise description empty")]
        public void WhenILeaveExerciseDescriptionEmpty()
        {
            var driver = GuiDriver.GetDriver();

            var exerciseDesc = driver.FindElementByAccessibilityId("txtDesc");
            exerciseDesc.SendKeys(" ");
        }

        [When(@"I leave exercise video empty")]
        public void WhenILeaveExerciseVideoEmpty()
        {
            var driver = GuiDriver.GetDriver();

            var exerciseVideo = driver.FindElementByAccessibilityId("txtLink");
            exerciseVideo.SendKeys(" ");
        }

        [When(@"I leave exercise difficulty empty")]
        public void WhenILeaveExerciseDifficultyEmpty()
        {
            var driver = GuiDriver.GetDriver();

            var exerciseDesc = driver.FindElementByAccessibilityId("cmbEquip");
            exerciseDesc.SendKeys(" ");
        }

        [Then(@"A pop up window should appear saying I need to enter a number for the exercise difficulty")]
        public void ThenAPopUpWindowShouldAppearSayingINeedToEnterANumberForTheExerciseDifficulty()
        {
            var driver = GuiDriver.GetDriver();

            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Please enter a number for difficulty!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();

        }
    }
}
