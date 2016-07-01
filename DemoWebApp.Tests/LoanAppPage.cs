using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoWebApp.Tests
{
    public class LoanAppPage
    {
        private const string PageUri = @"http://localhost/LoanApp/Home/StartLoanApplication";
        private readonly IWebDriver _driver;

        public LoanAppPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static LoanAppPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new LoanAppPage(driver);
        }

        public string FirstName
        {
            set
            {
                _driver.FindElement(By.Id("FirstName")).SendKeys(value);
            }
        }

        public string LastName
        {
            set
            {
                _driver.FindElement(By.Id("LastName")).SendKeys(value);
            }
        }

        public string ErorText =>
            _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li")).Text;

        public void SelectExistingLoan()
        {
            _driver.FindElement(By.Id("Loan")).Click();
        }

        public void AcceptTermsAndConditions()
        {
            _driver.FindElement(By.Name("TermsAcceptance")).Click();
        }

        public AppConfirmationPage SubmitApplication()
        {
            _driver.FindElement(By.CssSelector(".btn")).Click();
            return new AppConfirmationPage(_driver);
        }
    }
}
