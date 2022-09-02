using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement _getFirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _multiDropDownResult => Driver.FindElement(By.CssSelector(".getall-selected"));

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

        public SeleniumSelectPage SelectFromMultipleDropDownAndClickFirstSelectedButton(string first, string second)
        {
            //Florida
            //Texas
            _multiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);

            foreach (IWebElement option in _multiDropDown.Options)
            {
                if (option.Text.Equals("Florida") || option.Text.Equals("Texas"))
                {
                    action.Click(option);
                }
            }

            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();    

            return this;
        }

        public SeleniumSelectPage ClickGetFirstSelectedButton()
        {
            _getFirstSelectedButton.Click();

            return this;
        }

        public SeleniumSelectPage VerifyGetFirstSelectedResult(string result)
        {
            Assert.AreEqual($"First selected option is : {result}", _multiDropDownResult.Text, "Result is wrong!");

            return this;
        }
    }
}
