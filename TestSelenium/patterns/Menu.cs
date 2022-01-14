using OpenQA.Selenium;

namespace TestSelenium.patterns
{
    public class Menu
    {
        private IWebElement menuItem;

        public Menu(WebDriver driver, string containsUrl)
        {
            this.menuItem = driver.FindElement(By.XPath($"//a[contains(@href, '{containsUrl}')])"));
        }

        public void Click()
        {
            menuItem.Click();
        }
    }
}