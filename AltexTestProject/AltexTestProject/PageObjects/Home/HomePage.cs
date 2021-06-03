using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

    }
}
