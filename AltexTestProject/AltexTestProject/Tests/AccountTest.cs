using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltexTestProject.PageObjects.Information;
using AltexTestProject.PageObjects.Information.InputData;
using AltexTestProject.PageObjects.Login;
using AltexTestProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AltexTestProject.Tests
{
    [TestClass]
    public class AccountTest
    {
        private IWebDriver driver;
        private InformationPage informationPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
            var loginPage = new LoginPage(driver);
            var summary = loginPage.login("test1234@test1234.ro", "test1234");
            informationPage = summary.GoToEditAccount();
        }

        [TestMethod]
        public void Should__successfully_edit_account_info()
        {
            var informationBO = new InformationBO();
            informationPage.EditInfo(informationBO);
            WaitHelpers.WaitElementToBeVisible(driver, informationPage.SuccessffullyEdit);
            Assert.AreEqual(informationPage.LblSuccessffullyEdit.Text, "Utilizator salvat cu succes");
            informationPage.EditInfoBack(informationBO);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
