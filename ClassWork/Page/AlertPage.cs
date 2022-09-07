using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class AlertPage : BasePage
    {
        private const string PageAddress = "https://demoqa.com/alerts";
        private const string CancelTextResult = "You selected Cancel";

        private IWebElement _firstAlertButton => Driver.FindElement(By.Id("alertButton"));
        private IWebElement _secondAlertButton => Driver.FindElement(By.Id("confirmButton"));
        private IWebElement _secondAlertResult => Driver.FindElement(By.Id("confirmResult"));

        public AlertPage(IWebDriver webDriver) : base(webDriver) { }

        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public AlertPage ClickFirstAlertButton()
        {
            _firstAlertButton.Click();

            return this;
        }

        public AlertPage ClickSecondAlertButton()
        {
            _secondAlertButton.Click();

            return this;
        }

        public AlertPage AcceptFirstAlert()
        {
            Driver.SwitchTo().Alert().Accept();

            return this;
        }

        public AlertPage CancelSecondAlert()
        {
            Driver.SwitchTo().Alert().Dismiss();

            return this;
        }

        public AlertPage ValidateSecondAlertDismiss()
        {
            Assert.AreEqual(CancelTextResult, _secondAlertResult.Text, "Result is wrong!");

            return this;
        }
    }
}
