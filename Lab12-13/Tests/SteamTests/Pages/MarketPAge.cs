using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamTests.Service;
using System.Threading.Tasks;

namespace SteamTests.Pages
{
    internal class MarketPAge : PageObject
    {
        private IWebElement CartButton
        {
            get => driver.FindElement(By.ClassName("cart-button"));
        }
        private IWebElement CartDiv
        {
            get => driver.FindElement(By.ClassName("cart-skins-market-user-cart")); 
        }
        private IWebElement ToCart
        {
            get => driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[3]/div[2]/div/div[2]/div[4]"));
        }
        private IWebElement ItemValue
        {
            get => driver.FindElement(By.XPath("/html/body/header/section/div/div[2]/div[1]/div[3]/div[2]/div[3]/div[2]/div[1]/div/div[1]/div[2]"));
        }
        private IWebElement trash
        {
            get => driver.FindElement(By.XPath("//div[@class='small-item ']/div[4]"));
        }
        private IWebElement emptycart
        {
            get => driver.FindElement(By.ClassName("cart-empty"));
        }
        private IWebElement clearcart
        {
            get => driver.FindElement(By.ClassName("clear-cart"));
        }
        public MarketPAge(WebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }
        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://lis-skins.ru/market/cs2/");

            return this;
        }

        public bool addtocart()
        {
            try
            {
                ToCart.Click();
                CartButton.Click();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool removefromcart()
        {
            try
            {
                addtocart();
                if (!emptycart.Displayed)
                {

                    trash.Click();
                }
                else {
                    LoggerService.WriteLine("AddskinToCart: Cart is empty");
                    return false; }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool removeallcart()
        {
            try
            {
                addtocart();
                if (!emptycart.Displayed)
                {

                    clearcart.Click();
                }
                else
                {
                    LoggerService.WriteLine("AddskinToCart: Cart is empty");
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
