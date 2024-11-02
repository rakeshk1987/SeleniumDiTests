using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumDiTests.DriverSetup
{
    public class Driver : IDriver
    {
        private static IWebDriver _driver;
        private readonly ChromeDriverConfig _config;

        public Driver(ChromeDriverConfig config)
        {
            _config = config;
        }

        public IWebDriver Instance
        {
            get
            {
                if (_driver == null)
                {
                    _driver = CreateDriver();
                }
                return _driver;
            }
        }

        public void Quit()
        {
            _driver?.Quit();
            _driver = null;
        }

        private IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            if (_config.HeadlessMode)
            {
                options.AddArgument("--headless");
            }
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");

            return new ChromeDriver(options);
        }
    }
}
