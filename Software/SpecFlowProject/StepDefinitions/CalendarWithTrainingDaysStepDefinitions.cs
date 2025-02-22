using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Support;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class CalendarWithTrainingDaysStepDefinitions
    {
        [Given(@"I am logged in as registered user ivor")]
        public void GivenIAmLoggedInAsRegisteredUserIvor()
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var btnLoginChoice = driver.FindElementByAccessibilityId("loginButton");
            btnLoginChoice.Click();

            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            txtUsername.SendKeys("ivor");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            txtPassword.SendKeys("ivor12");
            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");

            btnLogin.Click();

        }

        [Given(@"I am on the main page with said user ivor")]
        public void GivenIAmOnTheMainPageWithSaidUserIvor()
        {
            var driver = GuiDriver.GetDriver();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool isOpened = driver.FindElementByName("FoiFitness") != null;
            Assert.IsTrue(isOpened);

        }

        [Given(@"I have selected wanted date")]
        public void GivenIHaveSelectedWantedDate()
        {
            var driver = GuiDriver.GetDriver();

            var datePicker = driver.FindElementByAccessibilityId("dpChoosingDate");
            datePicker.Clear();
            datePicker.SendKeys("11.04.2023");
        }

        [Given(@"I have pressed choose date button")]
        public void GivenIHavePressedChooseDateButton()
        {

            var driver = GuiDriver.GetDriver();

            var chooseDateButton = driver.FindElementByAccessibilityId("btnChooseDate");
            chooseDateButton.Click();
        }


        [When(@"I click on modify calories button")]
        public void WhenIClickOnModifyCaloriesButton()
        {
            var driver = GuiDriver.GetDriver();

            var modifyCaloriesButton = driver.FindElementByAccessibilityId("btnModifyCalories");
            modifyCaloriesButton.Click();
        }

        [Then(@"form for calory modification opens")]
        public void ThenFormForCaloryModificationOpens()
        {
            var driver = GuiDriver.GetDriver();

            var handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[0]);
            var formTitle = driver.FindElementByName("Calories").Text;
            Assert.AreEqual("Calories", formTitle);
        }
    }
}
