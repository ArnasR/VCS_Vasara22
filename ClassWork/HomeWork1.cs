using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork
{
    class HomeWork1
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://testpages.herokuapp.com/styled/calculator";
        }

        /*
        25 + 25.5 = 50.5
        5 + 25,5 + Integers only = 30
        1.99 + 0.959 = 2.949
        -1 + -9.99 + Integers only = -10
        */


        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "ERR", TestName = "a + b = ERR")]
        public static void TestCalculator(string number1, string number2, string expectedResult)
        {
            IWebElement firstNumberInputField = _driver.FindElement(By.Id("number1"));
            firstNumberInputField.Clear();
            firstNumberInputField.SendKeys(number1);

            IWebElement secondNumberInputField = _driver.FindElement(By.Id("number2"));
            secondNumberInputField.Clear();
            secondNumberInputField.SendKeys(number2);

            IWebElement submitButton = _driver.FindElement(By.Id("calculate"));
            submitButton.Click();

            IWebElement result = _driver.FindElement(By.Id("answer"));
            Assert.AreEqual(expectedResult, result.Text, "Answer is wrong");
            Assert.That(result.Text.Equals(expectedResult), "Answer is wrong");
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }
    }
}
