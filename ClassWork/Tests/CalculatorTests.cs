using ClassWork.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Tests
{
    class CalculatorTests : BaseTest
    {
        [TestCase("25", "25.5", "50.5", false, TestName = "25 + 25,5 = 50,5")]
        [TestCase("5", "25.5", "30", true, TestName = "5 + 25,5 integersOnly = 30")]
        [TestCase("1.99", "0.959", "2.949", false, TestName = "1,99 + 0,959 = 2,949")]
        [TestCase("-1", "-9.99", "-10", true, TestName = "-1 + -9,99 + Integers only = -10")]
        public static void TestCalculator(string number1, string number2, string expectedResult, bool isIntegerEnabled)
        {
            _calculatorPage.NavigateToDefaultPage();
            _calculatorPage.EnterFirstNumber(number1);
            _calculatorPage.EnterSecondNumber(number2);
            _calculatorPage.IsIntegerRequired(isIntegerEnabled);
            _calculatorPage.ClickSubmitButton();
            _calculatorPage.ValidateResult(expectedResult);
        }
    }
}
