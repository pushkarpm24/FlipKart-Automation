using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FlipKart.ScreenShot;
using FlipKart.Send_Email;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            opt.AddArguments("--disable-notification","--start-maximized");
            driver = new ChromeDriver(opt);
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           // driver.Manage().Window.Maximize();
            string flipKartUrl = ConfigurationManager.AppSettings["url"];
            driver.Url = flipKartUrl;
            //Extent Report..
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

        [TearDown]        
        public void Teardown()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    test.Log(Status.Fail, "Test Failed..");
                    //taking screenshot 
                    test.AddScreenCaptureFromPath(TakeScreenshot.TakeSs(driver));
                    
                }
                else if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    test.Log(Status.Pass, "Test Successfull.."); //shows the pass status in report

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
