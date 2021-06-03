using AltexTestProject.PageObjects.Address;
using AltexTestProject.PageObjects.Address.InputData;
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
    public class NewAddressTests
    {
        private IWebDriver driver;
        private NewAddressPage newAddressPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
            var loginPage = new LoginPage(driver);
            var summary = loginPage.login("test1234@test1234.ro", "test1234");
            var addressPage = summary.GoToAddressPage();
            newAddressPage = addressPage.GoToNewAddressPage();
        }

        [TestMethod]
        public void Should_fail_not_selected_region_and_city()
        {
            var newAddressBO = new NewAddressBO();
            newAddressPage.SaveAddressFail(newAddressBO);
            WaitHelpers.WaitElementToBeVisible(driver, newAddressPage.InvalidRegion);
            Assert.AreEqual(newAddressPage.LblInvalidRegion.Text, "Alege un judet");
            WaitHelpers.WaitElementToBeVisible(driver, newAddressPage.InvalidCity);
            Assert.AreEqual(newAddressPage.LblInvalidCity.Text, "Alege un oras");
        }


        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
