using AltexTestProject.PageObjects.Address.InputData;
using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Address
{
    public class NewAddressPage
    {
        public IWebDriver driver;
        public NewAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        public By FirstName = By.CssSelector("input[name=first_name]");
        public IWebElement TxtFirstName => driver.FindElement(FirstName);

        private By LastName = By.CssSelector("input[name=last_name]");
        public IWebElement TxtLastName => driver.FindElement(LastName);

        private By CustomerType = By.CssSelector("input[type=radio]");
        public IList<IWebElement> LstCUstomerType => driver.FindElements(CustomerType);

        private By Telephone = By.CssSelector("input[name=telephone]");
        public IWebElement TxtTelephone => driver.FindElement(Telephone);

        private By Street = By.CssSelector("textarea[name=street]");
        public IWebElement TxtStreet => driver.FindElement(Street);

        private By SaveAddress = By.XPath("//button[normalize-space()='Salveaza adresa']");
        public IWebElement BtnSaveAddress => driver.FindElement(SaveAddress);

        public By InvalidRegion = By.XPath("//div[contains(text(),'Alege un judet')]");
        public IWebElement LblInvalidRegion => driver.FindElement(InvalidRegion);

        public By InvalidCity = By.XPath("//div[contains(text(),'Alege un oras')]");
        public IWebElement LblInvalidCity => driver.FindElement(InvalidCity);


        public void SaveAddressFail(NewAddressBO newAddressBO)
        {
            WaitHelpers.WaitElementToBeVisible(driver, SaveAddress);
            TxtFirstName.Clear();
            TxtFirstName.SendKeys(newAddressBO.FirstName);
            TxtLastName.Clear();
            TxtLastName.SendKeys(newAddressBO.LastName);
            TxtTelephone.SendKeys(newAddressBO.Telephone);
            TxtStreet.SendKeys(newAddressBO.Street);
            BtnSaveAddress.Click();
        }
    }
}
