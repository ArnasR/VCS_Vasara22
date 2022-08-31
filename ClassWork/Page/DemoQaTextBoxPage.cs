using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class DemoQaTextBoxPage
    {
       private static IWebDriver _driver;

        private IWebElement _fullNameInputField => _driver.FindElement(By.Id("userName"));
        private IWebElement _submitButton => _driver.FindElement(By.CssSelector("#submit"));
        private IWebElement _fullNameResult => _driver.FindElement(By.Id("name"));
        private IWebElement _emailInputField => _driver.FindElement(By.XPath("//*[@id='userEmail']"));
        private IWebElement _emailResult => _driver.FindElement(By.Id("email"));

        public DemoQaTextBoxPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void InsertFullNameText(string fullName)
        {
            _fullNameInputField.Clear();
            _fullNameInputField.SendKeys(fullName);
        }

        public void ClickSubmitButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
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
