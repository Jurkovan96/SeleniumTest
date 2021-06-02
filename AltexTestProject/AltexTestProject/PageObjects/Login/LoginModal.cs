using AltexTestProject.PageObjects.Home;
using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Login
{
    public class LoginModal
    {
        public IWebDriver driver;

        public LoginModal(IWebDriver browser)
        {
            driver = browser;
        }

        private By Email = By.CssSelector("div[class=Session-loggedOut] input[name=email]");
        private IWebElement TxtEmail => driver.FindElement(Email);
        
        private By Password = By.CssSelector("input[name=password]");
        private IWebElement TxtPassword => driver.FindElement(Password);
        
        private By LogIn = By.XPath("/html/body/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[1]/div/div[2]/div/form/div[3]/span/button/div/div/div");
        private IWebElement BtnLogIn => driver.FindElement(LogIn);


        public void Login(string email, string password)
        {
            WaitHelpers.WaitElementToBeVisible(driver, Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            WaitHelpers.WaitElementToBeVisible(driver, LogIn);
            BtnLogIn.Click();
        }
    }
}
