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
    class DemoQaTextBoxTests : BaseTest
    {
        [Test]
        public static void TestFullNameInput()
        {
            string text = "Arnas";

            _demoQaTextBoxPage.NavigateToDefaultPage()
                .InsertFullNameText(text)
                .ClickSubmitButton()
                .VerifyFullName(text);
        }

        [Test]
        public static void TestFullNameAndEmail()
        {
            string name = "Jonas";
            string email = "jonas@jonas.lt";

            _demoQaTextBoxPage.NavigateToDefaultPage()
            .EnterFullNameAndEmail(name, email)
            .ClickSubmitButton()
            .VerifyFullName(name)
            .VerifyEmail(email);                
        }
    }
}
