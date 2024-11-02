using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeleniumDiTests.Configurations;
using SeleniumDiTests.DriverSetup;
using SeleniumDiTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDiTests.Tests
{
    public class TestBase
    {
        protected IServiceProvider ServiceProvider;
        protected IConfiguration Configuration;
        protected ExtentReportConfig ExtentReportConfig;
        protected ScreenshotConfig ScreenshotConfig;
        protected LoginPage LoginPage => ServiceProvider.GetRequiredService<LoginPage>();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var testOutputPath = TestContext.CurrentContext.TestDirectory;
            ExtentReportConfig = new ExtentReportConfig(testOutputPath);
            ExtentReportConfig.InitializeReport();

            ScreenshotConfig = new ScreenshotConfig(testOutputPath);

            LoggingConfig.ConfigureLogging(testOutputPath);

            var startup = new Startup(Configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        [SetUp]
        public void SetUp()
        {
            // Setup is now handled in individual test methods
        }

        [TearDown]
        public void TearDown()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var driver = ServiceProvider.GetRequiredService<IDriver>();
                var screenshotPath = ScreenshotConfig.CaptureScreenshot(driver.Instance, testName);
                var test = ExtentReportConfig.CreateTest(testName);
                test.Fail("Test failed")
                    .AddScreenCaptureFromPath(screenshotPath);
            }

            ServiceProvider.GetRequiredService<IDriver>().Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportConfig.FlushReport();
            LoggingConfig.CloseAndFlush();
        }
    }
}
