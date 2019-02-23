using System;
using Castle.Core.Smtp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using StringAssert = Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert;


namespace UnitTests
{
    [TestFixture]
    public class UnitTestSelenium
    {
        private IWebDriver _driver;
        

        [SetUp]
        public void StartBrowser()
        {
            _driver = new FirefoxDriver();
 
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        [Test]
        public void LoginTest()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var username = "absolutelynotfake@email.com";
            var password = "password";

            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.FindElement(By.ClassName("login")).Click();

            var email = _driver.FindElement(By.Id("email"));
            email.SendKeys(username);

            var pass = _driver.FindElement(By.Id("passwd"));
            pass.SendKeys(password);

            _driver.FindElement(By.Id("SubmitLogin")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("controller=my-account"));

            StringAssert.Contains(_driver.Url, "controller=my-account");

        }

        [Test]
        public void RegistrationTest()
        {
            var guid = Guid.NewGuid();
            var username = $"{guid.ToString()}@email.com";
            var password = "password";

            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.FindElement(By.ClassName("login")).Click();

            _driver.FindElement(By.Id("email_create")).SendKeys(username);
            _driver.FindElement(By.Id("SubmitCreate")).Click();

            var waitForSubmitCreate = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitForSubmitCreate.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("my-account#account-creation"));

            _driver.FindElement(By.Id("id_gender2")).Click();
            _driver.FindElement(By.Id("customer_firstname")).SendKeys("FirstName");
            _driver.FindElement(By.Id("customer_lastname")).SendKeys("Lastname");
            _driver.FindElement(By.Id("passwd")).SendKeys(password);
            _driver.FindElement(By.Id("address1")).SendKeys("TotallyAddress");
            _driver.FindElement(By.Id("city")).SendKeys("MyCity");

            var dropList = _driver.FindElement(By.Id("id_state"));
            var clickThis = new SelectElement(dropList);
            clickThis.SelectByIndex(1);

            _driver.FindElement(By.Id("postcode")).SendKeys("00000");
            _driver.FindElement(By.Id("phone_mobile")).SendKeys("123123123");

            _driver.FindElement(By.Id("submitAccount")).Click();

            var waitForSubmit = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitForSubmit.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("navigation_page")));

            StringAssert.Contains(_driver.Url, "controller=my-account");
        }

        [Test]
        public void CustomerService()
        {
            var username = "absolutelynotfake@email.com";
            var password = "password";

            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.FindElement(By.ClassName("login")).Click();
            var email = _driver.FindElement(By.Id("email"));
            email.SendKeys(username);
            var pass = _driver.FindElement(By.Id("passwd"));
            pass.SendKeys(password);
            _driver.FindElement(By.Id("SubmitLogin")).Click();

            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
            var dropList = _driver.FindElement(By.Id("id_contact"));
            var clickThis = new SelectElement(dropList);
            clickThis.SelectByIndex(2);
            _driver.FindElement(By.Id("email")).SendKeys(username);
            _driver.FindElement(By.Id("id_order")).SendKeys("123212");
            _driver.FindElement(By.Id("message")).SendKeys("Message");
            _driver.FindElement(By.Id("submitMessage")).Click();

            var waitForSubmitCreate = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitForSubmitCreate.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("controller=contact"));

            StringAssert.Contains("successfully sent", _driver.PageSource);
        }
    }
}
