using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using SeleniumDiTests.Configurations;
using SeleniumDiTests.DriverSetup;
using SeleniumDiTests.Pages;

namespace SeleniumDiTests
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configuration);
            services.AddSingleton<ChromeDriverConfig>(sp =>
            {
                var config = new ChromeDriverConfig();
                _configuration.GetSection("ChromeDriver").Bind(config);
                return config;
            });

            services.AddSingleton(sp =>
            {
                var driver = sp.GetRequiredService<IDriver>().Instance;
                return new WebDriverWaitHelper(driver, TimeSpan.FromSeconds(10)); // Set timeout as needed
            });

            services.AddSingleton<IDriver, Driver>();
            services.AddSingleton<IWebDriver>(sp => sp.GetRequiredService<IDriver>().Instance); // Register IWebDriver
            services.AddTransient<IHomePage, HomePage>(sp =>
                new HomePage(sp.GetRequiredService<IDriver>(), _configuration["BaseUrl"]));
            services.AddTransient<LoginPage>();
        }
    }
}
