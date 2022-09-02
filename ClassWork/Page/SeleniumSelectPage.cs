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
    class SeleniumSelectPage : BasePage
    {
        private const string PageAddress = "https://demo.anhtester.com/basic-select-dropdown-demo.html";

        private SelectElement _singleDropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement _resultTextElement => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.selected-value"));

        public SeleniumSelectPage(IWebDriver webDriver) : base(webDriver) { }

        public SeleniumSelectPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public SeleniumSelectPage SelectDropDownByValue(string value)
        {
            _singleDropDown.SelectByValue(value);

            return this;
        }

        public SeleniumSelectPage SelectDropDownByText(string text)
        {
            _singleDropDown.SelectByText(text);

            return this;
        }

        public SeleniumSelectPage VerifyDropDownResult(string result)
        {
            Assert.AreEqual($"Day selected :- {result}", _resultTextElement.Text, "Result is wrong!");

            return this;
        }
    }
}
