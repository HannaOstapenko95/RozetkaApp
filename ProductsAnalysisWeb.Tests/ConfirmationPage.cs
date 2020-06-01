using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAnalysisWeb.Tests
{
    public  class ConfirmationPage
    {
		private readonly IWebDriver _driver;

		[FindsBy(How = How.Id, Using = "confirmationMessage")]
		private IWebElement _confirmationMessage;
		public ConfirmationPage(IWebDriver driver)
		{
			_driver = driver;
			PageFactory.InitElements(_driver, this);
		}
		////public string FirstName => _driver.FindElement(By.Id("firstName")).Text;
		//public string FirstName => _firstName.Text;
		public string Message => _confirmationMessage.Text;

	}
}
