using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;

namespace DDTspecflow.Drivers
{
    public class Base
    {
        public static IWebDriver driver;
       

        public static IWebDriver getDriver()
        {
            return driver;
        }

        public static void InitBrowser(string browserName)
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
        public static string TakeScreenshot()
        {
            DateTime time = DateTime.Now;
            String fileName = "screenshot_" + time.ToString("h_mm_ss") + ".png";
            string path = @"D:\VS Studio Files\Testing Refresher\LearnAutomationUdemy\DDTspecflow\" + fileName;
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path);
            return path;
        }

    }
}
