using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTspecflow.PageObjects
{
    public class booking_HomePage
    {
        private IWebDriver driver;

        public booking_HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//a[@id='flights']")]
        private IWebElement flightLink;
        [FindsBy(How =How.XPath,Using = "//button[@aria-label=\"Dismiss sign-in info.\"]")]
        private IWebElement alert;        
        
        

        public IWebElement getalert()
        {
            return alert;
        }
        public IWebElement getflightLink()
        {
            return flightLink;
        }
        
        
    }
}
