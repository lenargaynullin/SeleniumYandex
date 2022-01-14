using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestSelenium.patterns
{
    public class PatternsTests
    {
        private WebDriver driver;
        private WebDriverWait wait;
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void RegistrationTesting()
        {
            var registrationPage = new StartPage(driver).GetRegistrationPage();
            registrationPage.SetEmail("dfsfsfs@sfdsfs.ru")
                .SubmitRegistration();
            Assert.IsTrue(registrationPage.IsSuccessRegistration());
        }
        
        [Test]
        public void LoginTesting()
        {
            var loginPage = new StartPage(driver).GetLoginPage();
            loginPage.Login("alisa.skrynko@gmail.com", "c069db");
            Assert.AreEqual("https://old.kzn.opencity.pro/cabinet/", driver.Url, "Не перешли в личный кабинет");
        }

        [Test]
        public void FActoryTest()
        {
            StartPage startPage = new StartPage(driver);
            PageFactory.InitElements(driver, startPage);
            startPage.About.Click();
            Assert.AreEqual("https://old.kzn.opencity.pro/aboutproject", driver.Url);
        }


        [Test]
        public void PageElementTesting()
        {
            StartPage startPage = new StartPage(driver);
            startPage.sendOrderMenu.Click();
            Assert.AreEqual("https://old.kzn.opencity.pro/sendorder", driver.Url);
        }


        [Test]
        public void BuilderTest()
        {
            var person = new Person.Builder()
                .WithSurname("Petrov")
                .WithName("Dima").build();
            var a = 5;
        }
    }
}