
using FlipKart.JsonFile;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace FlipKart.Pages
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        [FindsBy(How = How.XPath, Using = "//input[@class='_2zrpKA _1dBPDZ']")]
        public IWebElement MobileBox;
        [FindsBy(How = How.XPath, Using = "//input[@class='_2zrpKA _3v41xv _1dBPDZ']")]
        public IWebElement Password;
        [FindsBy(How = How.XPath, Using = "//button[@class='_2AkmmA _1LctnI _7UHT_c']//span[contains(text(),'Login')]")]
        public IWebElement FinalLoginButton;       

        public void AccountLogin()
        {
            Credentials cred = new Credentials();           
                      
            MobileBox.SendKeys(cred.phone);
            Thread.Sleep(3000);            
            Password.SendKeys(cred.password);
            Thread.Sleep(3000);
            FinalLoginButton.Click();
            Thread.Sleep(2000);            
        }
    }
}
