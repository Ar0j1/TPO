using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

using ListTradesTest.Pages;

namespace ListTradesTest
{
    [TestClass]
    public class SteamTest
    {
        private WebDriver? driver;

        [TestInitialize]
        public void Init()
        {
            EdgeOptions options = new EdgeOptions();

            string userProfilePath = "C:\\Users\\Sashcha\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default";

            options.AddArgument($"user-data-dir={userProfilePath}");

            driver = new EdgeDriver("msedgedriver.exe", options);
        }

        [TestMethod]
        public void NoMoneyBuyTest()
        {
            if (driver == null)
                Assert.Fail("Driver not started!");

            bool result = (new LisProfilePage(driver).OpenPage() as LisProfilePage)
                                            .ChangeURL();
        }

        //[TestMethod]
        //public void CyrillicSearchTest()
        //{
        //    if (driver == null)
        //        Assert.Fail("Driver not started!");



        //    bool result = (new LisSellPage(driver).OpenPage() as LisSellPage)
        //                        .Check();


        //}

        //[TestCleanup]
        //public void Cleaup()
        //{
        //    driver.Close();
        //    driver.Dispose();
        //}
    }
}