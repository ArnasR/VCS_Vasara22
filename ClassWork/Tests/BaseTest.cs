using ClassWork.Drivers;
using ClassWork.Page;
using ClassWork.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Tests
{
    class BaseTest
    {
        protected static IWebDriver Driver;

        public static CalculatorPage _calculatorPage;
        public static DemoQaTextBoxPage _demoQaTextBoxPage;
        public static SeleniumSelectPage _seleniumSelectPage;

        [OneTimeSetUp]
        public static void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();

            _calculatorPage = new CalculatorPage(Driver);
            _demoQaTextBoxPage = new DemoQaTextBoxPage(Driver);
            _seleniumSelectPage = new SeleniumSelectPage(Driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(Driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
           Driver.Close();
        }
    }
}
