using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    internal class UsingAlerts
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
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            TestContext.Progress.WriteLine("Url :" + driver.Url);
            TestContext.Progress.WriteLine("Title :" + driver.Title);

        }
        [Test]
        public void test_Alert()
        {
            String name = "skuila";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("#alertbtn")).Click();
            String alertText=driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();

            //check th entered text on alert
            StringAssert.Contains(name, alertText, "Alert text does not contains the entered name");
            // If the assertion passes, print a message indicating that it passed
            Console.WriteLine("Assertion passed: Alert text contains the entered name");

        }
    }
}
