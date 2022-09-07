using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Tests
{
    class AlertTests : BaseTest
    {
        [Test]
        public static void AcceptFirstAlert()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickFirstAlertButton()
                .AcceptFirstAlert();
        }

        [Test]
        public static void DismissSecondAlert()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickSecondAlertButton()
                .CancelSecondAlert()
                .ValidateSecondAlertDismiss();
        }

        [Test]
        public static void TestThirdAlertText()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickThirdAlertButton()
                .SendKeysToThirdAlert("Test")
                .ValidateThirdAlertText("Test");
        }
    }
}
