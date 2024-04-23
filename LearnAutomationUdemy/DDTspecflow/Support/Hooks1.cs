using DDTspecflow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DDTspecflow.Support
{
    [Binding]
    public sealed class Hooks1:Base
    {
        
        String browserName;

        [BeforeScenario]
        public void StartBrowser()
        {
            String browserName = ConfigurationManager.AppSettings["browser1"];
            InitBrowser(browserName);
            // Set implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new NotSupportedException($"Browser '{browserName}' is not supported.");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Quit the driver after scenario execution
         //  driver.Quit();
        }
    }
}
