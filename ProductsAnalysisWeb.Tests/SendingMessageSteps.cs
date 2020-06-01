using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace ProductsAnalysisWeb.Tests
{
    [Binding]
    public class SendingMessageSteps
    {
        private readonly ScenarioContext context;
        private IWebDriver _driver;
        private ContactPage _contactPage;
        private ConfirmationPage _confirmationPage;
        private readonly ITestOutputHelper _output;
        public SendingMessageSteps(ITestOutputHelper output)
        {
            _output = output;
        }

        [Given(@"I am on the Contact page")]
        public void GivenIAmOnTheContactPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _contactPage = ContactPage.NavigateTo(_driver);
        }

        [Given(@"I have entered (.*) into the Name field")]
        public void GivenIHaveEnteredHannaIntoTheNameField(string contactName)
        {
            _contactPage.Name = contactName;
        }

        [Given(@"I have entered (.*) into the Phone field")]
        public void GivenIHaveEnteredIntoThePhoneField(string contactPhone)
        {
            _contactPage.Phone = contactPhone;
        }

        [Given(@"I have entered (.*) into the Email field")]
        public void GivenIHaveEnteredDaretaSimcorp_ComIntoTheEmailField(string contactEmail)
        {
            _contactPage.Email = contactEmail;
        }

        [Given(@"I have entered ""(.*)"" into the Message field")]
        public void GivenIHaveEnteredIntoTheMessageField(string message)
        {
            _contactPage.Message = message;
        }

        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            _confirmationPage = _contactPage.SubmitApplication();
        }

        [Then(@"I should see ""(.*)"" text on the screen")]
        public void ThenIShouldSeeTextOnTheScreen(string confirmationText)
        {
            _output.WriteLine("Expected - " + confirmationText + "\nActual - " + _confirmationPage.Message);
            Assert.Equal(confirmationText, _confirmationPage.Message);
        }
        [Then(@"I should see ""(.*)"" text on the contact screen")]
        public void ThenIShouldSeeTextOnTheContactScreen(string phoneValidation)
        {
            _output.WriteLine("Expected - " + phoneValidation + "\nActual - " + _contactPage.PhoneValidation);
            Assert.Equal(phoneValidation, _contactPage.PhoneValidation);
        }

        [Then(@"I should see ""(.*)"" text under Name field")]
        public void ThenIShouldSeeTextUnderNameField(string nameValidation)
        {
            _output.WriteLine("Expected - " + nameValidation + "\nActual - " + _contactPage.PhoneValidation);
            Assert.Equal(nameValidation, _contactPage.PhoneValidation);
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }


    }
}
