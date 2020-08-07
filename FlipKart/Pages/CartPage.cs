using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace FlipKart.Pages
{
    public class CartPage
    {
        IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "pincodeInputId")]
        public IWebElement PinCodeBox;
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'411052')]")]
        public IWebElement SelectPinCode;
        [FindsBy(How = How.XPath, Using = "//span[@class='_2aK_gu']")]
        public IWebElement CheckButton;
        [FindsBy(How = How.XPath, Using = "//button[@class='_2AkmmA _2Npkh4 _2MWPVK']")]
        public IWebElement AddToCartButton;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Place Order')]")]
        public IWebElement PlaceOrderButton;

        public void AddToCart()
        {
            PinCodeBox.Click();
            Thread.Sleep(5000);
            SelectPinCode.Click();
            Thread.Sleep(5000);          
          //  CheckButton.Click();
          //  Thread.Sleep(5000);
            AddToCartButton.Click();
            Thread.Sleep(5000);
            PlaceOrderButton.Click();
        }
    }
}
