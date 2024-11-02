using OpenQA.Selenium;

namespace SeleniumDiTests.DriverSetup
{
    public interface IDriver
    {
        IWebDriver Instance { get; }
        void Quit();
    }
}
