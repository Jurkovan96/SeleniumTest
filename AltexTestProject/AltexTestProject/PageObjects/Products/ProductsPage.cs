using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private By AccessoriesListed => By.XPath("/html/body/div[2]/div[1]/div[2]/div[2]/ul/li[1]/ul/li[1]/div/div/ul/li[2]/ul");
        public IList<IWebElement> LstAccessories => driver.FindElements(AccessoriesListed);
        public void SelectAccessorieFromList() {

            foreach (var accessories in LstAccessories) 
            {
                if (accessories.Text.Equals("Huse telefon")) {
                    accessories.Click();
                    break;
                } 
            
            
            }
        }

        public void NavigateToAccessories() 
        {
            BtnTelephone.Click();
            SelectAccessorieFromList();
        }
    }
}
