using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoWebApp.Tests
{
    public class AppConfirmationPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _firstName;

        public AppConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string FirstName =>
            _firstName.Text;
    }
}