using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowProject.Support;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Given(@"I am on the login form")]
        public void GivenIAmOnTheLoginForm()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnLogin = driver.FindElementByAccessibilityId("loginButton");
            btnLogin.Click();
        }

        [When(@"I click Login button")]
        public void WhenIClickTheLoginButton()
        {
            var driver = GuiDriver.GetDriver();

            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");
            btnLogin.Click();
        }

        [Then(@"I should see ""([^""]*)"" error message")]
        public void ThenIShouldSeeErrorMessage(string p0)
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Credentials can't be empty");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [When(@"I enter a username ""([^""]*)""")]
        public void WhenIEnterAUsername(string someUsername)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            txtUsername.SendKeys(someUsername);
        }

        [When(@"I enter a password ""([^""]*)""")]
        public void WhenIEnterAPassword(string p0)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtPassword");
            txtUsername.SendKeys(p0);
        }

        [Then(@"I should see ""([^""]*)"" message")]
        public void ThenIShouldSeeMessage(string p0)
        {
            var driver = GuiDriver.GetDriver();
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == p0);
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [When(@"I enter my username ""([^""]*)""")]
        public void WhenIEnterMyUsername(string testerr)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            txtUsername.SendKeys(testerr);
        }

        [When(@"I enter corresponding password ""([^""]*)""")]
        public void WhenIEnterCorrespondingPassword(string testerr)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtPassword");
            txtUsername.SendKeys(testerr);
        }

        [Then(@"I should be transferred to the main application window")]
        public void ThenIShouldBeTransferredToTheMainApplicationWindow()
        {
            var driver = GuiDriver.GetDriver();
            var handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[0]);
            var isMainPageOpen = driver.FindElementByName("FoiFitness") != null;
            Assert.IsTrue(isMainPageOpen);
        }

      
    }
}
