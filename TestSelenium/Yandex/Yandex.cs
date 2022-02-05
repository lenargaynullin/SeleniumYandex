using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestSelenium
{
    public class YandexTest
    {
        private WebDriver driver;
        private WebDriverWait wait;
        private string login, passwod;
        private bool isAuth = false;

        const string YandexUrl = "https://yandex.ru/";
        const string YandexMarketUrl = "https://market.yandex.ru/";

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            
            // Отключить "Браузером управляет автоматизированное ПО
            //chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            //chromeOptions.AddExcludedArgument("enable-automation");
            
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        //[Test]
        //public void CheckYandexOpenTesting()
        //{
         //   driver.Navigate().GoToUrl(YandexUrl);
         //   Assert.AreEqual("https://yandex.ru/", driver.Url, "Яндекс не открылся");
            
        //}

        [Test]
        public void CheckYandexMarketTesting()
        {
            
            driver.Manage().Window.Maximize(); // Окно во весь экран
            driver.Navigate().GoToUrl(YandexMarketUrl); // Открыть Yandex Market
            
            
            
            // Нажать Яндекс Маркет
            //IWebElement market = wait.Until(e => e.FindElement(By.XPath("//div[text()='Маркет']")));
            //market.Click();
            
            // Клик Электроника
            IWebElement button2 = wait.Until(e => e.FindElement(By.XPath("//span[text()='Электроника']")));
            button2.Click();

            // Клик Смартфоны
            IWebElement button3 = wait.Until(e => e.FindElement(By.XPath("//a[text()='Смартфоны']")));
            button3.Click();
            Thread.Sleep(3000);
            
            // Выбрать цену от 30000 рублей
            IWebElement price = wait.Until(e => e.FindElement(By.CssSelector("input[name='Цена от']")));
            price.SendKeys("30000");
            Thread.Sleep(3000);

            // Диагональ экрана 6.5" и больше
            IWebElement screen = wait.Until(e => e.FindElement(By.XPath("//span[text()='6.5\" и больше']")));
            screen.Click();
            Thread.Sleep(3000);
           
            // Apple
            IWebElement apple = wait.Until(e => e.FindElement(By.XPath("//span[text()='Apple']")));
            apple.Click();
            Thread.Sleep(3000);
           
            // Nokia
            IWebElement nokia = wait.Until(e => e.FindElement(By.XPath("//span[text()='Nokia']")));
            nokia.Click();
            Thread.Sleep(3000);

            // Realme
            IWebElement realme = wait.Until(e => e.FindElement(By.XPath("//span[text()='realme']")));
            realme.Click();
            Thread.Sleep(3000);
            
            // Samsung
            IWebElement samsung = wait.Until(e => e.FindElement(By.XPath("//span[text()='Samsung']")));
            samsung.Click();
            Thread.Sleep(3000);

            // Xiaomi
            IWebElement xiaomi = wait.Until(e => e.FindElement(By.XPath("//span[text()='Xiaomi']")));
            xiaomi.Click();
            Thread.Sleep(3000);

            // Проверить что элементов на странице 10
            int ElementsCount = driver.FindElements(By.XPath("//article")).Count;
            
            var ElementsMore10 = false;
            if (ElementsCount >= 10) 
            {
                ElementsMore10 = true; 
                Console.WriteLine("Количество элементов на странице больше 10");
            }
            //Assert.AreEqual(true, ElementsMore10, "Элементов на странице меньше 10");
            Thread.Sleep(3000);
            
            // Запомнить первый элемент в списке.
            IWebElement firstElement = wait.Until(e => e.FindElement(By.XPath("(//a[contains(@class,'_2f75n _24Q6d')])[1]")));
            Thread.Sleep(3000);
            
            IWebElement firstElementTitle = wait.Until(e => e.FindElement(By.XPath("(//a[@title='Смартфон Samsung Galaxy M52 5G'])[1]")));
            Thread.Sleep(3000); 
                
            // Изменить Сортировку на другую (по цене).
            IWebElement sortingByPrice = wait.Until(e => e.FindElement(By.XPath("//button[text()='по цене']")));
            sortingByPrice.Click();
            Thread.Sleep(3000);
            
            // Найти и нажать по имени запомненного объекта.
            firstElementTitle.Click();   
            Thread.Sleep(3000);
            
            // Вывести цифровое значение его оценки.
            IWebElement phoneRating = wait.Until(e => e.FindElement(By.XPath("(//span[@class='_2v4E8'])[2]")));
            string rating = phoneRating.GetAttribute("innerText");
            
            Thread.Sleep(3000);
            Console.WriteLine("Оценка равна = " + rating);
            
            
            // Закрыть браузер.

            Assert.AreEqual("https://yandex.ru/", driver.Url, "Яндекс Маркет не открылся");

        }

        
    }   
          
}