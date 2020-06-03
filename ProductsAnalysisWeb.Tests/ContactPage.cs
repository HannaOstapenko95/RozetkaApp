using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAnalysisWeb.Tests
{
    public  class ContactPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"http://localhost:5001/Contact";

        [FindsBy(How = How.Id, Using = "contactName")]
        private IWebElement _contactName;

        [FindsBy(How = How.Id, Using = "contactPhone")]
        private IWebElement _contactPhone;

        [FindsBy(How = How.Id, Using = "contactEmail")]
        private IWebElement _contactEmail;

        [FindsBy(How = How.Id, Using = "contactMessage")]
        private IWebElement _contactMessage;

        [FindsBy(How = How.Id, Using = "sendMessageButton")]
        private IWebElement _submit;

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        private IWebElement _phoneValidation;

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        private IWebElement _nameValidation;
        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public static ContactPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);
            return new ContactPage(driver);
        }
        public string Name
        {
            set
            {
                _contactName.SendKeys(value);
            }
        }
        public string Phone
        {
            set
            {
                _contactPhone.SendKeys(value);
            }
        }
        public string Email
        {
            set
            {
                _contactEmail.SendKeys(value);
            }
        }
        public string Message
        {
            set
            {
                _contactMessage.SendKeys(value);
            }
        }
        public string PhoneValidation =>
             _phoneValidation.Text;

        public string NameValidation =>
             _nameValidation.Text;

        public void SubmitMessage()
        {
            _submit.Click();
        }
        public ConfirmationPage SubmitApplication()
        {
            _submit.Click();
            return new ConfirmationPage(_driver);
        }

    }
}
