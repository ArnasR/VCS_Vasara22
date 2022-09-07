using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Tests
{
    class SenukaiTests : BaseTest
    {
        [Test]
        public static void TestSenukaiCookies()
        {
            _senukaiPage.NavigateToDefaultPage()
                .AcceptAllCookies();
        }

        [TestCase(true, false, false, true, 2, TestName = "Test Cookies Marketing true")]
        [TestCase(false, false, false, false, 5, TestName = "Test all false Cookies")]
        public static void TestSenukaiCustomCookies(bool necessary, bool preferences, bool statistics, bool marketing, int days)
        {
            _senukaiPage.NavigateToDefaultPage()
                .AcceptCutomCookies(necessary, preferences, statistics, marketing, days);
        }

    }
}
