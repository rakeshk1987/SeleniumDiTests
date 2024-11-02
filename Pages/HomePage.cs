using SeleniumDiTests.DriverSetup;

namespace SeleniumDiTests.Pages
{
    public class HomePage : BasePage, IHomePage
    {
        private readonly string _baseUrl;

        public HomePage(IDriver driver, string baseUrl) : base(driver)
        {
            _baseUrl = baseUrl;
        }

        public void Navigate()
        {
            Driver.Instance.Navigate().GoToUrl(_baseUrl);
        }
    }
}
