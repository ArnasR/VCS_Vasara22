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

        public SenukaiPage AcceptAllCookies()
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%27PXyoyHsd8h2rWSbfWRSYw1Hw0FWHWxeMFkmENfnuWJ+qQHyMpDTDaw==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cver:1%2Cutc:1662566380304%2Cregion:%27lt%27}",
                "www.senukai.lt",
                "/",
                DateTime.Now.AddDays(1));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();

            return this;
        }

        public SenukaiPage AcceptCutomCookies(bool necessary, bool preferences, bool statistics, bool marketing, int days)
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%27PXyoyHsd8h2rWSbfWRSYw1Hw0FWHWxeMFkmENfnuWJ+qQHyMpDTDaw==%27%2C" +
                "necessary:"+ necessary.ToString() + "%2C" +
                "preferences:"+ preferences.ToString() + "%2C" +
                "statistics:"+ statistics.ToString() + "%2C" +
                "marketing:"+ marketing.ToString() + "%2Cver:1%2Cutc:1662566380304%2Cregion:%27lt%27}",
                "www.senukai.lt",
                "/",
                DateTime.Now.AddDays(days));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();

            return this;
        }
    }
}
