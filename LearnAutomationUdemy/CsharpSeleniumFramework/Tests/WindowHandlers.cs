using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;

namespace CsharpSeleniumFramework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    internal class WindowHandlers
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
        public void WindowHandle()
        {
            String email = "mentor@rahulshettyacademy.com";
            String parentwindowID=driver.CurrentWindowHandle;
            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);
            String childWindow=driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindow);
            TestContext.Progress.WriteLine("Title :" + driver.Title);

            TestContext.Progress.WriteLine(driver.FindElement(By.XPath("//p[@class='im-para red']")).Text);
            
            
            String text = driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;
            //Please email us at mentor@rahulshettyacademy.com with below template to receive response
            //split and grab email
            String[] spliitedtext=text.Split("at");
            String[] trimmedstring = spliitedtext[1].Trim().Split(" ");
            TestContext.Progress.WriteLine(trimmedstring[0]);
            Assert.AreEqual(email, trimmedstring[0]);

            driver.SwitchTo().Window(parentwindowID);

        }
    }
}
