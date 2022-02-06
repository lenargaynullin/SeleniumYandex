using System;
using System.Net.Mime;
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

        const string YandexMarketUrl = "https://market.yandex.ru/";

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            
            // Отключить "Браузером управляет автоматизированное ПО"
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddExcludedArgument("enable-automation");
            
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
        [Test]
        public void CheckYandexMarketTesting()
        {
            driver.Manage().Window.Maximize(); // Окно во весь экран
            driver.Navigate().GoToUrl(YandexMarketUrl); // Открыть Yandex Market
            
            // Клик Электроника
            IWebElement button2 = wait.Until(e => e.FindElement(By.XPath("//span[text()='Электроника']")));
            button2.Click();
            Thread.Sleep(2000);
            
            // Клик Смартфоны
            IWebElement button3 = wait.Until(e => e.FindElement(By.XPath("//a[text()='Смартфоны']")));
            button3.Click();
            Thread.Sleep(2000);
            
            // Выбрать цену от 30000 рублей
            IWebElement priceMin = wait.Until(e => e.FindElement(By.CssSelector("input[name='Цена от']")));
            priceMin.SendKeys("30000");
            Thread.Sleep(2000);
            
            // Выбрать цену до 39000 рублей
            IWebElement priceMax = wait.Until(e => e.FindElement(By.CssSelector("input[name='Цена до']")));
            priceMax.SendKeys("39000");
            Thread.Sleep(2000);
            
            // Диагональ экрана 6.5" и больше
            IWebElement screen = wait.Until(e => e.FindElement(By.XPath("//span[text()='6.5\" и больше']")));
            screen.Click();
            Thread.Sleep(1000);
           
            // Apple
            IWebElement apple = wait.Until(e => e.FindElement(By.XPath("//span[text()='Apple']")));
            apple.Click();
            Thread.Sleep(2000);
           
            // Nokia
            IWebElement nokia = wait.Until(e => e.FindElement(By.XPath("//span[text()='Nokia']")));
            nokia.Click();
            Thread.Sleep(2000);

            // Realme
            IWebElement realme = wait.Until(e => e.FindElement(By.XPath("//span[text()='realme']")));
            realme.Click();
            Thread.Sleep(2000);
            
            // Samsung
            IWebElement samsung = wait.Until(e => e.FindElement(By.XPath("//span[text()='Samsung']")));
            samsung.Click();
            Thread.Sleep(2000);

            // Xiaomi
            IWebElement xiaomi = wait.Until(e => e.FindElement(By.XPath("//span[text()='Xiaomi']")));
            xiaomi.Click();
            Thread.Sleep(2000);

            // Проверить что элементов на странице больше 10
            int ElementsCount = driver.FindElements(By.XPath("//article")).Count;
            
            var ElementsMore10 = false;
            if (ElementsCount >= 10) 
            {
                ElementsMore10 = true; 
                Console.WriteLine("Количество элементов на странице больше 10");
            }
            Thread.Sleep(2000);
            
            // Запомнить первый элемент в списке                                        
            IWebElement firstElement = wait.Until(e => e.FindElement(By.XPath("(//a[contains(@class,'_2f75n _24Q6d')]//span)[1]")));
            string firstElementText = firstElement.Text;
            
            Thread.Sleep(2000);
            
            // Изменить Сортировку на другую (по цене)
            IWebElement sortingByPrice = wait.Until(e => e.FindElement(By.XPath("//button[text()='по цене']")));
            sortingByPrice.Click();
            Thread.Sleep(5000);
           
            // Найти по имени запомненного объекта 
            IWebElement firstElementFind = wait.Until(e => e.FindElement(By.XPath("//span[text()='" + firstElementText + "']")));
            firstElementFind.Click();
            Thread.Sleep(2000);
            
            // Вывести цифровое значение его оценки.
            IWebElement phoneRating = wait.Until(e => e.FindElement(By.XPath("(//span[@class='_2v4E8'])[2]")));
            string rating = phoneRating.Text;
            Thread.Sleep(2000);
            
            
            Console.WriteLine("Название телефона = " + firstElementText);
            Console.WriteLine("Оценка равна = " + rating);
            
            
            // Закрыть браузер.
            
            Assert.AreEqual(true, ElementsMore10, "Элементов на странице меньше 10");

        }

        
    }   
          
}