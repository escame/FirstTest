using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DemoWebApp.Tests
{
    [TestClass]
    public class LoanApplicationTests
    {
        [TestMethod]
        public void StartApplication()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost/LoanApp/");

            IWebElement appButton = driver.FindElement(By.Id("startApplication"));

            appButton.Click();

            Assert.AreEqual("Start Loan Application - Loan Application", driver.Title);
        }
        [TestMethod]
        public void SubmitApplication()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost/LoanApp/Home/StartLoanApplication");

            IWebElement firstName = driver.FindElement(By.Id("FirstName"));
            firstName.SendKeys("Sarah");

            driver.FindElement(By.Id("LastName")).SendKeys("Smith");

            driver.FindElement(By.Id("Loan")).Click();

            driver.FindElement(By.Name("TermsAcceptance")).Click();

            driver.FindElement(By.CssSelector(".btn")).Submit();

            IWebElement confirmation = driver.FindElement(By.Id("firstName"));

            Assert.AreEqual("Sarah", confirmation.Text);
        }
    }
}
