using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamTests.Pages
{
    internal class BonusesPage : PageObject
    {
        public BonusesPage(WebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }
        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://lis-skins.ru/bonuses/");

            return this;
        }
    }
}
