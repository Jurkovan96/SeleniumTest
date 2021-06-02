using AltexTestProject.Controls;
using AltexTestProject.PageObjects.Login;
using AltexTestProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.Tests
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
            loginPage = new LoginPage(driver);         
        }

        [TestMethod]
        public void Should_login_successfully_with_valid_credentials()
        {
            var summaryPage = loginPage.login("test1234@test1234.ro", "test1234");
            WaitHelpers.WaitElementToBeVisible(driver, summaryPage.Firstname);
            Assert.AreEqual(summaryPage.lblFirstname.Text, "Salut Test Test");
           
        }

        [TestMethod]
        public void Should_fail_login_with_invalid_email_address()
        {
            var summaryPage = loginPage.login("aaaaaaa", "ceva");
            WaitHelpers.WaitElementToBeVisible(driver, loginPage.InvalidEmail);
            Assert.AreEqual(loginPage.LblInvalidEmail.Text, "Adresa de email invalida");

        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }


}
