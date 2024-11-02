using SeleniumDiTests;
using SeleniumDiTests.DriverSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDiTests.Pages
{
    public class BasePage
    {
        protected readonly IDriver Driver;

        public BasePage(IDriver driver)
        {
            Driver = driver;
        }
    }
}
