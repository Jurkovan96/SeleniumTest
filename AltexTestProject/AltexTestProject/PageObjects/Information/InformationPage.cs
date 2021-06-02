﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltexTestProject.PageObjects.Information.InputData;
using AltexTestProject.Utils;
using OpenQA.Selenium;

namespace AltexTestProject.PageObjects.Information
{
    public class InformationPage
    {
        public IWebDriver driver;
        public InformationPage(IWebDriver browser)
        {
            driver = browser;
        }

        public By FirstName = By.CssSelector("input[name=first_name]");

        public IWebElement TxtFirstName => driver.FindElement(FirstName);

        private By LastName = By.CssSelector("input[name=last_name]");

        public IWebElement TxtLastName => driver.FindElement(LastName);

        private By Email = By.CssSelector("input[name=email]");

        public IWebElement TxtEmail => driver.FindElement(Email);

        private By Telephone = By.CssSelector("input[name=telephone]");

        public IWebElement TxtTelephone => driver.FindElement(Telephone);

        private By Save = By.CssSelector("div[class*=lg-u] button[type=submit]");
        public IWebElement BtnSave => driver.FindElement(Save);

        public By SuccessffullyEdit = By.CssSelector("div[class=flex-grow]");
        public IWebElement LblSuccessffullyEdit => driver.FindElement(SuccessffullyEdit);

        public void EditInfo(InformationBO informationBO) {
            WaitHelpers.WaitElementToBeVisible(driver, Save);
            ClearData(informationBO);
            
            TxtFirstName.SendKeys(informationBO.FirstName);
            TxtLastName.SendKeys(informationBO.LastName);

            BtnSave.Click();
        }

        public void EditInfoBack(InformationBO informationBO)
        {            
            WaitHelpers.WaitElementToBeVisible(driver, Save);
            ClearData(informationBO);

            TxtFirstName.SendKeys("Test");
            TxtLastName.SendKeys("Test");

            BtnSave.Click();
        }

        public void ClearData(InformationBO informationBO)
        {
            for (int i = 0; i < informationBO.FirstName.Length; i++)
            {
                TxtFirstName.SendKeys(Keys.Backspace);
            }

            for (int i = 0; i < informationBO.LastName.Length; i++)
            {
                TxtLastName.SendKeys(Keys.Backspace);
            }
        }

    }

}