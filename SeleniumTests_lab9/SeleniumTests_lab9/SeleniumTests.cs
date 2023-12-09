using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests_lab9
{
    [TestClass]
    public class SeleniumTests
    {
        private WebDriver? driver;

    

        private IWebElement traidURL
        {
            get => driver.FindElement(By.Id("profile_trade_url"));
        }
        private IWebElement SellInvent
        {
            get => driver.FindElement(By.XPath("//a[contains(text(), 'Продать скины')]"));
        }
        private IWebElement SteamLinktraidURL
        {
            get => driver.FindElement(By.Id("trade_offer_access_url"));
        }
        
        private IWebElement saveButton
        {
            get => driver.FindElement(By.Id("profile_save_trade_url_button"));
        }
        [TestInitialize]
        public void Init()
        {
            EdgeOptions options = new EdgeOptions();

            //// Указание пути к профилю пользователя Edge
            string userProfilePath = "C:\\Users\\Sashcha\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default";
            options.AddArgument($"user-data-dir={userProfilePath}");

            // Инициализация драйвера Edge
            driver = new EdgeDriver("msedgedriver.exe", options);
           // driver = new ChromeDriver();
        }

        [TestMethod]
        public void TraidURLTest()
        {
            // Проверка, что драйвер был инициализирован
            if (driver == null)
                Assert.Fail("Driver not started!");

            // Установка таймаутов для ожидания элементов на странице
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);

            // Переход на страницу продукта в Steam
            driver.Navigate().GoToUrl("https://lis-skins.ru/profile/");

            string StringTraidURL = traidURL.GetAttribute("value");



           
            
            if (string.IsNullOrWhiteSpace(StringTraidURL))
            {
                
                
            }
            else
            {
                driver.Navigate().GoToUrl("https://steamcommunity.com/profiles/76561198946661122/tradeoffers/privacy#trade_offer_access_url");
                string TraidURL = SteamLinktraidURL.GetAttribute("value");

                driver.Navigate().Back();
                Thread.Sleep(1000);

                traidURL.Clear();
                Thread.Sleep(1000);
                traidURL.SendKeys(TraidURL);
                saveButton.Click();
                Thread.Sleep(1000);
                SellInvent.Click();
            }
            // Завершение работы драйвера
            driver.Quit();
        }
    }
}

