using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Summary
{
    public class SummaryPage
    {
        public IWebDriver driver;

        public SummaryPage(IWebDriver browser)
        {
            driver = browser;
        }

        public By Firstname = By.CssSelector("p[class=u-color-black]");
        public IWebElement lblFirstname => driver.FindElement(Firstname);

    }
}
