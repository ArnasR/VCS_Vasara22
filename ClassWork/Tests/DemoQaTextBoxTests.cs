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
        }


        [Test]
        public static void TestFullNameInput()
        {
            DemoQaTextBoxPage demoQaTextBoxPage = new DemoQaTextBoxPage(_driver);

            string text = "Arnas";

            demoQaTextBoxPage.NavigateToDefaultPage();
            demoQaTextBoxPage.InsertFullNameText(text);
            demoQaTextBoxPage.ClickSubmitButton();
            demoQaTextBoxPage.VerifyFullName(text);
        }

        [Test]
        public static void TestFullNameAndEmail()
        {
            DemoQaTextBoxPage demoQaTextBoxPage = new DemoQaTextBoxPage(_driver);

            string name = "Jonas";
            string email = "jonas@jonas.lt";

            demoQaTextBoxPage.NavigateToDefaultPage();
            demoQaTextBoxPage.EnterFullNameAndEmail(name, email);
            demoQaTextBoxPage.ClickSubmitButton();
            demoQaTextBoxPage.VerifyFullName(name);
            demoQaTextBoxPage.VerifyEmail(email);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }
    }
}
