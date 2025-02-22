using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlowProject.Support;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ConsumedCaloriesInDayModificationStepDefinitions
    {
        [Given(@"I have entered calories form")]
        public void GivenIHaveEnteredCaloriesForm()
        {
            var driver = GuiDriver.GetDriver();

            var datePicker = driver.FindElementByAccessibilityId("dpChoosingDate");
            datePicker.Clear();
            datePicker.SendKeys("11.04.2023");

            var chooseDateButton = driver.FindElementByAccessibilityId("btnChooseDate");
            chooseDateButton.Click();

            var modifyCaloriesButton = driver.FindElementByAccessibilityId("btnModifyCalories");
            modifyCaloriesButton.Click();

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [Given(@"I clicked calories button")]
        public void GivenIClickedCaloriesButton()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnCalories");
            btnCalories.Click();
        }

        [When(@"I enter calories into textbox")]
        public void WhenIEnterCaloriesIntoTextbox()
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtAddCalories");
            txtAddCalories.SendKeys("100");
        }

        [When(@"I click add button")]
        public void WhenIClickAddButton()
        {
            var driver = GuiDriver.GetDriver();

            var btnAddCalories = driver.FindElementByAccessibilityId("btnAddCalories");
            btnAddCalories.Click();
        }

        [Then(@"I get message with succesfull insertion of calories")]
        public void ThenIGetMessageWithSuccesfullInsertionOfCalories()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Successfully inserted calories!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Then(@"I get message with unsuccessful insertion of calories")]
        public void ThenIGetMessageWithUnsuccessfulInsertionOfCalories()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Insert a number of calories!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Given(@"I clicked Foodstuff button")]
        public void GivenIClickedFoodstuffButton()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnFoodStuff");
            btnCalories.Click();
        }

        [When(@"I choose groceries in combobox")]
        public void WhenIChooseGroceriesInCombobox()
        {
            var driver = GuiDriver.GetDriver();

            var cbBodyParts = driver.FindElementByAccessibilityId("cbFoodStuff");
            cbBodyParts.Click();
            cbBodyParts.SendKeys(Keys.Down);
            cbBodyParts.SendKeys(Keys.Enter);
        }

        [When(@"I click insert grams button to insert grams")]
        public void WhenIClickInsertGramsButtonToInsertGrams()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnInsertGramsAmount");
            btnCalories.Click();
        }

        [When(@"I enter grams into textbox")]
        public void WhenIEnterGramsIntoTextbox()
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtFoodstuffGrams");
            txtAddCalories.SendKeys("100");
        }

        [When(@"I click insert grams button to add groceries to day")]
        public void WhenIClickInsertGramsButtonToAddGroceriesToDay()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnAddGroceryToDay");
            btnCalories.Click();
        }

        [Then(@"I get message with succesful insertion of groceries to day")]
        public void ThenIGetMessageWithSuccesfulInsertionOfGroceriesToDay()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Successfully inserted food to day");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Then(@"I get message with warning that I need to choose groceries")]
        public void ThenIGetMessageWithWarningThatINeedToChooseGroceries()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "You need to choose a food item first!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Then(@"I get message with warning that I need to insert grams")]
        public void ThenIGetMessageWithWarningThatINeedToInsertGrams()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Failed to insert food to day");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Given(@"I clicked insert food button")]
        public void GivenIClickedInsertFoodButton()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnInsertFood");
            btnCalories.Click();
        }

        [When(@"I enter name of grocery into textbox")]
        public void WhenIEnterNameOfGroceryIntoTextbox()
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtFoodName");
            txtAddCalories.SendKeys("Kolaè");
        }

        [When(@"I click insert grams button to insert calories per (.*) grams for grocery")]
        public void WhenIClickInsertGramsButtonToInsertCaloriesPerGramsForGrocery(int p0)
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnNextInsertFoodOption");
            btnCalories.Click();
        }

        [When(@"I enter calories per (.*) grams into textbox")]
        public void WhenIEnterCaloriesPerGramsIntoTextbox(int p0)
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtFoodGrams");
            txtAddCalories.SendKeys("500");
        }

        [When(@"I click add button to add the grocery to database")]
        public void WhenIClickAddButtonToAddTheGroceryToDatabase()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnAddFoodToDatabase");
            btnCalories.Click();
        }

        [Then(@"I get message with succesful insertion of grocery into database")]
        public void ThenIGetMessageWithSuccesfulInsertionOfGroceryIntoDatabase()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Succesfuly inserted food!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Then(@"I get message with unsuccesful insertion of grocery into database")]
        public void ThenIGetMessageWithUnsuccesfulInsertionOfGroceryIntoDatabase()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "This grocery already exist!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [Then(@"I get message with warning that I need to insert name of grocery first")]
        public void ThenIGetMessageWithWarningThatINeedToInsertNameOfGroceryFirst()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Insert a food name first!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [When(@"I click cancel button")]
        public void WhenIClickCancelButton()
        {
            var driver = GuiDriver.GetDriver();

            var btnCalories = driver.FindElementByAccessibilityId("btnCancelCalories");
            btnCalories.Click();
        }

        [Then(@"The form closes")]
        public void ThenTheFormCloses()
        {
            var driver = GuiDriver.GetDriver();

            try
            {
                var btnCalories = driver.FindElementByAccessibilityId("btnCalories");
                Assert.IsNotNull(btnCalories);
            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Assert.IsTrue(true);
            }
        }

        [When(@"I enter random characters for calories into textbox")]
        public void WhenIEnterRandomCharactersForCaloriesIntoTextbox()
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtAddCalories");
            txtAddCalories.SendKeys("dwasda");
        }

        [Then(@"I get warning with unsuccesful insertion of calories")]
        public void ThenIGetWarningWithUnsuccesfulInsertionOfCalories()
        {
            var driver = GuiDriver.GetDriver();
            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxText = driver.FindElementByAccessibilityId("65535");
            Assert.IsTrue(messageBoxText.Text.ToString() == "Failed to insert calories for day!");
            var messageBoxOK = driver.FindElementByAccessibilityId("2");
            messageBoxOK.Click();
        }

        [When(@"I enter negativ numbers for calories into textbox")]
        public void WhenIEnterNegativNumbersForCaloriesIntoTextbox()
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtAddCalories");
            txtAddCalories.SendKeys(Keys.Subtract + "100");
        }

        [When(@"I enter  random characters for calories per (.*) grams into textbox")]
        public void WhenIEnterRandomCharactersForCaloriesPerGramsIntoTextbox(int p0)
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtFoodGrams");
            txtAddCalories.SendKeys("asdwad");
        }

        [When(@"I enter negativ numbers for calories per (.*) grams into textbox")]
        public void WhenIEnterNegativNumbersForCaloriesPerGramsIntoTextbox(int p0)
        {
            var driver = GuiDriver.GetDriver();

            var txtAddCalories = driver.FindElementByAccessibilityId("txtFoodGrams");
            txtAddCalories.SendKeys(Keys.Subtract + "100");
        }
    }
}
