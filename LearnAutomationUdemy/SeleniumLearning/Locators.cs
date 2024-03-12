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
    internal class Locators
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
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyy");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            // --//tagname[@attribute='value']--
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            //Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //using explicit wait here
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));
            
            String errorMessage =driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link= driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr =link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            //Validate URL of the Linktext
            Assert.AreEqual(expectedUrl, hrefAttr);

        }
    }
}
