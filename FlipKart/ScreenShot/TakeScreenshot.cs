using OpenQA.Selenium;
using System;
using System.Text;

namespace FlipKart.ScreenShot
{
    public class TakeScreenshot
    {
         public static string TakeSs(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string ssPath = @"C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ScreenShot\\" + TakeSsWithDate() + ".png";
            ss.SaveAsFile(ssPath, ScreenshotImageFormat.Png);
            return ssPath;
        }

        public static StringBuilder TakeSsWithDate()
        {
            StringBuilder DateAndTime = new StringBuilder(DateTime.Now.ToString());
            DateAndTime.Replace("/", "_");
            DateAndTime.Replace(":", "_");
            return DateAndTime;
        }
    }
}
