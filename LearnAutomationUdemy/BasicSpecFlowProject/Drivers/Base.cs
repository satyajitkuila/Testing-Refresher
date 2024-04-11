using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSpecFlowProject.Drivers
{
    public class Base
    {
        public static IWebDriver driver;
        public IWebDriver getDriver()

        {
            return driver;
        }



    }
}
