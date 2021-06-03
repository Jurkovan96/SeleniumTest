using AltexTestProject.PageObjects.Products.InputData;
using AltexTestProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Products
{
    public class IndividualProductPage
    {
        public IWebDriver driver;

        public IndividualProductPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By AddReview = By.CssSelector("li[id='reviews'] div div[class='hidden md:block'] div div[class='flex items-center justify-center']");
        public IWebElement BtnAddReview => driver.FindElement(AddReview);

        private By Title = By.CssSelector("input[name = title]");
        public IWebElement TxtTitle => driver.FindElement(Title);

        private By Body = By.CssSelector("textarea[name=body]");
        public IWebElement TxtBody => driver.FindElement(Body);

        private By SentReview = By.CssSelector("button[type = 'submit'] div div[class='border-2 rounded py-2px px-4 border-transparent']");
        public IWebElement BtnSentReview => driver.FindElement(SentReview);

        private By Stars = By.XPath("//body//div//label[4]//*[local-name()='svg']//*[name()='path' and contains(@d,'M10 15l-5.')]");
        public IWebElement BtnStars => driver.FindElement(Stars);

        public By Result = By.XPath("//div[normalize-space()='Recenzia ta a fost adaugata. Iti multumim pentru contributie.']");
        public IWebElement LblResult => driver.FindElement(Result);

        public By EmailFail = By.CssSelector("div[class*=is-active] div[class=Form-validate-message]");
        public IWebElement LblEmailFail => driver.FindElement(EmailFail);

        public void sentReview(AddReviewBO addReviewBO)
        {
            WaitHelpers.WaitElementToBeVisible(driver, AddReview);
            BtnAddReview.Click();

            WaitHelpers.WaitElementToBeVisible(driver, Title);
            TxtTitle.SendKeys(addReviewBO.Title);
            TxtBody.SendKeys(addReviewBO.Body);
            BtnStars.Click();

            BtnSentReview.Click();
        }
    }
}
