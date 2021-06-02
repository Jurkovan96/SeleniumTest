using AltexTestProject.PageObjects.Summary;
using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Login
{
    public class LoginPage
    {
        public IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By Email = By.CssSelector("div[class*=lg-u-float-right] form input[name=email]");
        private IWebElement TxtEmail => driver.FindElement(Email);

        private By Password = By.CssSelector("div[class*=lg-u-float-right] form input[name=password]");
        private IWebElement TxtPassword => driver.FindElement(Password);

        private By LogIn = By.CssSelector("div[class=\"mb-2 mt-4\"] div[class*=\"flex items-center justify-center\"]");
        private IWebElement BtnLogIn => driver.FindElement(LogIn);

        private By Cookies = By.CssSelector("button[class*=Button--primary]");
        private IWebElement BtnCookies => driver.FindElement(Cookies);

        public By InvalidEmail = By.CssSelector("div[class=\"Form-validate is-active\"] div[class=Form-validate-message]");

        public IWebElement LblInvalidEmail => driver.FindElement(InvalidEmail);

        public SummaryPage login(string email, string password)
        {
            WaitHelpers.WaitElementToBeVisible(driver, Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnCookies.Click();
            BtnLogIn.Click();
            return new SummaryPage(driver);
        }
    }
}
