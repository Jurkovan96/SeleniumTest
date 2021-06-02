using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AltexTestProject.Controls;
using AltexTestProject.PageObjects.Login;
using AltexTestProject.PageObjects.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AltexTestProject.Tests
{
    [TestClass]
   public class ProductsTest
    { 
            private IWebDriver driver;
            private LoginPage loginPage;
            private LoggedInMenuItemControl menu;

        public object WaitHelper { get; private set; }

        [TestInitialize]
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://altex.ro/cont/intra/");
                loginPage = new LoginPage(driver);
                menu = new LoggedInMenuItemControl(driver);
                
            }

            [TestMethod]
            public void Should_view_products()
            {
                var summaryPage = loginPage.login("test1234@test1234.ro", "test1234");
                Thread.Sleep(4000);
                menu.BtnProducts.Click();
                var productPage = new ProductsPage(driver);
                Thread.Sleep(4000);
                //productPage.BtnTelephone.Click();
                Thread.Sleep(4000);
                productPage.NavigateToAccessories();
                Thread.Sleep(4000);

        }

            [TestCleanup]
            public void CleanUp()
            {
                driver.Quit();
            }
        }
    
}
