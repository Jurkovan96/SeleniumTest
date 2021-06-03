using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By Search = By.XPath("//div[@class='flex items-center justify-center']");
        public IWebElement BtnSearch => driver.FindElement(Search);

        public By SearchResult = By.XPath("//h1[normalize-space()='Rezultate cautare : telefon']");
        public IWebElement LblSearchResult => driver.FindElement(SearchResult);
        
        private By SearchValue = By.XPath("//input[@type='text']");
        public IWebElement TxtSearchValue => driver.FindElement(SearchValue);

        public void searchValue()
        {
            WaitHelpers.WaitElementToBeVisible(driver, SearchValue);
            TxtSearchValue.SendKeys("telefon");
            BtnSearch.Click();
        }
    }
}
