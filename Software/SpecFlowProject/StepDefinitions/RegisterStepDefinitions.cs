using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowProject.Support;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class RegisterStepDefinitions
    {
        [Given(@"I am on the registration form")]
        public void GivenIAmOnTheRegistrationForm()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var registerButton = driver.FindElementByAccessibilityId("registerButton");
            registerButton.Click();
        }

        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var registerButton = driver.FindElementByAccessibilityId("registerButton");
            registerButton.Click();
        }


        [When(@"I enter a random firstname")]
        public void WhenIEnterARandomFirstname()
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtFirstName");
            var randomUsername = Utils.GenerateRandomString(6);
            txtUsername.SendKeys(randomUsername);
        }

        [When(@"I enter a random second name")]
        public void WhenIEnterARandomSecondName()
        {
            var driver = GuiDriver.GetDriver();
            var txtLastName = driver.FindElementByAccessibilityId("txtLastName");
            var randomString = Utils.GenerateRandomString(6);
            txtLastName.SendKeys(randomString);
        }

        [When(@"I enter a random username")]
        public void WhenIEnterARandomUsername()
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var randomUsername = Utils.GenerateRandomString(6);
            txtUsername.SendKeys(randomUsername);
        }

        [When(@"I enter a random email")]
        public void WhenIEnterARandomEmail()
        {
            var driver = GuiDriver.GetDriver();
            var txtEmail = driver.FindElementByAccessibilityId("txtEmail");
            var randomEmail = Utils.GenerateRandomString(6) + "@gmail.com";
            txtEmail.SendKeys(randomEmail);
        }

        [When(@"I enter a random password")]
        public void WhenIEnterARandomPassword()
        {
            var driver = GuiDriver.GetDriver();
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            var randomString = Utils.GenerateRandomString(6);
            txtPassword.SendKeys(randomString);
        }

        [Then(@"I should be transferred to the fitness input form")]
        public void ThenIShouldBeTransferredToTheFitnessInputForm()
        {
            var driver = GuiDriver.GetDriver();
            // If txtAge element exists. THat means fitness input form is open
            var fitnessInputOpened = driver.FindElementByAccessibilityId("txtAge") != null;
            Assert.IsTrue(fitnessInputOpened);
        }

        [Then(@"I should see Username already in use error message")]
        public void ThenIShouldSeeUsernameAlreadyInUseErrorMessage()
        {
            var driver = GuiDriver.GetDriver();
            var errorUsername = driver.FindElementByAccessibilityId("errorUsername");
            Assert.IsTrue(errorUsername.Text == "Username already in use!");
        }



        [Then(@"I should see ""([^""]*)"" error message under input field")]
        public void ThenIShouldSeeErrorMessageUnderInputField(string p0)
        {
            var driver = GuiDriver.GetDriver();
            var errorPassword = driver.FindElementByAccessibilityId("errorPassword");
            Assert.IsTrue(errorPassword.Text == p0);
        }
    }
}
