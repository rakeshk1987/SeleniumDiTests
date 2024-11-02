using OpenQA.Selenium;
using SeleniumDiTests.Configurations;

namespace SeleniumDiTests.Pages
{
    public class LoginPage
    {        
        private readonly IWebDriver _driver;
        private readonly WebDriverWaitHelper _waitHelper;

        private IWebElement navigateLoginPage => _driver.FindElement(By.XPath("//a[contains(text(),'Form Authentication')]"));
        public IWebElement UsernameField => _driver.FindElement(By.Id("username"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.XPath("//i[@class='fa fa-2x fa-sign-in']"));
        public IWebElement SuccessMessage => _driver.FindElement(By.XPath("//div[@class='flash success']"));
        public IWebElement LogoutButton => _driver.FindElement(By.XPath("//a[@class='button secondary radius']"));
        
        public LoginPage(IWebDriver driver, WebDriverWaitHelper waitHelper)
        {
            _driver = driver;
            _waitHelper = waitHelper;
        }    

        public string Login(string username, string password)
        {
            _waitHelper.WaitForElementToBeVisible(By.XPath("//a[contains(text(),'Form Authentication')]"));
            navigateLoginPage.Click();
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();

            return SuccessMessage.Text;
        }


    }
}
