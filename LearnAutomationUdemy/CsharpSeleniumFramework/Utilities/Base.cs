using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace CsharpSeleniumFramework.Utilities
{
    public class Base
    {
        public IWebDriver driver;

        public IWebDriver getDriver()
        {
            return driver;
        }
        [SetUp]
        public void StartBrowser()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            String Url = ConfigurationManager.AppSettings["url"];

            InitBrowser(browserName);
            //using implicitwait here
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);    
            driver.Manage().Window.Maximize();
            driver.Url = Url;
            TestContext.Progress.WriteLine("Url :" + driver.Url);
            TestContext.Progress.WriteLine("Title :" + driver.Title);

        }

        public void InitBrowser(String browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }

        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
