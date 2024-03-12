using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    internal class FunctionalTest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //using implicitwait here
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);    
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine("Url :" + driver.Url);
            TestContext.Progress.WriteLine("Title :" + driver.Title);

        }
        [Test]
        public void dropdown()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1);

            //css- tagname[attribute=value]
            //xpath- //tagname[@attribute=value]
            IList <IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radiobuttton in rdos)
            {
                if (radiobuttton.GetAttribute("value").Equals("user"))
                {
                    radiobuttton.Click();
                }
            }
        }
    }
}
