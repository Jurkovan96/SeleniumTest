using AltexTestProject.Controls;
using AltexTestProject.PageObjects.Address;
using AltexTestProject.PageObjects.Information;
using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Summary
{
    public class SummaryPage
    {
        public IWebDriver driver;
        public SummaryPage(IWebDriver browser)
        {
            driver = browser;
        }

        public By Firstname = By.CssSelector("p[class=u-color-black]");
        public IWebElement lblFirstname => driver.FindElement(Firstname);

        private By Edit = By.CssSelector("a[href*=informatii][class=underline]");
        public IWebElement BtnEdit => driver.FindElement(Edit);

        private By Address = By.CssSelector("li[class*=Sidebar-item] a[href*=adrese]");
        public IWebElement BtnAddress => driver.FindElement(Address);

        public InformationPage GoToEditAccount()
        {
            WaitHelpers.WaitElementToBeVisible(driver, Edit);
            BtnEdit.Click();
            return new InformationPage(driver);
        }

        public AddressPage GoToAddressPage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, Address);
            BtnAddress.Click();
            return new AddressPage(driver);
        }

        public LoggedInMenuItemControl loggedInMenuItemControl => new LoggedInMenuItemControl(driver);
    }
}
