using System;
using AltexTestProject.PageObjects.Login;
using AltexTestProject.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AltexTestProject.Controls
{
    public class MenuItemControl
    {
        public IWebDriver driver;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
        }

        private By home = By.CssSelector("");
        public IWebElement BtnHome => driver.FindElement(home);
    }

    public class LoggedOutMenuItemControl : MenuItemControl
    {
        public LoggedOutMenuItemControl(IWebDriver browser) : base(browser)
        {
        }

        private By ContulMeu = By.CssSelector("a[href=\"https://altex.ro/cont/\"]");
        public IWebElement BtnContulMeu => driver.FindElement(ContulMeu);

        public LoginModal OpenLoginModal()
        {
            WaitHelpers.WaitElementToBeVisible(driver, ContulMeu);
            BtnContulMeu.Click();
            return new LoginModal(driver);
        }
    }

    public class LoggedInMenuItemControl : MenuItemControl
    {
        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        { 
        }

        public By Products = By.CssSelector("a[href*=produse]");
        public IWebElement BtnProducts => driver.FindElement(Products);

        public By Firstname = By.CssSelector("a span[class*=jsx]");
        public IWebElement LblFirstname => driver.FindElement(Firstname);

    }
}