using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltexTestProject.Utils;
using OpenQA.Selenium;

namespace AltexTestProject.PageObjects.Products
{
    public class ProductsPage
    {
        public IWebDriver driver;

        public ProductsPage(IWebDriver browser)
        {
            driver = browser;
        }

        public By Telephone = By.CssSelector("li[class*=ProductsMenu] a[title=\"Telefoane, Tablete\"]");
        public IWebElement BtnTelephone => driver.FindElement(Telephone);

        private By AccessoriesList => By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[2]/ul[1]/li[1]/ul[1]/li[1]/div[1]/div[1]/ul[1]/li[2]/ul[1]/li/a");
        public IList<IWebElement> LstAccessories => driver.FindElements(AccessoriesList);

        public By SelectedCategory = By.XPath("//h1[normalize-space()='Huse telefon']");
        public IWebElement LblSelectedCategory => driver.FindElement(SelectedCategory);

        public void SelectAccessorieFromList()
        {
            foreach (var accessories in LstAccessories)
            {
                if (accessories.Text.Equals("Huse telefon"))
                {
                    accessories.Click();
                    break;
                }
            }
        }

        public void NavigateToAccessories()
        {
            WaitHelpers.WaitElementToBeClickable(driver, Telephone);
            BtnTelephone.Click();
            WaitHelpers.WaitElementToBeVisible(driver, AccessoriesList);
            SelectAccessorieFromList();
        }
    }
}
