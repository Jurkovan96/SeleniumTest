using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Address
{
    public class AddressPage
    {
        public IWebDriver driver;
        public AddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By NewAddress = By.CssSelector("button[type=button]");
        public IWebElement BtnNewAddress => driver.FindElement(NewAddress);

        public NewAddressPage GoToNewAddressPage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, NewAddress);
            BtnNewAddress.Click();
            return new NewAddressPage(driver);
        }

    }
}
