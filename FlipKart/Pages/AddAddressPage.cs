using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlipKart.Pages
{
    public class AddAddressPage
    {
        IWebDriver driver;

        public AddAddressPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='_2Y8lQ1']")]
        public IWebElement AddAddressBox;
        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        public IWebElement Name;
        [FindsBy(How = How.XPath, Using = "//input[@name='phone']")]
        public IWebElement Mobile;
        [FindsBy(How = How.XPath, Using = "//input[@name='pincode']")]
        public IWebElement PinCode;
        [FindsBy(How = How.XPath, Using = "//input[@name='addressLine2']")]
        public IWebElement Locality;
        [FindsBy(How = How.XPath, Using = "//textarea[@name='addressLine1']")]
        public IWebElement AddressLine;
        [FindsBy(How = How.XPath, Using = "//input[@name='city']")]
        public IWebElement City;
        [FindsBy(How = How.XPath, Using = "//select[@name='state']")]
        public IWebElement State;
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'Maharashtra')]")]
        public IWebElement SelectState;
        [FindsBy(How = How.XPath, Using = "//label[@class='_8J-bZE _2s38SO _29FFjj _3lyfHx _1Icwrf']//label[1]//div[1]")]
        public IWebElement AddressType;
        [FindsBy(How = How.XPath, Using = "//button[@class='_2AkmmA EqjTfe _7UHT_c']")]
        public IWebElement SaveButton;
        [FindsBy(How = How.XPath, Using = "//button[@class='_2AkmmA _2Q4i61 _7UHT_c']")]
        public IWebElement CheckSummryAndContinue;

        public void ProvideAddress()
        {
            AddAddressBox.Click();
            Thread.Sleep(3000);
            Name.SendKeys("Pushkar Morey");
            Thread.Sleep(3000);
            Mobile.SendKeys("7768076656");
            Thread.Sleep(3000);
            PinCode.SendKeys("411052");
            Thread.Sleep(3000);
            Locality.SendKeys("sai mandir");
            Thread.Sleep(3000);
            AddressLine.SendKeys("Teacher Colony nr. telephone exchange");
            Thread.Sleep(3000);
           // City.SendKeys("Pune");
           // Thread.Sleep(5000);
           // State.Click();
           // Thread.Sleep(5000);
           // SelectState.Click();
           // Thread.Sleep(5000);
            AddressType.Click();
            Thread.Sleep(3000);
            SaveButton.Click();
            Thread.Sleep(3000);
            CheckSummryAndContinue.Click();
        }
    }
}
