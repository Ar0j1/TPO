using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SteamTests.Pages
{
    internal class LisSellPage : PageObject
    {
        private IWebElement Skin
        {
            get => driver.FindElement(By.XPath("//div[@class='inventory']/div[2]"));
        }
        private IWebElement SkinActive
        {
            get => driver.FindElement(By.XPath("//div[@id='userinvertory']/div[4]"));
        }
        private IWebElement SposobVivoda
        {
            get => driver.FindElement(By.XPath("//div[@class='payment-list']/div[4]"));
        }
        private IWebElement Buttondo3d
        {
            get => driver.FindElement(By.ClassName("minimal-sum-deal"));
        }
        private IWebElement Buttonposle3d
        {
            get => driver.FindElement(By.ClassName("continue-deal"));
        }
        public LisSellPage(WebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }
        
        public bool Check()
        {
            try
            {
                Skin.Click(); Thread.Sleep(1000);
                if (!Buttondo3d.Displayed)
                {
                    SposobVivoda.Click(); Thread.Sleep(1000);
                }
                
                Buttonposle3d.Click();

            }
            catch
            {
                return false;
            }
            return true;
        }

        public override PageObject OpenPage()
        {
          
            driver.Navigate().GoToUrl("https://lis-skins.ru/cs2/");

            return this;
        
    }

  
    }
}
