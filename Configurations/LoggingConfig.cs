using Serilog;
using System.IO;

namespace SeleniumDiTests.Configurations
{
    public class LoggingConfig
    {
        public static void ConfigureLogging(string logFilePath)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(logFilePath, "log.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
