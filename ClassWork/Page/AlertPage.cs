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
        private const string ThirdAlertResult = "You entered ";

        private IWebElement _firstAlertButton => Driver.FindElement(By.Id("alertButton"));
        private IWebElement _secondAlertButton => Driver.FindElement(By.Id("confirmButton"));
        private IWebElement _secondAlertResult => Driver.FindElement(By.Id("confirmResult"));
        private IWebElement _thirdAlertButton => Driver.FindElement(By.Id("promtButton"));
        private IWebElement _thirdAlertResult => Driver.FindElement(By.Id("promptResult"));

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

        public AlertPage ClickThirdAlertButton()
        {
            _thirdAlertButton.Click();

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

        public AlertPage SendKeysToThirdAlert(string text)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();

            return this;
        }

        public AlertPage ValidateSecondAlertDismiss()
        {
            Assert.AreEqual(CancelTextResult, _secondAlertResult.Text, "Result is wrong!");

            return this;
        }

        public AlertPage ValidateThirdAlertText(string resultText)
        {
            Assert.IsTrue(($"{ThirdAlertResult}{resultText}").Contains(_thirdAlertResult.Text), "Result is wrong!");

            return this;
        }
    }
}
