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
        IWebDriver _driver;

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
            var username = "absolutelynotfake@email.com";
            var password = "password";

            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.FindElement(By.ClassName("login")).Click();

            var email = _driver.FindElement(By.Id("email"));
            email.SendKeys(username);

            var pass = _driver.FindElement(By.Id("passwd"));
            pass.SendKeys(password);

            _driver.FindElement(By.Id("SubmitLogin")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("http://automationpractice.com/index.php?controller=my-account"));

            Assert.AreEqual("Sign out",_driver.FindElement(By.ClassName("logout")).Text);

        }

        [Test]
        public void RegistrationTest()
        {
            var username = "anotherfake32121@email.com";
            var password = "password";

            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.FindElement(By.ClassName("login")).Click();

            _driver.FindElement(By.Id("email_create")).SendKeys(username);
            _driver.FindElement(By.Id("SubmitCreate")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation"));

            _driver.FindElement(By.Id("id_gender2")).Click();
            _driver.FindElement(By.Id("customer_firstname")).SendKeys("FirstName");
            _driver.FindElement(By.Id("customer_lastname")).SendKeys("Lastname");
            _driver.FindElement(By.Id("passwd")).SendKeys(password);
            _driver.FindElement(By.Id("address1")).SendKeys("TotallyAddress");
            _driver.FindElement(By.Id("city")).SendKeys("MyCity");

            IWebElement dropList = _driver.FindElement(By.Id("id_state"));
            SelectElement clickThis = new SelectElement(dropList);
            clickThis.SelectByIndex(1);

            _driver.FindElement(By.Id("postcode")).SendKeys("00000");
            _driver.FindElement(By.Id("phone_mobile")).SendKeys("123123123");

            _driver.FindElement(By.Id("submitAccount")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("navigation_page")));

            StringAssert.EndsWith("multi-shipping=0",_driver.Url);
        }
    }
}
