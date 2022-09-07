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
    }
}
