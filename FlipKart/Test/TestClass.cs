// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using FlipKart.Base;
using FlipKart.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace FlipKart
{
    [TestFixture]
    public class TestClass : BaseClass
    {
        [Test, Order(1)]
        public void LoginPageTest()
        {
            LoginPage login = new LoginPage(driver);
            login.AccountLogin();
            //Validation
            string expectedPageUrl = "https://www.flipkart.com/";
            string actualPageUrl = driver.Url;
            Assert.AreEqual(expectedPageUrl, actualPageUrl);
        }

        [Test,Order(2)]
        public void SearchProductTest()
        {
            HomePage home = new HomePage(driver);
            home.SelectProduct();
            //Validation
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.IsTrue(driver.FindElement(By.Id("pincodeInputId")).Displayed);
        }

        [Test, Order(3)]
        public void AddProductToCartTest()
        {
            CartPage cart = new CartPage(driver);
            cart.AddToCart();
            //Validation            
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='_1QbRjw']")).Displayed);
        }

        [Test, Order(4)]
        public void AddAddressTest()
        {
            AddAddressPage address = new AddAddressPage(driver);
            address.ProvideAddress();
            //Validation            
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.XPath("//h3[@class='_1fM65H _2RMAtd']")).Displayed);
        }

        [Test, Order(5)]
        public void LogoutAccountTest()
        {
            LogoutPage logout = new LogoutPage(driver);            
            logout.LogoutFromAccount();
            //Validation            
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='Og_iib col col-2-5 _3SWFXF']")).Displayed);
        }
    }
}
