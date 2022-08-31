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
    class DemoQaTextBoxTests
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://demoqa.com/text-box";
        }


        [Test]
        public static void TestFullNameInput()
        {
            DemoQaTextBoxPage demoQaTextBoxPage = new DemoQaTextBoxPage(_driver);

            string text = "Arnas";

            demoQaTextBoxPage.InsertFullNameText(text);
            demoQaTextBoxPage.ClickSubmitButton();
            demoQaTextBoxPage.VerifyFullName(text);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }
    }
}
