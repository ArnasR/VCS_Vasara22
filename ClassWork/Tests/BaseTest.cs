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
    class BaseTest
    {
        protected static IWebDriver Driver;

        public static CalculatorPage _calculatorPage;
        public static DemoQaTextBoxPage _demoQaTextBoxPage;
        public static SeleniumSelectPage _seleniumSelectPage;

        [OneTimeSetUp]
        public static void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();

            _calculatorPage = new CalculatorPage(Driver);
            _demoQaTextBoxPage = new DemoQaTextBoxPage(Driver);
            _seleniumSelectPage = new SeleniumSelectPage(Driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Driver.Close();
        }
    }
}
