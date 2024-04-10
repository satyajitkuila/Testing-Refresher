using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using AngleSharp.Dom;
using NUnit.Framework;

namespace CsharpSeleniumFramework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    internal class SortWebTables
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
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
            TestContext.Progress.WriteLine("Url :" + driver.Url);
            TestContext.Progress.WriteLine("Title :" + driver.Title);

        }
        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            //Step 1 get all veggie name into arraylist A
            IList <IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }
            //before sort
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            //Step 2 Sort the arraylist
            a.Sort();
            TestContext.Progress.WriteLine("After sorting: ");
            foreach (String  element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            //Step 3 go and click on sort
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();

            //step 4 again get all veggie list into arraylist B
            ArrayList b = new ArrayList();
            IList<IWebElement> sortedveggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in sortedveggies)
            {
                b.Add(veggie.Text);
            }

            //Step 5 Compare both arraylist A and B
            Assert.AreEqual(a,b);

        }
    }
}
