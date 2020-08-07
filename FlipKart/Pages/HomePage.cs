using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace FlipKart.Pages
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search for products, brands and more']")]
        public IWebElement SearchBox;
        [FindsBy(How = How.XPath, Using = "//button[@class='vh79eN']//*[local-name()='svg']")]
        public IWebElement SearchButton;
        [FindsBy(How = How.CssSelector, Using = "div.t-0M7P._2doH3V div._3e7xtJ div._1HmYoV.hCUpcT:nth-child(1) div._1HmYoV._35HD7C:nth-child(2) div.bhgxx2.col-12-12:nth-child(2) div._3O0U0u > div:nth-child(1)")]
        public IWebElement ClickOnProduct;

        public void SelectProduct()
        {
            SearchBox.Click();
            Thread.Sleep(2000);
            SearchBox.SendKeys("electronics");
            Thread.Sleep(2000);
            SearchButton.Click();
            Thread.Sleep(8000);
            ClickOnProduct.Click();
        }
    }
}
