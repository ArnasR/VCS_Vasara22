using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class DemoQaTextBoxPage : BasePage
    {
        private const string PageAddress = "https://demoqa.com/text-box";

        private IWebElement _fullNameInputField => Driver.FindElement(By.Id("userName"));
        private IWebElement _submitButton => Driver.FindElement(By.CssSelector("#submit"));
        private IWebElement _fullNameResult => Driver.FindElement(By.Id("name"));
        private IWebElement _emailInputField => Driver.FindElement(By.XPath("//*[@id='userEmail']"));
        private IWebElement _emailResult => Driver.FindElement(By.Id("email"));

        public DemoQaTextBoxPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }
        }

        public void InsertFullNameText(string fullName)
        {
            _fullNameInputField.Clear();
            _fullNameInputField.SendKeys(fullName);
        }

        public void ClickSubmitButton()
        {
            ScrollDown();
            _submitButton.Click();
        }

        public void VerifyFullName(string expectedResult)
        {
            Assert.AreEqual($"Name:{expectedResult}", _fullNameResult.Text, "FullName is wrong!");
        }

        public void InsertEmailText(string email)
        {
            _emailInputField.Clear();
            _emailInputField.SendKeys(email);
        }

        public void VerifyEmail(string expectedResult)
        {
            Assert.AreEqual($"Email:{expectedResult}", _emailResult.Text, "Email is wrong!");
        }

        public void EnterFullNameAndEmail(string fullName, string email)
        {
            InsertFullNameText(fullName);
            InsertEmailText(email);
        }
    }
}
