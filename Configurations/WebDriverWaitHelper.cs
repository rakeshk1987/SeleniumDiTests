using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumDiTests.Configurations
{
    public class WebDriverWaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WebDriverWaitHelper(IWebDriver driver, TimeSpan timeout)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, timeout);
        }

        public IWebElement WaitForElementToBeClickable(By locator)
        {
            return _wait.Until(driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Enabled) ? element : null;
            });
        }

        public IWebElement WaitForElementToBeVisible(By locator)
        {
            return _wait.Until(driver =>
            {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        public bool WaitForElementToDisappear(By locator)
        {
            return _wait.Until(driver =>
            {
                var elements = driver.FindElements(locator);
                return elements.Count == 0;
            });
        }
    }
}
