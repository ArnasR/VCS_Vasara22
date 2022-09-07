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
                .AcceptCookies();
        }

    }
}
