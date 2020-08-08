using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FlipKart.Send_Email;
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
        public ExtentReports extent = null;
        public ExtentTest test = null;

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

            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\HP\source\repos\FlipKart\FlipKart\ExtentReport\TestClass.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(8000);
            extent.Flush();
            Thread.Sleep(3000);
            EmailSend.SendMail();
            driver.Quit();
        }
    }
}
