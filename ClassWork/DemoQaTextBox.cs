using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork
{
    class DemoQaTextBox
    {
        //1 Test Case -->  Input field
        //2 Test Case -->  2 Input fields

        [Test]
        public static void TestFullNameInputField()
        {
            string name = "Friday";

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("close-fixedban")).Displayed);
            IWebElement baner = driver.FindElement(By.Id("close-fixedban"));
            baner.Click();


            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

            IWebElement fullNameInputField = driver.FindElement(By.Id("userName"));
            fullNameInputField.SendKeys(name);

            IWebElement submitButton = driver.FindElement(By.CssSelector("#submit"));
            submitButton.Click();

            IWebElement result = driver.FindElement(By.Id("name"));
            Assert.AreEqual($"Name:{name}", result.Text, "Name is wrong!");

            driver.Close();
        }

        [Test]
        public static void TestFullNameAndEmailAddress()
        {

            string name = "Friday";

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

            IWebElement fullNameInputField = driver.FindElement(By.Id("userName"));
            fullNameInputField.SendKeys(name);

            IWebElement emailAddress = driver.FindElement(By.XPath("//*[@id='userEmail']"));
            emailAddress.SendKeys("ratkevicius.arnas@gmail.com");

            IWebElement submitButton = driver.FindElement(By.CssSelector("#submit"));
            submitButton.Click();

            IWebElement result = driver.FindElement(By.Id("name"));
            Assert.AreEqual($"Name:{name}", result.Text, "Name is wrong!");

            IWebElement emailResult = driver.FindElement(By.Id("email"));
            Assert.IsTrue(emailResult.Text.Equals("Email:ratkevicius.arnas@gmail.com"), "Email is wrong!");

            driver.Close();
        }

    }
}
