using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class SebCalculatorPage : BasePage
    {
        //1500
        //Klaipeda
        // > 100000 eur
        private const string PageAddress = "https://www.seb.lt/privatiems/kreditai/busto-kreditas#paragraph7764";

        private IWebElement _incomeInput => Driver.FindElement(By.Id("income"));
        private SelectElement _city => new SelectElement(Driver.FindElement(By.Id("city")));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calculate"));
        private IWebElement _resultText => Driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 > div.row > div > div:nth-child(5) > div > strong"));

        public SebCalculatorPage(IWebDriver webDriver) : base(webDriver) { }

        public SebCalculatorPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public SebCalculatorPage InsertIncome(string income)
        {
            _incomeInput.Clear();
            _incomeInput.SendKeys(income);

            return this;
        }

        public SebCalculatorPage SelectCityByValue(string value)
        {
            _city.SelectByValue(value);

            return this;
        }

        public SebCalculatorPage ClickCalculateButton()
        {
            _calculateButton.Click();

            return this;
        }

        public SebCalculatorPage CheckIfICanGetLoan(int wantedLoad)
        {
            //118 658
            string possibleLoanValue = _resultText.Text.Trim().Replace(" ", "");
            Assert.IsTrue(wantedLoad < GetParsedValue(possibleLoanValue), "No, you can not get loan!");
            
            return this;
        }

        private int GetParsedValue(string value)
        {
            int parsedValue = 0;
            if (!"".Equals(value) && value != null)
            {
                parsedValue = Int32.Parse(value);
            }

            return parsedValue;
        }
    }
}
