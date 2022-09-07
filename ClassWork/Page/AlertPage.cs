﻿using OpenQA.Selenium;
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

        private IWebElement _firstAlertButton => Driver.FindElement(By.Id("alertButton"));

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

        public AlertPage AcceptFirstAlert()
        {
            Driver.SwitchTo().Alert().Accept();

            return this;
        }
    }
}