using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoWebApp.Tests
{
    [Binding]
    public class LoadAppSteps
    {
        private IWebDriver _driver;
        private LoanAppPage _loanAppPage;
        private AppConfirmationPage _confirmationPage;

        [Given(@"I am on the load application screen")]
        public void GivenIAmOnTheLoadApplicationScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
//            _driver.Navigate().GoToUrl("http://localhost/LoanApp/Home/StartLoanApplication");
            _loanAppPage = LoanAppPage.NavigateTo(_driver);
        }

        [Given(@"I enter a first name of (.*)")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            //    IWebElement FirstName = _driver.FindElement(By.Id("FirstName"));
            //    FirstName.SendKeys(firstName);
            _loanAppPage.FirstName = firstName;
        }

        [Given(@"I enter a second name of (.*)")]
        public void GivenIEnterASecondNameOf(string lastName)
        {
            //_driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            _loanAppPage.LastName = lastName;
        }

        [Given(@"I select that I have an existing loan account")]
        public void GivenISelectThatIHaveAnExistingLoanAccount()
        {
            //_driver.FindElement(By.Id("Loan")).Click();
            _loanAppPage.SelectExistingLoan();
        }
        
        [Given(@"I confirm my acceptance of the terms and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTermsAndConditions()
        {
            //_driver.FindElement(By.Name("TermsAcceptance")).Click();
            _loanAppPage.AcceptTermsAndConditions();
        }
        
        [When(@"I submit my application")]
        public void WhenISubmitMyApplication()
        {
            //_driver.FindElement(By.CssSelector(".btn")).Submit();
           _confirmationPage= _loanAppPage.SubmitApplication();
        }
        
        [Then(@"I should see the application complete confirmation for Sarah")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForSarah()
        {
            //IWebElement confirmation = _driver.FindElement(By.Id("firstName"));
            //Assert.AreEqual("Sarah", confirmation.Text);
            Assert.AreEqual("Sarah", _confirmationPage.FirstName);
        }

        [Then(@"I should see an error message telling me I must accept the terms and conditions")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustAcceptTheTermsAndConditions()
        {
            //IWebElement errorElement =
            //_driver.FindElement(By.CssSelector("div.validation-summary-errors ul li"));
            Assert.AreEqual("You must accept the terms and conditions", _loanAppPage.ErorText);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
