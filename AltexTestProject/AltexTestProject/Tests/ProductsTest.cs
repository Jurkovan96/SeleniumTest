using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AltexTestProject.Controls;
using AltexTestProject.PageObjects.Login;
using AltexTestProject.PageObjects.Products;
using AltexTestProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AltexTestProject.Tests
{
    [TestClass]
    public class ProductsTest
    {
        private IWebDriver driver;
        private ProductsPage productsPage;

        public object WaitHelper { get; private set; }

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
            var loginPage = new LoginPage(driver);
            var summaryPage = loginPage.login("test1234@test1234.ro", "test1234");
            productsPage = summaryPage.loggedInMenuItemControl.OpenProductsPage();
        }

        [TestMethod]
        public void Should_navigate_to_selected_accessories()
        {
            productsPage.NavigateToAccessories();
            WaitHelpers.WaitElementToBeVisible(driver, productsPage.SelectedCategory);
            Assert.AreEqual(productsPage.LblSelectedCategory.Text, "Huse telefon");

        }

        [TestMethod]
        public void Should_apply_selected_filtre_to_accessories()
        {
            productsPage.NavigateToAccessories();
            productsPage.FilterAccessories();
            WaitHelpers.WaitElementToBeVisible(driver, productsPage.FilterCategoryResult);
            Assert.AreEqual(productsPage.LblFilterCategoryResult.Text, "General: Promotii");
            WaitHelpers.WaitElementToBeVisible(driver, productsPage.FilterBrandResult);
            Assert.AreEqual(productsPage.LblFilterBrandResult.Text, "Brand: SAMSUNG");
        }

        [TestMethod]
        public void Should_delete_applied_selected_filtre_to_accessories()
        {
            productsPage.NavigateToAccessories();
            productsPage.FilterAccessories();
            WaitHelpers.WaitElementToBeVisible(driver, productsPage.DeleteFilter);
            productsPage.BtnDeleteFilter.Click();

            WaitHelpers.WaitElementToBeVisible(driver, productsPage.SelectedCategory);
            Assert.AreEqual(productsPage.LblSelectedCategory.Text, "Huse telefon");
        }


        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }

}
