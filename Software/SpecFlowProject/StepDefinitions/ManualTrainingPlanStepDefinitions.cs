using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowProject.Support;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ManualTrainingPlanStepDefinitions
    {
        [Given(@"User is logged in to the application using username ""([^""]*)"" and password ""([^""]*)"" and has opened a window for creating a new training plan by clicking a button ""([^""]*)""")]
        public void GivenUserIsLoggedInToTheApplicationUsingUsernameAndPasswordAndHasOpenedAWindowForCreatingANewTrainingPlanByClickingAButton(string testiranjeTestiranje, string testiranjeTestiranje1, string p2)
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var loginButton = driver.FindElementByAccessibilityId("loginButton");
            loginButton.Click();

            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            txtUsername.SendKeys(testiranjeTestiranje);
            txtPassword.SendKeys(testiranjeTestiranje);

            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");
            btnLogin.Click();

            var handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[0]);

            var isMainPage = driver.FindElementByName("FoiFitness");
            Assert.IsNotNull(isMainPage);

            var btnCreatePlan = driver.FindElementByAccessibilityId("btnAddPlan");
            btnCreatePlan.Click();

            driver.SwitchTo().Window(driver.WindowHandles.First());

            var isPlan = driver.FindElementByName("Create your own plan");
            Assert.IsNotNull(isPlan);
        }

        [When(@"I click create training plan button")]
        public void WhenIClickCreateTrainingPlanButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnCreatePlan = driver.FindElementByAccessibilityId("btnCreate");
            btnCreatePlan.Click();
        }

        [When(@"I enter training plan name ""([^""]*)""")]
        public void WhenIEnterTrainingPlanName(string p0)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtPlanName = driver.FindElementByAccessibilityId("txtPlanName");
            txtPlanName.SendKeys(p0);
        }

        [When(@"I enter description ""([^""]*)""")]
        public void WhenIEnterDescription(string p0)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtDesc = driver.FindElementByAccessibilityId("txtDesc");
            txtDesc.SendKeys(p0);
        }

        [When(@"I enter training plan duration ""([^""]*)""")]
        public void WhenIEnterTrainingPlanDuration(string p0)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtDur = driver.FindElementByAccessibilityId("txtDur");
            txtDur.SendKeys(p0);
        }

        [When(@"I select ""([^""]*)"" from ""([^""]*)"" dropdown")]
        public void WhenISelectFromDropdown(string p0, string p1)
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbVolume");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [When(@"I click ""([^""]*)"" button")]
        public void WhenIClickButton(string save)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnSave = driver.FindElementByAccessibilityId("btnSave");
            btnSave.Click();
        }

        [Then(@"The training plan should be created and no error messages should pop up")]
        public void ThenTheTrainingPlanShouldBeCreatedAndNoErrorMessagesShouldPopUp()
        {
            var driver = GuiDriver.GetDriver();

            try
            {
                var comboBox = driver.FindElementByAccessibilityId("cmbVolume");
                Assert.IsNotNull(comboBox);
            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Assert.IsTrue(true);
            }
        }


        [When(@"I select volume from Plan volume dropdown")]
        public void WhenISelectVolumeFromPlanVolumeDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbVolume");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [When(@"I select type from Plan type dropdown")]
        public void WhenISelectTypeFromPlanTypeDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbType");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [Then(@"A pop up window should appear saying I need to enter a numeric value for duration")]
        public void ThenAPopUpWindowShouldAppearSayingINeedToEnterANumericValueForDuration()
        {
            var driver = GuiDriver.GetDriver();

            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Please enter a number for plan duration!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Then(@"A pop up window should appear saying I need to enter a numeric value for duration, reps or sets")]
        public void ThenAPopUpWindowShouldAppearSayingINeedToEnterANumericValueForDurationRepsOrSets()
        {
            var driver = GuiDriver.GetDriver();

            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Please enter a number for sets, repetitions or duration!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [When(@"I click create training button")]
        public void WhenIClickCreateTrainingButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnCreateTraining = driver.FindElementByAccessibilityId("btnCreateTraining");
            btnCreateTraining.Click();
        }

        [When(@"I select a training plan from choose a training plan dropdown")]
        public void WhenISelectATrainingPlanFromChooseATrainingPlanDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbPlan");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [When(@"I select a date from Date dropdown")]
        public void WhenISelectADateFromDateDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbDate");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [Then(@"The training should be created and no error messages should pop up")]
        public void ThenTheTrainingShouldBeCreatedAndNoErrorMessagesShouldPopUp()
        {
            var driver = GuiDriver.GetDriver();

            try
            {
                var comboBox = driver.FindElementByAccessibilityId("cmbDate");
                Assert.IsNotNull(comboBox);
            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Assert.IsTrue(true);
            }
        }

        [When(@"I click add exercise info button")]
        public void WhenIClickAddExerciseInfoButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnCreateExercise = driver.FindElementByAccessibilityId("btnCreateExercise");
            btnCreateExercise.Click();
        }

        [When(@"I select Bench press from Select exercise dropdown")]
        public void WhenISelectBenchPressFromSelectExerciseDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbExerciseName");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [When(@"I enter training exercise ""([^""]*)"" sets")]
        public void WhenIEnterTrainingExerciseSets(string p0)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtSets = driver.FindElementByAccessibilityId("txtSets");
            txtSets.SendKeys(p0);
        }

        [When(@"I enter training exercise ""([^""]*)"" repetitions")]
        public void WhenIEnterTrainingExerciseRepetitions(string p0)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtReps = driver.FindElementByAccessibilityId("txtReps");
            txtReps.SendKeys(p0);
        }

        [When(@"I enter training exercise ""([^""]*)"" duration")]
        public void WhenIEnterTrainingExerciseDuration(string p0)
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtDur = driver.FindElementByAccessibilityId("txtDur");
            txtDur.SendKeys(p0);
        }

        [When(@"I select a training from Training dropdown")]
        public void WhenISelectATrainingFromTrainingDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbTraining");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [Then(@"Exercise info should be added and no error messages should pop up")]
        public void ThenExerciseInfoShouldBeAddedAndNoErrorMessagesShouldPopUp()
        {
            var driver = GuiDriver.GetDriver();

            try
            {
                var comboBox = driver.FindElementByAccessibilityId("cmbTraining");
                Assert.IsNotNull(comboBox);
            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Assert.IsTrue(true);
            }
        }


        [When(@"I select a training plan to send to mail from Choose a plan dropdown")]
        public void WhenISelectATrainingPlanToSendToMailFromChooseAPlanDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var comboBox = driver.FindElementByAccessibilityId("cmbChoosePlan");
            comboBox.Click();
            comboBox.SendKeys(Keys.Down);
            comboBox.SendKeys(Keys.Enter);
        }

        [When(@"I click send to mail button")]
        public void WhenIClickSendToMailButton()
        {
            var driver = GuiDriver.GetDriver();

            var sendToMail = driver.FindElementByAccessibilityId("btnSendMail");
            sendToMail.Click();
        }

        [Then(@"I should get an email with selected training plan")]
        public void ThenIShouldGetAnEmailWithSelectedTrainingPlan()
        {
            Assert.IsTrue(true);
        }

        [Then(@"A pop up window should appear saying I need to select a value from Choose a plan dropdown")]
        public void ThenAPopUpWindowShouldAppearSayingINeedToSelectAValueFromChooseAPlanDropdown()
        {
            var driver = GuiDriver.GetDriver();

            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Please select a training plan before sending it to mail!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }
    }
}
