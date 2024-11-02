using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;


namespace SeleniumDiTests.Configurations
{
    public class ExtentReportConfig
    {
        private readonly string _reportPath;
        private ExtentReports _extent;

        public ExtentReportConfig(string reportPath)
        {
            _reportPath = reportPath;
        }

        public void InitializeReport()
        {
            _extent = new ExtentReports();

            var htmlReporter = new ExtentSparkReporter(Path.Combine(_reportPath, "TestReport.html"));
            _extent.AttachReporter(htmlReporter);
        }

        public ExtentTest CreateTest(string testName)
        {
            return _extent.CreateTest(testName);
        }

        public void FlushReport()
        {
            _extent.Flush();
        }
    }
}
