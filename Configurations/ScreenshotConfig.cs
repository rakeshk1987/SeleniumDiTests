using OpenQA.Selenium;

namespace SeleniumDiTests.Configurations
{
    public class ScreenshotConfig
    {
        private readonly string _testOutputPath;

        public ScreenshotConfig(string testOutputPath)
        {
            _testOutputPath = testOutputPath;
        }

        public string CaptureScreenshot(IWebDriver driver, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = $"Screenshot_{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var filePath = Path.Combine(_testOutputPath, fileName);
            screenshot.SaveAsFile(filePath); 
            return filePath;
        }
    }
}
