using System;
using System.Threading;
using AltexTestProject.PageObjects.Home;
using AltexTestProject.PageObjects.Login;
using AltexTestProject.PageObjects.Products;
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

        private By HomePage = By.CssSelector("a[title='Electronice si electrocasnice - 2x Diferenta*']");
        public IWebElement BtnHomePage => driver.FindElement(HomePage);

        public HomePage GoToHomePage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, HomePage);
            Thread.Sleep(8000);//Element is visible but page make a refresh and with this Thread.Sleep wait for refresh. We know it's a bad practice :(
            BtnHomePage.Click();
            return new HomePage(driver);
        }
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

        public ProductsPage OpenProductsPage()
        {
            WaitHelpers.WaitElementToBeClickable(driver, Products);
            Thread.Sleep(8000);//Element is visible but page make a refresh and with this Thread.Sleep wait for refresh. We know it's a bad practice :(
            BtnProducts.Click();
            return new ProductsPage(driver);
        }

        public By Firstname = By.CssSelector("a span[class*=jsx]");
        public IWebElement LblFirstname => driver.FindElement(Firstname);

    }
}