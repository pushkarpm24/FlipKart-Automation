// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FlipKart.Base;
using FlipKart.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace FlipKart
{
    [TestFixture]
    public class TestClass : BaseClass
    {
        ExtentReports extent = null;
        ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\HP\source\repos\FlipKart\FlipKart\ExtentReport\TestClass.html");
            extent.AttachReporter(htmlReporter);
        }

        [Test, Order(1)]
        public void LoginPageTest()
        {
            try
            {
                test = extent.CreateTest("LoginPageTest").Info("Login Test Started.."); //To write Logs In The Report

                LoginPage login = new LoginPage(driver);
                login.AccountLogin();
                test.Log(Status.Info, "Login Successfull..");
                //Validation
                string expectedPageUrl = "https://www.flipkart.com/";
                string actualPageUrl = driver.Url;
                Assert.AreEqual(expectedPageUrl, actualPageUrl);
                test.Log(Status.Pass, "Login Test Passed.."); //shows the pass status in report
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                //taking screenshot 
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ScreenShot\\LoginPageTest.png", ScreenshotImageFormat.Png);
                throw;
            }
        }

        [Test,Order(2)]
        public void SearchProductTest()
        {
            try
            {
                test = extent.CreateTest("SearchProductTest").Info("SearchProduct Test Started.."); //To write Logs In The Report

                HomePage home = new HomePage(driver);
                home.SelectProduct();
                test.Log(Status.Info, "Product Selected Successfully..");
                //Validation
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Assert.IsTrue(driver.FindElement(By.Id("pincodeInputId")).Displayed);
                test.Log(Status.Pass, "SearchProductTest Passed.."); //shows the pass status in report
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                //taking screenshot 
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ScreenShot\\SearchProductTest.png", ScreenshotImageFormat.Png);
                throw;
            }
        }

        [Test, Order(3)]
        public void AddProductToCartTest()
        {
            try
            {
                test = extent.CreateTest("AddProductToCartTest").Info("AddProductToCart Test Started.."); //To write Logs In The Report

                CartPage cart = new CartPage(driver);
                cart.AddToCart();
                test.Log(Status.Info, "Product Added To Cart Successfully..");
                //Validation            
                Thread.Sleep(5000);
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='_1QbRjw']")).Displayed);
                test.Log(Status.Pass, "AddProductToCartTest Passed.."); //shows the pass status in report
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                //taking screenshot 
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ScreenShot\\AddProductToCartTest.png", ScreenshotImageFormat.Png);
                throw;
            }
        }

        [Test, Order(4)]
        public void AddAddressTest()
        {
            try
            {
                test = extent.CreateTest("AddAddressTest").Info("AddAddress Test Started.."); //To write Logs In The Report

                AddAddressPage address = new AddAddressPage(driver);
                address.ProvideAddress();
                test.Log(Status.Info, "Address Added Successfully..");
                //Validation            
                Thread.Sleep(5000);
                Assert.IsTrue(driver.FindElement(By.XPath("//h3[@class='_1fM65H _2RMAtd']")).Displayed);
                test.Log(Status.Pass, "AddAddressTest Passed.."); //shows the pass status in report
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                //taking screenshot 
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ScreenShot\\AddAddressTest.png", ScreenshotImageFormat.Png);
                throw;
            }
        }

        [Test, Order(5)]
        public void LogoutAccountTest()
        {
            try
            {
                test = extent.CreateTest("LogoutAccountTest").Info("LogoutAccount Test Started.."); //To write Logs In The Report

                LogoutPage logout = new LogoutPage(driver);
                logout.LogoutFromAccount();
                test.Log(Status.Info, "Logout Successfully..");
                //Validation            
                Thread.Sleep(5000);
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='Og_iib col col-2-5 _3SWFXF']")).Displayed);
                test.Log(Status.Pass, "LogoutAccountTest Passed.."); //shows the pass status in report
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                //taking screenshot 
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ScreenShot\\LogoutAccountTest.png", ScreenshotImageFormat.Png);
                throw;
            }
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
