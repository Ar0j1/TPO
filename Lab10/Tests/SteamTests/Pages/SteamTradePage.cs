using OpenQA.Selenium;

namespace ListTradesTest.Pages
{
    internal class SteamTradePage : PageObject
    {
        private IWebElement SteamLinktraid
        {
            get => driver.FindElement(By.Id("trade_offer_access_url"));
        }

        public SteamTradePage(WebDriver? driver) : base(driver)
        {
          
                driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
           
        }

        public override PageObject OpenPage()
        {
            return this;
        }

        public string CopyTradeLink()
        {
            Thread.Sleep(1000);
            string traidURL = SteamLinktraid.GetAttribute("value");

            return traidURL;
        }
        public LisProfilePage BackToProfile()
        {
            driver.Navigate().Back();
            return new LisProfilePage(driver);
        }
    }
}
