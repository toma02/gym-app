using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowProject.Support;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ViewingExistingFitnessExercisesStepDefinitions
    {
        [Given(@"I am logged in as registered user")]
        public void GivenIAmLoggedInAsRegisteredUser()
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var btnLoginOption = driver.FindElementByAccessibilityId("loginButton");
            btnLoginOption.Click();
            
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");

            txtUsername.SendKeys("neki");
            txtPassword.SendKeys("nekitester");
            
            btnLogin.Click();
        }

        [Given(@"I am on the main page")]
        public void GivenIAmOnTheMainPage()
        {
            var driver = GuiDriver.GetDriver();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool isOpened = driver.FindElementByName("FoiFitness") != null;
            Assert.IsTrue(isOpened);
        }

        [Given(@"I have selected the body part ""([^""]*)"" and exercise equipment ""([^""]*)""")]
        public void GivenIHaveSelectedTheBodyPartAndExerciseEquipment(string chest, string machine)
        {
            var driver = GuiDriver.GetDriver();

            var cbBodyParts = driver.FindElementByAccessibilityId("cbBodyParts");
            cbBodyParts.Click();
            cbBodyParts.SendKeys(Keys.Down);
            cbBodyParts.SendKeys(Keys.Enter);

            var cbEquipment = driver.FindElementByAccessibilityId("cbEquipment");
            cbEquipment.Click();
            cbEquipment.SendKeys(Keys.Down);
            cbEquipment.SendKeys(Keys.Enter);
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string search)
        {
            var driver = GuiDriver.GetDriver();

            var btnSearch = driver.FindElementByAccessibilityId("SearchExcercises");
            btnSearch.Click();
        }

        [Then(@"I should see a list of exercises that fit my fitness goals and preferences")]
        public void ThenIShouldSeeAListOfExercisesThatFitMyFitnessGoalsAndPreferences()
        {
            var driver = GuiDriver.GetDriver();

            var listOfExcercises = driver.FindElementByClassName("ShowExcercisesUserControl");
            var excercises = listOfExcercises.FindElementByClassName("Image");

            Assert.IsNotNull(excercises);
        }

        [Given(@"I have selected exercise equipment ""([^""]*)""")]
        public void GivenIHaveSelectedExerciseEquipment(string machine)
        {
            var driver = GuiDriver.GetDriver();

            var cbEquipment = driver.FindElementByAccessibilityId("cbEquipment");
            cbEquipment.Click();
            cbEquipment.SendKeys(Keys.Down);
            cbEquipment.SendKeys(Keys.Enter);
        }

        [Given(@"I have selected a body part ""([^""]*)""")]
        public void GivenIHaveSelectedABodyPart(string chest)
        {
            var driver = GuiDriver.GetDriver();

            var cbBodyParts = driver.FindElementByAccessibilityId("cbBodyParts");
            cbBodyParts.Click();
            cbBodyParts.SendKeys(Keys.Down);
            cbBodyParts.SendKeys(Keys.Enter);
        }

        [When(@"I clear filters")]
        public void WhenIClearFilters()
        {
            var driver = GuiDriver.GetDriver();

            var btnClearFilters = driver.FindElementByAccessibilityId("btnClearFilters");
            btnClearFilters.Click();
        }

        [When(@"I have selected the body part ""([^""]*)"" and exercise equipment ""([^""]*)""")]
        public void WhenIHaveSelectedTheBodyPartAndExerciseEquipment(string glutes, string barbell)
        {
            var driver = GuiDriver.GetDriver();

            var cbBodyParts = driver.FindElementByAccessibilityId("cbBodyParts");
            cbBodyParts.Click();
            for (int i = 0; i < 6; i++)
            {
                cbBodyParts.SendKeys(Keys.Down);
            }
            cbBodyParts.SendKeys(Keys.Enter);

            var cbEquipment = driver.FindElementByAccessibilityId("cbEquipment");
            cbEquipment.Click();
            for (int i = 0; i < 2; i++)
            {
                cbEquipment.SendKeys(Keys.Down);
            }
            cbEquipment.SendKeys(Keys.Enter);

            var btnSearch = driver.FindElementByAccessibilityId("SearchExcercises");
            btnSearch.Click();
        }

        [Then(@"I should see new list of excercises")]
        public void ThenIShouldSeeNewListOfExcercises()
        {
            var driver = GuiDriver.GetDriver();

            var listOfExcercises = driver.FindElementByClassName("ShowExcercisesUserControl");
            var pictureExists = listOfExcercises.FindElementsByClassName("Image") != null;

            Assert.IsTrue(pictureExists);
        }

        [When(@"I click on excercise image")]
        public void WhenIClickOnExcerciseImage()
        {
            var driver = GuiDriver.GetDriver();

            var listOfExcercises = driver.FindElementByClassName("ShowExcercisesUserControl");
            var excercises = listOfExcercises.FindElementsByClassName("Image");
            excercises[0].Click();
        }

        [Then(@"I should see enlarged photo of selected exercise")]
        public void ThenIShouldSeeEnlargedPhotoOfSelectedExercise()
        {
            var driver = GuiDriver.GetDriver();

            driver.SwitchTo().Window(driver.WindowHandles.First());

            var isImageOpened = driver.FindElementByAccessibilityId("ImageFullScreen") != null;
            Assert.IsTrue(isImageOpened);
        }

        [When(@"I click on Select button to show more info")]
        public void WhenIClickOnSelectButtonToShowMoreInfo()
        {
            var driver = GuiDriver.GetDriver();

            var listOfExcercises = driver.FindElementByClassName("ShowExcercisesUserControl");
            var excercises = listOfExcercises.FindElementsByClassName("Button");
            excercises[0].Click();
        }

        [Then(@"I should see more information of selected exercise")]
        public void ThenIShouldSeeMoreInformationOfSelectedExercise()
        {
            var driver = GuiDriver.GetDriver();

            driver.SwitchTo().Window(driver.WindowHandles.First());

            var isExerciseOpen = driver.FindElementByAccessibilityId("tbExcerciseName") != null;
            Assert.IsTrue(isExerciseOpen);
        }

        [Given(@"I have not selected a body part combobox")]
        public void GivenIHaveNotSelectedABodyPartCombobox()
        {
            _ = GuiDriver.GetDriver();
        }

        [Then(@"I should see a message that prompts me to select a body part combobox")]
        public void ThenIShouldSeeAMessageThatPromptsMeToSelectABodyPartCombobox()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to select body part!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationExcerciseFilters").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Given(@"I have not selected an exercise equipment combobox")]
        public void GivenIHaveNotSelectedAnExerciseEquipmentCombobox()
        {
            _ = GuiDriver.GetDriver();
        }

        [Then(@"I should see a message that prompts me to select an exercise equipment combobox")]
        public void ThenIShouldSeeAMessageThatPromptsMeToSelectAnExerciseEquipmentCombobox()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to select equipment!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationExcerciseFilters").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Given(@"I have not selected an exercise equipment and a body part combobox")]
        public void GivenIHaveNotSelectedAnExerciseEquipmentAndABodyPartCombobox()
        {
            _ = GuiDriver.GetDriver();
        }

        [Then(@"I should see a message that prompts me to select an exercise equipment and a body part comboboxes")]
        public void ThenIShouldSeeAMessageThatPromptsMeToSelectAnExerciseEquipmentAndABodyPartComboboxes()
        {
            var driver = GuiDriver.GetDriver();

            var expectedMessage = "You have to select filters!";
            var actualMessage = driver.FindElementByAccessibilityId("lblValidationExcerciseFilters").Text.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Then(@"I should see filters that now have default value")]
        public void ThenIShouldSeeFiltersThatNowHaveDefaultValue()
        {
            var driver = GuiDriver.GetDriver();
            
            var cbBodyParts = driver.FindElementByAccessibilityId("cbBodyParts").Text.ToString() == "All bodyparts";
            var cbEquipment = driver.FindElementByAccessibilityId("cbEquipment").Text.ToString() == "All equipment";

            Assert.IsNotNull(cbBodyParts && cbEquipment);
        }
    }
}
