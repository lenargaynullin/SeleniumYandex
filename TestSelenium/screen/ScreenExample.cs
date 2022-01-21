using System;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestSelenium.patterns;

namespace TestSelenium.screen
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    // https://docs.nunit.org/articles/nunit/writing-tests/attributes/parallelizable.html
    public class ScreenExample
    {
        private WebDriver driver;
        private WebDriverWait wait;
        private StartPage _startPage;
        
        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            if (driver.FindElements(By.XPath("//a[@class='btnExit']")).Count > 0)
            {
                driver.FindElement(By.XPath("//a[@class='btnExit']")).Click();
            }
            _startPage = new StartPage(driver).Open();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
        [Test]
        public void LoginTesting()
        {
            string pathStart = "D:/testing/TestSelenium/TestSelenium/TestSelenium/screen/resourses";
            var loginPage = _startPage.GetLoginPage();
            loginPage.Login("alisa.skrynko@gmail.com", "c069db");

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(pathStart + "/screenTest.png",
                ScreenshotImageFormat.Png);
            byte[] expectedFile = File.ReadAllBytes(pathStart + "/screen.png");
            byte[] actualFile = File.ReadAllBytes(pathStart + "/screenTest.png");

            var element = driver.FindElement(By.XPath("//a[@class='btnExit']"));
            Screenshot screenshotElement = ((ITakesScreenshot)element).GetScreenshot();
            screenshotElement.SaveAsFile(pathStart + "/screenElement.png",
                ScreenshotImageFormat.Png);
            Assert.AreEqual(expectedFile, actualFile);
        }
        
        [Test]
        public void Login2Testing()
        {
            string pathStart = "D:/testing/TestSelenium/TestSelenium/TestSelenium/screen/resourses";
            
            var loginPage = _startPage.GetLoginPage();
            loginPage.Login("alisa.skrynko@gmail.com", "c069db");
            
            var element = driver.FindElement(By.XPath("//a[@class='btnExit']"));
            JObject jsonStyle = JObject.Parse(File.ReadAllText(pathStart + "/cssExample.json"));
            Assert.AreEqual(jsonStyle["font"].ToString(), element.GetCssValue("font"));
        }
    }
}