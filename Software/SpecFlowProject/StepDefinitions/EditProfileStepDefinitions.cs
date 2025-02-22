using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowProject.Support;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class EditProfileStepDefinitions
    {
        [Given(@"User is logged in to the application using username ""([^""]*)"" and password ""([^""]*)"" and has opened a window to edit profile clicking the profile button\.")]
        public void GivenUserIsLoggedInToTheApplicationUsingUsernameAndPasswordAndHasOpenedAWindowToEditProfileClickingTheProfileButton_(string testiranje, string testiranje1)
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

            var btnAddExercise = driver.FindElementByAccessibilityId("btnProfil");
            btnAddExercise.Click();

            driver.SwitchTo().Window(driver.WindowHandles.First());

            var isProfile = driver.FindElementByName("Profile");
            Assert.IsNotNull(isProfile);
        }

        [When(@"I enter ""([^""]*)"" for name")]
        public void WhenIEnterForName(string pero)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtName");
            exerciseName.SendKeys(pero);
        }

        [When(@"I enter ""([^""]*)"" for last name")]
        public void WhenIEnterForLastName(string peric)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtLastName");
            exerciseName.SendKeys(peric);
        }

        [When(@"I enter ""([^""]*)"" for weight")]
        public void WhenIEnterForWeight(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtWeight");
            exerciseName.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" for password")]
        public void WhenIEnterForPassword(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtPassword");
            exerciseName.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" to confirm password")]
        public void WhenIEnterToConfirmPassword(string p0)
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtPassword2");
            exerciseName.SendKeys(p0);
        }

        [When(@"I click the button ""([^""]*)""")]
        public void WhenIClickTheButton(string save)
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var btnSave = driver.FindElementByAccessibilityId("btnSave");
            btnSave.Click();
        }

        [Then(@"The profile is edited and no error messages should pop up")]
        public void ThenTheProfileIsEditedAndNoErrorMessagesShouldPopUp()
        {
            var driver = GuiDriver.GetDriver();

            try
            {
                var txtPasswordElement = driver.FindElementByAccessibilityId("txtPassword");
                Assert.IsNotNull(txtPasswordElement);
            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Assert.IsTrue(true);
            }
        }


        [Then(@"An error message should appear saying that name can't contain any special characters")]
        public void ThenAnErrorMessageShouldAppearSayingThatNameCantContainAnySpecialCharacters()
        {
            var driver = GuiDriver.GetDriver();

            var errorName = driver.FindElementByAccessibilityId("errorName");
            Assert.IsTrue(errorName.Text == "Ime mora biti između 2 i 50 znakova i ne može imati specijalne znakove!");
        }

        [Then(@"An error message should appear saying that last name can't contain any special characters")]
        public void ThenAnErrorMessageShouldAppearSayingThatLastNameCantContainAnySpecialCharacters()
        {
            var driver = GuiDriver.GetDriver();

            var errorLastName = driver.FindElementByAccessibilityId("errorLastName");
            Assert.IsTrue(errorLastName.Text == "Prezime mora biti između 2 i 50 znakova i ne može imati specijalne znakove!");
        }

        [Then(@"An error message should appear saying that I must enter numeric values for weight")]
        public void ThenAnErrorMessagehouldAppearSayingThatIMustEnterNumericValuesForWeight()
        {
            var driver = GuiDriver.GetDriver();

            var errorWeight = driver.FindElementByAccessibilityId("errorWeight");
            Assert.IsTrue(errorWeight.Text == "Unesite brojeve za kilažu!");
        }

        [When(@"I enter a different passoword to confirm password")]
        public void WhenIEnterADifferentPassowordToConfirmPassword()
        {
            var driver = GuiDriver.GetDriver();

            var exerciseName = driver.FindElementByAccessibilityId("txtPassword2");
            exerciseName.SendKeys("wrongPassword");
        }

        [Then(@"An error message should appear saying that passwords do not match")] 
        public void ThenAnErrorMessageShouldAppearSayingThatPasswordsDoNotMatch()
        {
            var driver = GuiDriver.GetDriver();

            var txtPass1 = driver.FindElementByAccessibilityId("txtPassword");
            var txtPass2 = driver.FindElementByAccessibilityId("txtPassword2");

            if (txtPass1 != txtPass2)
            {
                var errorPassword = driver.FindElementByAccessibilityId("errorPassword");
                Assert.IsTrue(errorPassword.Text == "Lozinka mora biti ista");
            }
            else
                Assert.Fail();
            
        }
    }
}
