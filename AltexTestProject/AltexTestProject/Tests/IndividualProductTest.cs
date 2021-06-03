using AltexTestProject.PageObjects.Login;
using AltexTestProject.PageObjects.Products;
using AltexTestProject.PageObjects.Products.InputData;
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
    public class IndividualProductTest
    {
        private IWebDriver driver;
        private IndividualProductPage individualProductPage;

        public object WaitHelper { get; private set; }

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
            var loginPage = new LoginPage(driver);
            var summaryPage = loginPage.login("test1234@test1234.ro", "test1234");
            var productsPage = summaryPage.loggedInMenuItemControl.OpenProductsPage();
            productsPage.NavigateToAccessories();
            individualProductPage = productsPage.GoToProductPage();
        }

        [TestMethod]
        public void Should_successfully_add_review_on_product()
        {
            var addReviewBO = new AddReviewBO();
            individualProductPage.sentReview(addReviewBO);

            WaitHelpers.WaitElementToBeVisible(driver, individualProductPage.Result);
            Assert.AreEqual(individualProductPage.LblResult.Text, "Recenzia ta a fost adaugata. Iti multumim pentru contributie.");
        }

        [TestMethod]
        public void Should_fail_add_review_on_product_because_title_have_to_few_characters()
        {
            var addReviewBO = new AddReviewBO()
            {
                Title = "aa"
            };
            individualProductPage.sentReview(addReviewBO);

            WaitHelpers.WaitElementToBeVisible(driver, individualProductPage.EmailFail);
            Assert.AreEqual(individualProductPage.LblEmailFail.Text, "Trebuie sa aiba cel putin 5 caractere");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
