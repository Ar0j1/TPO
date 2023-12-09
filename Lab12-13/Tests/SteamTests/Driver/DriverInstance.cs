using Microsoft.SqlServer.Server;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using SteamTests.Service;

namespace SteamTests.Driver
{
    public static class DriverInstance
    {
        private static WebDriver? driver;
        public static WebDriver? Driver => driver;

        public static void CreateIntance(string browser = "edge")
        {
            if (driver == null)
            {
                EdgeOptions options = new EdgeOptions();

                string userProfilePath = "";

                switch (browser.ToLower())
                {
                    case "firefox":
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            driver = new FirefoxDriver();
                            break;
                        }
                    case "chrome":
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            driver = new ChromeDriver();
                            break;
                        }
                    case "edge":
                        {
                         userProfilePath = "C:\\Users\\Sashcha\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default";

                        options.AddArgument($"user-data-dir={userProfilePath}");

                        driver = new EdgeDriver(options);
                        break; 
                }
                    default: break;
                }


            }

            driver?.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver?.Manage().Window.Maximize();

            LoggerService.WriteLine("Driver started!");
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver?.Close();
                driver?.Dispose();
                driver = null;
            }

            LoggerService.WriteLine("Driver stoped!");
        }
    }
}
