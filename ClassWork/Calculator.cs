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
    class Calculator
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://testsheepnz.github.io/BasicCalculator.html#main-body";
        }

        /*
        25 + 25.5 = 50.5
        5 + 25,5 + Integers only = 30
        1.99 + 0.959 = 2.949
        -1 + -9.99 + Integers only = -10
        */


        [TestCase("25", "25.5", "50.5", false, TestName = "25 + 25,5 = 50,5")]
        [TestCase("5", "25.5", "30", true, TestName = "5 + 25,5 integersOnly = 30")]
        [TestCase("1.99", "0.959", "2.949", false, TestName = "1,99 + 0,959 = 2,949")]
        [TestCase("-1", "-9.99", "-10", true, TestName = "-1 + -9,99 + Integers only = -10")]
        public static void TestCalculator(string number1, string number2, string expectedResult, bool isIntegerEnabled)
        {
            IWebElement firstNumberInputField = _driver.FindElement(By.Id("number1Field"));
            firstNumberInputField.Clear();
            firstNumberInputField.SendKeys(number1);

            IWebElement secondNumberInputField = _driver.FindElement(By.Id("number2Field"));
            secondNumberInputField.Clear();
            secondNumberInputField.SendKeys(number2);

            IWebElement integerCheckBox = _driver.FindElement(By.Id("integerSelect"));
            if (isIntegerEnabled != integerCheckBox.Selected)
            {
                integerCheckBox.Click();
            }

            IWebElement submitButton = _driver.FindElement(By.Id("calculateButton"));
            submitButton.Click();

            IWebElement result = _driver.FindElement(By.Id("numberAnswerField"));
            Assert.AreEqual(expectedResult, result.GetAttribute("value").ToString(), "Answer is wrong");
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }

    }
}
