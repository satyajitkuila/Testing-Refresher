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

namespace DDTspecflow.Drivers
{
    public class Base
    {
        public static IWebDriver driver;
       

        public static IWebDriver getDriver()
        {
            return driver;
        }

       
    }
}
