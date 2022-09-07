using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork.Page
{
    class SenukaiPage : BasePage
    {
        private const string PageAddress = "https://www.senukai.lt/";

        public SenukaiPage(IWebDriver webDriver) : base(webDriver) { }

        public SenukaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public SenukaiPage AcceptCookies()
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%27PXyoyHsd8h2rWSbfWRSYw1Hw0FWHWxeMFkmENfnuWJ+qQHyMpDTDaw==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:true%2Cver:1%2Cutc:1662566380304%2Cregion:%27lt%27}",
                "www.senukai.lt",
                "/",
                DateTime.Now.AddDays(1));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();

            return this;
        }
    }
}
