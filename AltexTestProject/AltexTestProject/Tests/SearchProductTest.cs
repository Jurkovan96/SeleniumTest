using AltexTestProject.PageObjects.Home;
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
    public class SearchProductTest
    {
        private IWebDriver driver;
        private HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
            var loginPage = new LoginPage(driver);
            var summaryPage = loginPage.login("test1234@test1234.ro", "test1234");
            homePage = summaryPage.menuItemControl.GoToHomePage();
        }

        [TestMethod]
        public void Should_Go_To_Product_Result_Page()
        {
            homePage.searchValue();
            WaitHelpers.WaitElementToBeVisible(driver, homePage.SearchResult);
            Assert.AreEqual(homePage.LblSearchResult.Text, "Rezultate cautare : telefon");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
