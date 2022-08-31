using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class CalculatorPage
    {
        private static IWebDriver _driver;

        private IWebElement _firstInputField => _driver.FindElement(By.Id("number1Field"));
        private IWebElement _secondInputField => _driver.FindElement(By.Id("number2Field"));
        private IWebElement _integerCheckBox => _driver.FindElement(By.Id("integerSelect"));
        private IWebElement _submitButton => _driver.FindElement(By.Id("calculateButton"));
        private IWebElement _result => _driver.FindElement(By.Id("numberAnswerField"));

        public CalculatorPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void EnterFirstNumber(string firstNumber)
        {
            _firstInputField.Clear();
            _firstInputField.SendKeys(firstNumber);
        }

        public void EnterSecondNumber(string secondNumber)
        {
            _secondInputField.Clear();
            _secondInputField.SendKeys(secondNumber);
        }

        public void IsIntegerRequired(bool isIntegerRequired)
        {
            if (isIntegerRequired != _integerCheckBox.Selected)
            {
                _integerCheckBox.Click();
            }
        }

        public void ClickSubmitButton()
        {
            _submitButton.Click();
        }

        public void ValidateResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _result.GetAttribute("value").ToString(), "Answer is wrong");
        }
    }
}
