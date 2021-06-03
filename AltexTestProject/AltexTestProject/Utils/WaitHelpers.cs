using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AltexTestProject.Utils
{
    public static class WaitHelpers
    {
        public static void WaitElementToBeVisible(IWebDriver driver, By by, int timeSpan = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitElementToBeClickable(IWebDriver driver, By by, int timeSpan = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}