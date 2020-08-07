using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.Threading;

namespace FlipKart.Base
{
    public class BaseClass
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Initlize()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments("--disable-notification");
            driver = new ChromeDriver(opt);
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            string flipKartUrl = ConfigurationManager.AppSettings["url"];
            driver.Url = flipKartUrl;
        }

        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(8000);          
            driver.Quit();
        }
    }
}
