using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Storage;
using OpenQA.Selenium.Support.UI;

namespace SteamTests.Pages
{
    internal class LisProfilePage : PageObject
    {
        private IWebElement ButtonToSteam
        {
            get => driver.FindElement(By.CssSelector("div.profile-field-title>a"));
        }
        private IWebElement TradeURL
        {
            get => driver.FindElement(By.Id("profile_trade_url"));
        }
        private IWebElement SellInvent
        {
            get => driver.FindElement(By.XPath("//a[contains(text(), 'Продать скины')]"));
        }
        private IWebElement saveButton
        {
            get => driver.FindElement(By.ClassName("save-button"));
        }
        public LisProfilePage(WebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://lis-skins.ru/profile");

            return this;
        }

        public string GetTradeLinkLis()
        {
            string StringTraidURL = TradeURL.GetAttribute("value");

            return StringTraidURL;
        }
        public LisProfilePage SaveTradeURL()
        {
            saveButton.Click();
                Thread.Sleep(1000);
            return this;
        }

        public string OpenSteamTrade()
        {
            driver.Navigate().GoToUrl("https://steamcommunity.com/id/t6masasha/tradeoffers/privacy#trade_offer_access_url");
            SteamTradePage Steam = new SteamTradePage(driver);
            Thread.Sleep(1000);
            string link = Steam.CopyTradeLink();
            Steam.BackToProfile();
            Thread.Sleep(1000);

            return link;
        }
        public bool ChangeURL()
        {
            try
            {
                Thread.Sleep(1000);
                string url = OpenSteamTrade();
                TradeURL.Clear();
                TradeURL.SendKeys(url);
                Thread.Sleep(1000);
                SaveTradeURL();
            }
            catch
            {
                return false;
            }
            return true ;
        }
    }
}
