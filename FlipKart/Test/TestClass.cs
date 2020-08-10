// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FlipKart.Base;
using FlipKart.Pages;
using FlipKart.ScreenShot;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace FlipKart
{
    [TestFixture]
    public class TestClass : BaseClass
    {
        //applied logger in file
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test, Order(1)]
        public void LoginPageTest()
        {            
           
                LoginPage login = new LoginPage(driver);
                login.AccountLogin();
               // test.Log(Status.Info, "Login Successfull..");
                //Validation
                Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(text(),'pushkar')]")).Displayed);                
                log.Info("login verification successfull");
           
        }

        [Test,Order(2)]
        public void SearchProductTest()
        {
           
                HomePage home = new HomePage(driver);
                home.SelectProduct();
               // test.Log(Status.Info, "Product Selected Successfully..");
                //Validation
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Assert.IsTrue(driver.FindElement(By.Id("pincodeInputId")).Displayed);                
                log.Info("SearchProductTest verification successfull");
           
        }

        [Test, Order(3)]
        public void AddProductToCartTest()
        {
           
                CartPage cart = new CartPage(driver);
                cart.AddToCart();
               // test.Log(Status.Info, "Product Added To Cart Successfully..");
                //Validation            
                Thread.Sleep(5000);
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='_1QbRjw']")).Displayed);              
                log.Info("AddProductToCartTest verification successfull");
          
        }

        [Test, Order(4)]
        public void AddAddressTest()
        {
           
                AddAddressPage address = new AddAddressPage(driver);
                address.ProvideAddress();
               // test.Log(Status.Info, "Address Added Successfully..");
                //Validation            
                Thread.Sleep(5000);
                Assert.IsTrue(driver.FindElement(By.XPath("//h3[@class='_1fM65H _2RMAtd']")).Displayed);               
                log.Info("AddAddressTest verification successfull");
           
        }

        [Test, Order(5)]
        public void LogoutAccountTest()
        {
           
                LogoutPage logout = new LogoutPage(driver);
                logout.LogoutFromAccount();
               // test.Log(Status.Info, "Logout Successfully..");
                //Validation            
                Thread.Sleep(5000);
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='Og_iib col col-2-5 _3SWFXF']")).Displayed);                
                log.Info("LogoutAccountTest verification successfull");
           
        }       
    }
}
