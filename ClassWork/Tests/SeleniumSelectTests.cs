﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Tests
{
    class SeleniumSelectTests : BaseTest
    {
        [Test]
        public void TestSingleDropDown()
        {
            _seleniumSelectPage.NavigateToDefaultPage()
                .SelectDropDownByValue("Friday")
                .VerifyDropDownResult("Friday");
        }

        [TestCase("Florida", "Texas", TestName = "Pasirenkam 2 reiksmes ir patikrinam pirma")]
        [TestCase("Ohio", "California", "Washington", TestName = "Pasirenkam 3 reiksmes ir patikrinam pirma")]
        public void TestMultipleDropDownAndValidateFirst(params string[] selectedElements)
        {
            _seleniumSelectPage.NavigateToDefaultPage()
                .SelectFromMultipleDropDownAndClickFirstSelectedButton(selectedElements.ToList())
                .ClickGetFirstSelectedButton()
                .VerifyGetFirstSelectedResult(selectedElements[0]);
        }
    }
}
