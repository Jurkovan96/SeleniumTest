using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private By FilterCategoryList => By.XPath("/html/body/div[2]/div[2]/main/div[2]/div[2]/ul/div/li[1]/ul/li/a");
        public IList<IWebElement> LstFilterCategory => driver.FindElements(FilterCategoryList);

        private By FilterBrandList => By.XPath("/html/body/div[2]/div[2]/main/div[2]/div[2]/ul/div/li[3]/ul/li/a");
        public IList<IWebElement> LstFilterBrand => driver.FindElements(FilterBrandList);

        public By FilterCategoryResult => By.XPath("//a[normalize-space()='General: Promotii']");
        public IWebElement LblFilterCategoryResult => driver.FindElement(FilterCategoryResult);

        public By FilterBrandResult => By.XPath("//a[normalize-space()='Brand: SAMSUNG']");
        public IWebElement LblFilterBrandResult => driver.FindElement(FilterBrandResult);

        public By DeleteFilter => By.CssSelector("a[title=\"Sterge tot\"]");
        public IWebElement BtnDeleteFilter => driver.FindElement(DeleteFilter);

        public void FilterAccessories()
        {
            WaitHelpers.WaitElementToBeVisible(driver, FilterCategoryList);
            foreach (var filterCategory in LstFilterCategory)
            {
                if (filterCategory.Text.Equals("Promotii (313)"))
                {
                    filterCategory.Click();
                    break;
                }
            }
            Thread.Sleep(2000);
            WaitHelpers.WaitElementToBeVisible(driver, FilterBrandList);
            foreach (var filterBrand in LstFilterBrand)
            {
                if (filterBrand.Text.Equals("SAMSUNG (232)"))
                {
                    filterBrand.Click();
                    break;
                }
            }
        }

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
