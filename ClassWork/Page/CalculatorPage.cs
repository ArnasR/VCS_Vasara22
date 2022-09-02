using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class CalculatorPage : BasePage
    {
        private const string PageAddress = "https://testsheepnz.github.io/BasicCalculator.html#main-body";

        private IWebElement _firstInputField => Driver.FindElement(By.Id("number1Field"));
        private IWebElement _secondInputField => Driver.FindElement(By.Id("number2Field"));
        private IWebElement _integerCheckBox => Driver.FindElement(By.Id("integerSelect"));
        private IWebElement _submitButton => Driver.FindElement(By.Id("calculateButton"));
        private IWebElement _result => Driver.FindElement(By.Id("numberAnswerField"));

        public CalculatorPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
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
