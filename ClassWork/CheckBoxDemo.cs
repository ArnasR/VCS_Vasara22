using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork
{
    class CheckBoxDemo
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://demo.anhtester.com/basic-checkbox-demo.html";
        }

        [SetUp]
        public static void SetUp()
        {
            IWebElement singleCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            if (singleCheckBox.Selected)
            {
                singleCheckBox.Click();
            }
            
            IReadOnlyCollection<IWebElement> checkBoxes = _driver.FindElements(By.ClassName("cb1-element"));
            foreach (IWebElement checkBox in checkBoxes)
            {
                if (checkBox.Selected)
                {
                    checkBox.Click();
                }
            }
        }

        [Test]
        public static void TestSingleCheckBox()
        {
            IWebElement singleCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            singleCheckBox.Click();

            IWebElement singleCheckBoxResult = _driver.FindElement(By.Id("txtAge"));
            Assert.AreEqual("Success - Check box is checked", singleCheckBoxResult.Text, "Message is wrong!");
        }

        [Test]
        public static void TestUncheckAllButtonText()
        {
            IReadOnlyCollection<IWebElement> checkBoxes = _driver.FindElements(By.ClassName("cb1-element"));
            foreach (IWebElement checkBox in checkBoxes)
            {
                checkBox.Click();
            }

            IWebElement button = _driver.FindElement(By.Id("check1"));

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(button, "Uncheck All"));

            Assert.AreEqual("Uncheck All", button.GetAttribute("value").ToString(), "Value is incorrect");
        }

        [Test]
        public static void TestUnselectAllButton()
        {
            IReadOnlyCollection<IWebElement> checkBoxes = _driver.FindElements(By.ClassName("cb1-element"));
            foreach (IWebElement checkBox in checkBoxes)
            {
                checkBox.Click();
            }

            IWebElement button = _driver.FindElement(By.Id("check1"));
            button.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(button, "Check All"));

            Assert.AreEqual("Check All", button.GetAttribute("value").ToString(), "Value is incorrect");
            foreach (IWebElement checkBox in checkBoxes)
            {
                Assert.IsTrue(!checkBox.Selected, "CheckBox Selected.");
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }
    }
}
