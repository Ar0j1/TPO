using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SteamTests.Driver;
using SteamTests.Pages;
using SteamTests.Service;

namespace SteamTests
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Init()
        {
            DriverInstance.CreateIntance();
        }

        [TestMethod]
        public void NoTradeLink()
        {
            bool result = (new LisProfilePage(DriverInstance.Driver).OpenPage() as LisProfilePage)
                                .ChangeURL();

            LoggerService.WriteLine($"NoTradeLink ended with [{result}] result!");

            Assert.Fail("Trade-link has already been specified");
        }

        [TestMethod]
        public void SellingTest()
        {

            bool result = (new LisSellPage(DriverInstance.Driver).OpenPage() as LisSellPage)
                                .Check();

            LoggerService.WriteLine($"SellingTest ended with [{result}] result!");

            Assert.Fail("The amount of skins must be more than $3");
        }

        [TestMethod]
        public void AddskinToCart()
        {

            bool result = (new MarketPAge(DriverInstance.Driver).OpenPage() as MarketPAge)
                .addtocart();

            LoggerService.WriteLine($"AddskinToCart ended with [{result}] result!");
        }

        [TestMethod]
        public void RemoveoncefromCart()
        {

            bool result = (new MarketPAge(DriverInstance.Driver).OpenPage() as MarketPAge)
                .addtocart();

            LoggerService.WriteLine($"RemoveoncefromCart ended with [{result}] result!");
            Assert.Fail("Cart is empty");
        }

        [TestMethod]
        public void RemoveAllFromCart()
        {
            
                bool result = (new MarketPAge(DriverInstance.Driver).OpenPage() as MarketPAge)
                    .removeallcart();

                LoggerService.WriteLine($"RemoveAllFromCart ended with [{result}] result!");

            Assert.Fail("Cart is empty");


        }



        [TestCleanup]
        public void Cleaup()
        {
            DriverInstance.CloseDriver();
        }
    }
}