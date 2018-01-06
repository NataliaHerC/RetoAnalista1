using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PracticasBancolombia.FunctionalsTest
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver(TipoDriver tipoDriver)
        {
            IWebDriver driver = null;

            switch (tipoDriver)
            {
                case TipoDriver.Chrome:
                    driver = new ChromeDriver();
                    break;
                case TipoDriver.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    break;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            return driver;
        }
    }
}
