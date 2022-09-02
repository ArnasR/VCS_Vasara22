using NUnit.Framework;
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

        [Test]
        public void TestMultipleDropDown()
        {
            _seleniumSelectPage.NavigateToDefaultPage()
                .SelectFromMultipleDropDownAndClickFirstSelectedButton("Florida", "Texas")
                .ClickGetFirstSelectedButton()
                .VerifyGetFirstSelectedResult("Florida");
        }
    }
}
