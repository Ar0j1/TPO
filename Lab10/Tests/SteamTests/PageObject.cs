using OpenQA.Selenium;

namespace ListTradesTest
{
    internal abstract class PageObject
    {
        protected WebDriver? driver;

        public PageObject(WebDriver? driver) 
        { 
            this.driver = driver;
        }

        public abstract PageObject OpenPage();
    }
}
