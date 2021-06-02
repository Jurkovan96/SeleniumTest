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
            var summaryPage = loginPage.login("apostolvlad98@gmail.com", "engleza90.");
            WaitHelpers.WaitElementToBeVisible(driver, summaryPage.Firstname);
            Assert.AreEqual(summaryPage.lblFirstname.Text, "Salut Example Example");
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }


}
