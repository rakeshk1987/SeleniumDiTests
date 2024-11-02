using Microsoft.Extensions.DependencyInjection;
using SeleniumDiTests.DriverSetup;
using SeleniumDiTests.Pages;
using Serilog;
using NUnit.Framework;

namespace SeleniumDiTests.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {       

        [Test]
        public void ValidatetheLogintotheSystem()
        {
            Log.Information("Starting login test");
            var homePage = ServiceProvider.GetRequiredService<IHomePage>();
            var loginPage = ServiceProvider.GetRequiredService<LoginPage>();
            homePage.Navigate();
            var message = loginPage.Login("tomsmith", "SuperSecretPassword!");
            Assert.That(message.TrimEnd(), Is.EqualTo("You logged into a secure area!\r\n×"));
        }
    }
}
