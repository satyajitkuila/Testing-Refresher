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
    internal class E2E_Test
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
        public void EndToEndFlow()
        {
            String[] expectedproducts = { "iphone X", "Blackberry" };

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            //using explicit wait here
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList <IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

                if (expectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    //click on addcart
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
        }
    }
}
