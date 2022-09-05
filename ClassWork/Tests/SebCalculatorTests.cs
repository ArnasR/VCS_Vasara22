using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Tests
{
    class SebCalculatorTests : BaseTest
    {
        [Test]
        public static void TestLoanCalculator()
        {
            _sebCalculatorPage.NavigateToDefaultPage()
                .AcceptPopUp()
                .SwitchToFrame()
                .InsertIncome("1500")
                .SelectCityByValue("Klaipeda")
                .ClickCalculateButton()
                .CheckIfICanGetLoan(100000);
        }
    }
}
